using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Oracle.DataAccess.Client; // nodig voor Oracle connectie
using Oracle.DataAccess.Types; // nodig voor oracle connectie


namespace Proftaak
{
    public static class DatabaseHandler
    {
        private static OracleConnection con;
        private static OracleCommand cmd;
        private static OracleDataReader dr;

        public static void Connect()
        {
            try
            {
                con = new OracleConnection();
                con.ConnectionString = "User Id=system;Password=Wesley96;Data Source=localhost/xe";
              
                con.Open();

                //MessageBox.Show("DATABASE VERBINDING GELUKT");
            }
            catch
            {
                MessageBox.Show("DATABASE VERBINDNG MISLUKT");
            }
        }

        public static void Disconnect()
        {
            con.Close();
            con.Dispose();
        }

        public static void ReadData(string sql)
        {
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public static void WriteData(string sql)
        {
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public static string LogIn(string email, string wachtwoord)
        {
            Connect();

            try // kijk of het lukt
            {
                cmd.CommandText = "SELECT * FROM ACCOUNT"; // Selecteer alles van de TEST tabel (zelf aangemaakt moeten we veranderen naar Gebruiker) waar de naar refereert naar "1"

                cmd.Parameters.Add(new OracleParameter("Email",
                                       OracleDbType.Varchar2,
                                       email,
                                       ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.CommandType = CommandType.Text; // het is een SQL text command 
                OracleDataReader reader = cmd.ExecuteReader(); // maak een reader aan omdat je gegvevens krijgt
                if (!reader.HasRows) //zijn er rows met de query die we opgaven
                {
                    MessageBox.Show("Er zijn geen gebruikers met die naam"); //nee die zijn er niet
                    return "";
                }
                if (!wachtwoord.Equals(reader["WACHTWOORD"].ToString()))//is het wachtwoord dat we mee hebben gegeven gelijk aan de wWACHTWOORD rij in de tabel
                {
                    MessageBox.Show("Verkeerd wachtwoord");  // nee dat is hij niet
                    return "";
                }
                return reader["DISCRIMINATOR"].ToString(); //Ja dat is hij wel return true
            }
            catch (OracleException oe) // mocht er iets fout gaan
            {
                MessageBox.Show(oe.Message); // wat ging er fout
                return ""; // het is fout gegaan return false
            }
            finally
            {
                con.Close(); // sluit de connectie zodat hij niet voor eeuwig open blijft
            }
        }

        public static string AllAccounts(string discriminator)
        {
            string oradb = @"Data Source=localhost:1521;User Id=proftaak;Password=proftaak;"; //Waar en hoe verbind het programma met de database, username en password zijn de connecit die jij hebt gemaakt
            OracleConnection conn = new OracleConnection(oradb);

            try // kijk of het lukt
            {
                conn.Open(); // open de connectie
                OracleCommand cmd = new OracleCommand(); // nieuwe command om queries uit te voeren 
                cmd.Connection = conn; //zorg dat de queries naar de juiste connectie gaan
                cmd.CommandText = "SELECT * FROM ACCOUNT WHERE DISCRIMINATOR= :Discriminator"; // Selecteer alles van de TEST tabel (zelf aangemaakt moeten we veranderen naar Gebruiker) waar de naar refereert naar "1"

                cmd.Parameters.Add(new OracleParameter("Discriminator", OracleDbType.Varchar2, discriminator, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.CommandType = CommandType.Text; // het is een SQL text command 
                OracleDataReader reader = cmd.ExecuteReader(); // maak een reader aan omdat je gegvevens krijgt
                if (!reader.HasRows) //zijn er rows met de query die we opgaven
                {
                    MessageBox.Show("Er zijn geen accounts gevonden"); //nee die zijn er niet
                    return "";
                }
                return reader["VOORNAAM"].ToString();
            }
            catch (OracleException oe) // mocht er iets fout gaan
            {
                MessageBox.Show(oe.Message); // wat ging er fout
                return ""; // het is fout gegaan return false
            }
            finally
            {
                conn.Close(); // sluit de connectie zodat hij niet voor eeuwig open blijft
            }
        }

        public static void AddVrijwilliger(Vrijwilliger vrijwilliger)
        {
            string oradb = @"Data Source=localhost:1521;User Id=proftaak;Password=proftaak;"; //Waar en hoe verbind het programma met de database, username en password zijn de connecit die jij hebt gemaakt
            OracleConnection conn = new OracleConnection(oradb);

            try // kijk of het lukt
            {
                conn.Open(); // open de connectie
                OracleCommand cmd = new OracleCommand(); // nieuwe command om queries uit te voeren 
                cmd.Connection = conn; //zorg dat de queries naar de juiste connectie gaan
                cmd.CommandText = "INSERT INTO \"ACCOUNT\" (EMAILADRES, WACHTWOORD, DISCRIMINATOR, WOONPLAATS, STRAATNAAM, HUISNUMMER, TELEFOONNUMMER, VOORNAAM, ACHTERNAAM, GEBOORTEDATUM, BIOGRAFIE, COMPETENTIES, VERVOER, BESCHIKBAARHEID, LOCATIEVOG, LOCATIEFOTO) VALUES (:email, :wacthwoord, :discriminator, :woonplaats, :straatnaam, :huisnummer, :telefoonnummer, :voornaam, :achternaam, :geboortedatum, :biografie, :competenties, :vervoer, :beschikbaarheid, :VOG, :foto)";

                cmd.Parameters.Add(new OracleParameter("email", OracleDbType.Varchar2, vrijwilliger.Email, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("wacthwoord", OracleDbType.Varchar2, vrijwilliger.Wachtwoord, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("discriminator", OracleDbType.Varchar2, "V", ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("woonplaats", OracleDbType.Varchar2, vrijwilliger.City, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("straatnaam", OracleDbType.Varchar2, vrijwilliger.Street, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("huisnummer", OracleDbType.Varchar2, vrijwilliger.Address, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("telefoonnummer", OracleDbType.Varchar2, vrijwilliger.PhoneNumber, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("voornaam", OracleDbType.Varchar2, vrijwilliger.FirstName, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("achternaam", OracleDbType.Varchar2, vrijwilliger.LastName, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("geboortedatum", OracleDbType.Date, vrijwilliger.DateOfBirth, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("biografie", OracleDbType.Varchar2, vrijwilliger.Bio, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("competenties", OracleDbType.Varchar2, vrijwilliger.Competences, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("vervoer", OracleDbType.Varchar2, vrijwilliger.Vervoer, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("beschikbaarheid", OracleDbType.Varchar2, vrijwilliger.Availability, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("VOG", OracleDbType.Varchar2, vrijwilliger.LocatieVOG, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("foto", OracleDbType.Varchar2, vrijwilliger.LocatiePhoto, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen


                cmd.CommandType = CommandType.Text; // het is een SQL text command 
                OracleDataReader reader = cmd.ExecuteReader(); // maak een reader aan omdat je gegvevens krijgt
            }
            catch (OracleException oe) // mocht er iets fout gaan
            {
                MessageBox.Show(oe.Message); // wat ging er fout
            }
            finally
            {
                conn.Close(); // sluit de connectie zodat hij niet voor eeuwig open blijft
            }
        }

        public static void DelVrijwilliger()
        {
            
        }

        public static void AddHelpBehoevende(HelpBehoevende hulpbehoevende)
        {
            string oradb = @"Data Source=localhost:1521;User Id=proftaak;Password=proftaak;"; //Waar en hoe verbind het programma met de database, username en password zijn de connecit die jij hebt gemaakt
            OracleConnection conn = new OracleConnection(oradb);

            try // kijk of het lukt
            {
                conn.Open(); // open de connectie
                OracleCommand cmd = new OracleCommand(); // nieuwe command om queries uit te voeren 
                cmd.Connection = conn; //zorg dat de queries naar de juiste connectie gaan
                cmd.CommandText = "INSERT INTO \"ACCOUNT\" (EMAILADRES, WACHTWOORD, DISCRIMINATOR, WOONPLAATS, STRAATNAAM, HUISNUMMER, TELEFOONNUMMER, VOORNAAM, ACHTERNAAM, GEBOORTEDATUM, BIOGRAFIE, PROBLEEMSTELLING) VALUES (:email, :wacthwoord, :discriminator, :woonplaats, :straatnaam, :huisnummer, :telefoonnummer, :voornaam, :achternaam, :geboortedatum, :biografie, :probleemstelling)";

                cmd.Parameters.Add(new OracleParameter("email", OracleDbType.Varchar2, hulpbehoevende.Email, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("wacthwoord", OracleDbType.Varchar2, hulpbehoevende.Wachtwoord, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("discriminator", OracleDbType.Varchar2, "H", ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("woonplaats", OracleDbType.Varchar2, hulpbehoevende.City, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("straatnaam", OracleDbType.Varchar2, hulpbehoevende.Street, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("huisnummer", OracleDbType.Varchar2, hulpbehoevende.Address, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("telefoonnummer", OracleDbType.Varchar2, hulpbehoevende.PhoneNumber, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("voornaam", OracleDbType.Varchar2, hulpbehoevende.FirstName, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("achternaam", OracleDbType.Varchar2, hulpbehoevende.LastName, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("geboortedatum", OracleDbType.Date, hulpbehoevende.DateOfBirth, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("biografie", OracleDbType.Varchar2, hulpbehoevende.Bio, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.Parameters.Add(new OracleParameter("Probleemstelling", OracleDbType.Varchar2, hulpbehoevende.Problem, ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen

                cmd.CommandType = CommandType.Text; // het is een SQL text command 
                OracleDataReader reader = cmd.ExecuteReader(); // maak een reader aan omdat je gegvevens krijgt
            }
            catch (OracleException oe) // mocht er iets fout gaan
            {
                MessageBox.Show(oe.Message); // wat ging er fout
            }
            finally
            {
                conn.Close(); // sluit de connectie zodat hij niet voor eeuwig open blijft
            }
        }

        public static void DelHelpbehoevende()
        {
            
        }

        public static void AddChatMessage(int berichtId, string tekst, string datum, int fkOntvanger, int fkVerzender)
        {
            string oradb = @"Data Source=localhost:1521;User Id=proftaak;Password=proftaak;"; //Waar en hoe verbind het programma met de database, username en password zijn de connecit die jij hebt gemaakt
            OracleConnection conn = new OracleConnection(oradb);

            try // kijk of het lukt
            {
                conn.Open(); // open de connectie
                OracleCommand cmd = new OracleCommand(); // nieuwe command om queries uit te voeren 
                cmd.Connection = conn; //zorg dat de queries naar de juiste connectie gaan
                cmd.CommandText = "INSERT INTO CHATBERICHT (CHATBERICHTID, TEKST, DATUM, FKONTVANGER, FKVERZENDER) VALUES (:berichtID, :Tekst, TO_DATE(:Datum, 'YYYY-MM-DD HH24:MI:SS'), :fkOntvanger, fkVerzender);"; // Selecteer alles van de TEST tabel (zelf aangemaakt moeten we veranderen naar Gebruiker) waar de naar refereert naar "1"

                cmd.Parameters.Add(new OracleParameter("ChatBerichtID", OracleDbType.Int32, berichtId, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("Tekst", OracleDbType.Varchar2, tekst, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("Datum", OracleDbType.Varchar2, datum, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("fkOntvanger", OracleDbType.Int32, fkOntvanger, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("fkVerzender", OracleDbType.Int32, fkVerzender, ParameterDirection.Input));

                cmd.CommandType = CommandType.Text; // het is een SQL text command 
                OracleDataReader reader = cmd.ExecuteReader(); // maak een reader aan omdat je gegvevens krijgt
                
            }
            catch (OracleException oe) // mocht er iets fout gaan
            {
                MessageBox.Show(oe.Message); // wat ging er fout
                 // het is fout gegaan return false
            }
            finally
            {
                conn.Close(); // sluit de connectie zodat hij niet voor eeuwig open blijft
            }
        }

        public static string GetChatMessage(int fkVerzender)
        {
            string bericht;
            string oradb = @"Data Source=localhost:1521;User Id=proftaak;Password=proftaak;"; //Waar en hoe verbind het programma met de database, username en password zijn de connecit die jij hebt gemaakt
            OracleConnection conn = new OracleConnection(oradb);

            try
            {
                conn.Open(); // open de connectie
                OracleCommand cmd = new OracleCommand(); // nieuwe command om queries uit te voeren 
                cmd.Connection = conn; //zorg dat de queries naar de juiste connectie gaan
                cmd.CommandText = "SELECT Tekst FROM Charbericht WHERE fkVerzender = :fkVerzender;";

                cmd.Parameters.Add(new OracleParameter("fkVerzender", OracleDbType.Int32, fkVerzender, ParameterDirection.Input));

                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();
                bericht = Convert.ToString(reader["Tekst"]);
            }
            catch (OracleException oe)
            {
                MessageBox.Show(oe.Message);
                bericht = null;
            }
            finally
            {
                conn.Close();
            }
            return bericht;
        }

        public static int GetAccountID(string email)
        {
            int accountid;
            string oradb = @"Data Source=localhost:1521;User Id=proftaak;Password=proftaak;"; //Waar en hoe verbind het programma met de database, username en password zijn de connecit die jij hebt gemaakt
            OracleConnection conn = new OracleConnection(oradb);

            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT AccountID FROM Account WHERE Emailadres = :Email;";

                cmd.Parameters.Add(new OracleParameter("Email", OracleDbType.Varchar2, email, ParameterDirection.Input));

                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();
                accountid = Convert.ToInt32(reader["AccountID"]);
            }
            catch (OracleException oe)
            {
                MessageBox.Show(oe.Message);
                accountid = -1;
            }
            finally
            {
                conn.Close();
            }
            return accountid;
        }

        public static void AddAnswer()
        {
            
        }

        public static void AddReview()
        {
            
        }


        public static void AddMeeting()
        {
            
        }

        public static void EditMeeting()
        {

        }

        public static void AddHulpVraag()
        {
            
        }

        public static void GetHulpVraag()
        {
            Connect();

            ReadData("SELECT * FROM HULPVRAAG");

            try
            {
                while (dr.Read())
                {
                    int hulpvraagID;
                    string tekstprobleem;
                    DateTime aanmaakdatum;
                    DateTime begindatum;
                    string duur;
                    string urgentie;

                    hulpvraagID = dr.GetInt32(0);
                    tekstprobleem = dr.GetString(1);
                    aanmaakdatum = dr.GetDateTime(2);
                    begindatum = dr.GetDateTime(3);
                    duur = dr.GetString(4);
                    urgentie = dr.GetString(5);

                    HelpRequest helpRequest = new HelpRequest(hulpvraagID, tekstprobleem,aanmaakdatum,begindatum,duur,urgentie);

                    HelpHandler helphandler = new HelpHandler();

                    helphandler.AddHelpRequest(helpRequest);
                }
            }

            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Disconnect();
            }
        }

        public static void GetReview()
        {
            Connect();

            ReadData("SELECT * FROM RECENSIE");

            try
            {
                while (dr.Read())
                {
                    int recensieID;
                    string inhoud;
                    DateTime datum;
                    int beoordeling;

                    recensieID = dr.GetInt32(0);
                    inhoud = dr.GetString(1);
                    datum = dr.GetDateTime(2);
                    beoordeling = dr.GetInt32(3);

                    Review review = new Review(recensieID, inhoud, datum, beoordeling);

                    HelpHandler helphandler = new HelpHandler();

                    helphandler.AddReview(review);
                }
            }

            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Disconnect();
            }
        }

        public static void GetAnswer()
        {
            Connect();

            ReadData("SELECT * FROM REACTIE");

            try
            {
                while (dr.Read())
                {
                    int answerID;
                    string inhoud;
                    DateTime datum;

                    answerID = dr.GetInt32(0);
                    inhoud = dr.GetString(1);
                    datum = dr.GetDateTime(2);

                    Answer answer = new Answer(answerID, inhoud, datum);

                    HelpHandler helphandler = new HelpHandler();

                    helphandler.AddAnswer(answer);
                }
            }

            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Disconnect();
            }
        }

        public static void EditHelpRequest(int id, string inhoud)
        {
            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE HULPVRAAG SET TEKSTPROBLEEM = :UPDATEDTEKST WHERE HULPVRAAGID = :HULPID";
                cmd.Parameters.Add("UPDATEDTEKST", OracleDbType.Varchar2).Value = inhoud;
                cmd.Parameters.Add("HULPID", OracleDbType.Int32).Value = id;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                Disconnect();
            }
        }

        public static void EditReview(int id, string inhoud)
        {
            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE RECENSIE SET TEKST = :UPDATEDTEKST WHERE RECENSIEID = :RECENSIEID";
                cmd.Parameters.Add("UPDATEDTEKST", OracleDbType.Varchar2).Value = inhoud;
                cmd.Parameters.Add("RECENSIEID", OracleDbType.Int32).Value = id;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                Disconnect();
            }
        }

        public static void EditAnswer(int id, string inhoud)
        {
            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE REACTIE SET TEKST = :UPDATEDTEKST WHERE ANSWERID = :ANSWERID";
                cmd.Parameters.Add("UPDATEDTEKST", OracleDbType.Varchar2).Value = inhoud;
                cmd.Parameters.Add("ANSWERID", OracleDbType.Int32).Value = id;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                Disconnect();
            }
        }

        public static void DelHelpRequest(int id)
        {
            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE HULPVRAAG WHERE HULPVRAAGID = :HULPID";
                cmd.Parameters.Add("HULPID", OracleDbType.Int32).Value = id;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                Disconnect();
            }
        }

        public static void DelReview(int id)
        {
            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE RECENSIE WHERE RECENSIEID = :RECENSIEID";
                cmd.Parameters.Add("RECENSIEID", OracleDbType.Int32).Value = id;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                Disconnect();
            }
        }

        public static void DelAnswer(int id)
        {
            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE REACTIE WHERE REACTIEID = :REACTIEID";
                cmd.Parameters.Add("REACTIEID", OracleDbType.Int32).Value = id;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                Disconnect();
            }
        }
    }
}
