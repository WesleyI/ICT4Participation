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
            string oradb = @"Data Source=localhost:1521;User Id=proftaak;Password=proftaak;"; //Waar en hoe verbind het programma met de database, username en password zijn de connecit die jij hebt gemaakt
            OracleConnection conn = new OracleConnection(oradb);

            try // kijk of het lukt
            {
                conn.Open(); // open de connectie
                OracleCommand cmd = new OracleCommand(); // nieuwe command om queries uit te voeren 
                cmd.Connection = conn; //zorg dat de queries naar de juiste connectie gaan
                cmd.CommandText = "SELECT * FROM ACCOUNT WHERE EMAILADRES= :Email"; // Selecteer alles van de TEST tabel (zelf aangemaakt moeten we veranderen naar Gebruiker) waar de naar refereert naar "1"

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
                conn.Close(); // sluit de connectie zodat hij niet voor eeuwig open blijft
            }
        }

        public static string AllAccounts(string discriminator)
        {
            string oradb = @"Data Source=localhost:1521;User Id=system;Password=Wesley96;"; //Waar en hoe verbind het programma met de database, username en password zijn de connecit die jij hebt gemaakt
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
            string oradb = @"Data Source=localhost:1521;User Id=system;Password=Wesley96;"; //Waar en hoe verbind het programma met de database, username en password zijn de connecit die jij hebt gemaakt
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
            string oradb = @"Data Source=localhost:1521;User Id=system;Password=Wesley96;"; //Waar en hoe verbind het programma met de database, username en password zijn de connecit die jij hebt gemaakt
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

        public static int GetAccountID(string email)
        {
            int accountid;
            string oradb = @"Data Source=localhost:1521;User Id=system;Password=Wesley96;"; //Waar en hoe verbind het programma met de database, username en password zijn de connecit die jij hebt gemaakt
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

        public static int GetAccountIDReview(int id)
        {
            int accountid = 0;
            string oradb = @"Data Source=localhost:1521;User Id=system;Password=Wesley96;"; //Waar en hoe verbind het programma met de database, username en password zijn de connecit die jij hebt gemaakt
            OracleConnection conn = new OracleConnection(oradb);

            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT AccountID FROM Account WHERE ACCOUNTID IN (SELECT RECENSIEID FROM RECENSIE WHERE RECENSIEID = " + id + ")";

                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    accountid = Convert.ToInt32(reader["ACCOUNTID"]);
                }
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

        public static bool AddAnswer(string tekst, DateTime datum, int ontvanger, int afzender)
        {
            string oradb = @"Data Source=localhost:1521;User Id=system;Password=Wesley96;"; //Waar en hoe verbind het programma met de database, username en password zijn de connecit die jij hebt gemaakt
            OracleConnection conn = new OracleConnection(oradb);

            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO REACTIE (TEKST, DATUM, FKACCOUNTID, FKRECENSIEID) VALUES(:TEKST, :DATUM, :FKACCOUNTID, :FKRECENSIEID)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("TEKST", OracleDbType.Varchar2).Value = tekst;
                cmd.Parameters.Add("DATUM", OracleDbType.Date).Value = datum;
                cmd.Parameters.Add("FKACCOUNTID", OracleDbType.Int32).Value = ontvanger;
                cmd.Parameters.Add("FKRECENSIEID", OracleDbType.Int32).Value = afzender;

                int rowsUpdated = cmd.ExecuteNonQuery();
                if (rowsUpdated != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
            return false;
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

        public static void GetMeeting()
        {
            Connect();

            ReadData("SELECT * FROM KENNISMAKINGSGESPREK");

            try
            {
                while (dr.Read())
                {
                    int id;
                    DateTime datum;
                    string tekst;
                    int account;

                    id = Convert.ToInt32(dr.GetValue(0));
                    datum = dr.GetDateTime(1);
                    tekst = dr.GetString(2);
                    account = Convert.ToInt32(dr.GetValue(3));

                    Meeting meeting = new Meeting(id, datum, tekst, account);

                    HelpHandler.AddMeeting(meeting);
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

                    hulpvraagID = Convert.ToInt32(dr.GetValue(0));
                    tekstprobleem = dr.GetString(1);
                    aanmaakdatum = dr.GetDateTime(2);
                    begindatum = dr.GetDateTime(3);
                    duur = dr.GetString(4);
                    urgentie = dr.GetString(5);

                    HelpRequest helpRequest = new HelpRequest(hulpvraagID, tekstprobleem, aanmaakdatum, begindatum, duur, urgentie);

                    HelpHandler.AddHelpRequest(helpRequest);
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
                    int verzender;                    

                    recensieID = Convert.ToInt32(dr.GetValue(0));
                    inhoud = dr.GetString(1);
                    datum = dr.GetDateTime(2);
                    beoordeling = Convert.ToInt32(dr.GetValue(3));
                    verzender = Convert.ToInt32(dr.GetValue(5));

                    Review review = new Review(recensieID, inhoud, datum, beoordeling, verzender);

                    HelpHandler.AddReview(review);
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

        public static string GetAccountNaam(int ontvanger)
        {
            string oradb = @"Data Source=localhost:1521;User Id=system;Password=Wesley96;"; //Waar en hoe verbind het programma met de database, username en password zijn de connecit die jij hebt gemaakt
            OracleConnection conn = new OracleConnection(oradb);

            try // kijk of het lukt
            {
                conn.Open(); // open de connectie
                OracleCommand cmd = new OracleCommand(); // nieuwe command om queries uit te voeren 
                cmd.Connection = conn; //zorg dat de queries naar de juiste connectie gaan
                cmd.CommandText = "SELECT * FROM ACCOUNT WHERE ACCOUNTID = (SELECT FKVERZENDER FROM RECENSIE WHERE FKONTVANGER = " + ontvanger + ")"; // Selecteer alles van de TEST tabel (zelf aangemaakt moeten we veranderen naar Gebruiker) waar de naar refereert naar "1"

                //cmd.Parameters.Add(new OracleParameter("verzender",
                //                       OracleDbType.Varchar2,
                //                       verzender,
                //                       ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.CommandType = CommandType.Text; // het is een SQL text command 
                OracleDataReader reader = cmd.ExecuteReader(); // maak een reader aan omdat je gegvevens krijgt
                string voornaam = "";
                string achternaam = "";
                while (reader.Read())
                {
                    voornaam = reader["VOORNAAM"].ToString();
                    achternaam = reader["ACHTERNAAM"].ToString();
                }
                return voornaam + " " + achternaam; //Ja dat is hij wel return true
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

                    HelpHandler.AddAnswer(answer);
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

        public static bool AcceptHelpRequest(int vrijId, int hulpVraagId)
        {
            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE HULPVRAAG SET ACCEPTER= :vrijID WHERE HULPVRAAGID = :hulpID";
                cmd.Parameters.Add("vrijID", OracleDbType.Int32).Value = vrijId;
                cmd.Parameters.Add("hulpID", OracleDbType.Int32).Value = hulpVraagId;
                int rowsUpdated = cmd.ExecuteNonQuery();
                if (rowsUpdated != null)
                {
                    return true;
                }
                return false;
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
            return false;
        }

        public static int CountAcceptedHelpRequests(int id)
        {
            Connect();

            ReadData("SELECT HULPVRAAGID FROM HULPVRAAG WHERE ACCEPTER =" + id);

            List<int> counter = new List<int>();
            try
            {
                while (dr.Read())
                {
                    counter.Add(Convert.ToInt32(dr["HULPVRAAGID"]));
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

            int counted = counter.Count();

            return counted;
        }

        public static bool AcceptMeeting(int vrijID, int meetingID)
        {
            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE KENNISMAKINGSGESPREK SET GEACCEPTEERD= :vrijID WHERE KENNISMAKINGSGESPREKID = :meetingID";
                cmd.Parameters.Add("vrijID", OracleDbType.Int32).Value = vrijID;
                cmd.Parameters.Add("meetingID", OracleDbType.Int32).Value = meetingID;
                int rowsUpdated = cmd.ExecuteNonQuery();
                if (rowsUpdated != 0)
                {
                    return true;
                }
                return false;
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
            return false;
        }

        public static List<Meeting> GetAcceptedMeetings(int ID)
        {
            Connect();

            ReadData("SELECT * FROM KENNISMAKINGSGESPREK WHERE GEACCEPTEERD = " + ID);

            List<Meeting> accepted = new List<Meeting>();

            try
            {
                while (dr.Read())
                {
                    int kennismakingsID;
                    string aanvraag;
                    DateTime datum;
                    int aanvrager;

                    kennismakingsID = Convert.ToInt32(dr["KENNISMAKINGSGESPREKID"]);
                    aanvraag = dr["TEKST"].ToString();
                    datum = Convert.ToDateTime(dr["DATUM"]);
                    aanvrager = Convert.ToInt32(dr["FKACCOUNTID"]);


                    accepted.Add(new Meeting(kennismakingsID, datum, aanvraag, aanvrager));
                }
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            finally
            {
                Disconnect();
            }
            return accepted;
        }

        public static HelpRequest GetAcceptedHelpRequest(int id)
        {
            Connect();

            ReadData("SELECT * FROM HULPVRAAG WHERE ACCEPTER = " + id);

            HelpRequest accepted = null;

            try
            {
                while (dr.Read())
                {
                    int helpId;
                    string problem;
                    DateTime dateOfCreation;
                    DateTime beginDate;
                    string duration;
                    string urgent;

                    helpId = Convert.ToInt32(dr["HULPVRAAGID"]);
                    problem = dr["TEKSTPROBLEEM"].ToString();
                    dateOfCreation = Convert.ToDateTime(dr["AANMAAKDATUM"]);
                    beginDate = Convert.ToDateTime(dr["BEGINDATUM"]);
                    duration = dr["DUUR"].ToString();
                    urgent = dr["URGENT"].ToString();

                    accepted = new HelpRequest(helpId, problem, dateOfCreation, beginDate, duration, urgent);
                }
            }

            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            finally
            {
                Disconnect();
            }
            return accepted;

        }

        public static List<HelpRequest> GetAcceptedHelpRequests(int id)
        {
            Connect();

            ReadData("SELECT * FROM HULPVRAAG WHERE ACCEPTER = " + id);

            List<HelpRequest> accepted = new List<HelpRequest>();

            try
            {
                while (dr.Read())
                {
                    int helpId;
                    string problem;
                    DateTime dateOfCreation;
                    DateTime beginDate;
                    string duration;
                    string urgent;

                    helpId = Convert.ToInt32(dr["HULPVRAAGID"]);
                    problem = dr["TEKSTPROBLEEM"].ToString();
                    dateOfCreation = Convert.ToDateTime(dr["AANMAAKDATUM"]);
                    beginDate = Convert.ToDateTime(dr["BEGINDATUM"]);
                    duration = dr["DUUR"].ToString();
                    urgent = dr["URGENT"].ToString();

                    accepted.Add(new HelpRequest(helpId, problem, dateOfCreation, beginDate, duration, urgent));
                }
            }

            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            finally
            {
                Disconnect();
            }
            return accepted;

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
                cmd.CommandText = "UPDATE REACTIE SET TEKST = :UPDATEDTEKST WHERE REACTIEID = :REACTIEID";
                cmd.Parameters.Add("UPDATEDTEKST", OracleDbType.Varchar2).Value = inhoud;
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

        public static void GetHulpBehoevende()
        {
            Connect();

            ReadData("SELECT * FROM ACCOUNT WHERE DISCRIMINATOR = 'H'");

            try
            {
                while (dr.Read())
                {
                    int id;
                    string firstName;
                    string lastName;

                    id = Convert.ToInt32(dr.GetValue(0));
                    firstName = dr.GetString(8);
                    lastName = dr.GetString(9);

                    AccountHandler accounthandler = new AccountHandler();

                    HelpBehoevende helpbehoevende = new HelpBehoevende(id, firstName, lastName);

                    accounthandler.AddHelpbehoevende(helpbehoevende);
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

        public static void GetVrijwilliger()
        {
            Connect();

            ReadData("SELECT * FROM ACCOUNT WHERE DISCRIMINATOR = 'V'");

            try
            {
                while (dr.Read())
                {
                    int id;
                    string firstName;
                    string lastName;

                    id = dr.GetInt32(0);
                    firstName = dr.GetString(8);
                    lastName = dr.GetString(9);

                    AccountHandler accounthandler = new AccountHandler();

                    Vrijwilliger vrijwilliger = new Vrijwilliger(id, firstName, lastName);

                    accounthandler.AddVrijwilliger(vrijwilliger);
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

        public static Vrijwilliger GetVrijwilligerInlog(string email)
        {
            string oradb = @"Data Source=localhost:1521;User Id=system;Password=Wesley96;"; //Waar en hoe verbind het programma met de database, username en password zijn de connecit die jij hebt gemaakt
            OracleConnection conn = new OracleConnection(oradb);

            try // kijk of het lukt
            {
                conn.Open(); // open de connectie
                OracleCommand cmd = new OracleCommand(); // nieuwe command om queries uit te voeren 
                cmd.Connection = conn; //zorg dat de queries naar de juiste connectie gaan
                cmd.CommandText = "SELECT * FROM ACCOUNT WHERE EMAILADRES = \'" + email + "\'"; // Selecteer alles van de TEST tabel (zelf aangemaakt moeten we veranderen naar Gebruiker) waar de naar refereert naar "1"

                //cmd.Parameters.Add(new OracleParameter("verzender",
                //                       OracleDbType.Varchar2,
                //                       verzender,
                //                       ParameterDirection.Input)); //maak de "1" referentie en zorg dat hij verwijst naar de meegegeven string Inlognaam, deze parameters meegeven werkt SQL injection tegen
                cmd.CommandType = CommandType.Text; // het is een SQL text command 
                OracleDataReader reader = cmd.ExecuteReader(); // maak een reader aan omdat je gegvevens krijgt
                int id = 0;//
                string voornaam = "";
                string achternaam = "";
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["ACCOUNTID"]);
                    voornaam = reader["VOORNAAM"] as string;
                    achternaam = reader["ACHTERNAAM"] as string;
                }
                Vrijwilliger vrijwilliger = new Vrijwilliger(id, voornaam, achternaam);
                return vrijwilliger; //Ja dat is hij wel return true
            }
            catch (OracleException oe) // mocht er iets fout gaan
            {
                MessageBox.Show(oe.Message); // wat ging er fout
                return null; // het is fout gegaan return false
            }
            finally
            {
                conn.Close(); // sluit de connectie zodat hij niet voor eeuwig open blijft
            }
        }

        public static void AddChatMessage(string bericht, DateTime datum, int afzender, int ontvanger)
        {
            Connect();

            int chatID = 1;

            ReadData("SELECT MAX(CHATBERICHTID) +1  FROM CHATBERICHT");
            try
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        chatID = dr.GetInt32(0);
                    }
                }
            }
            catch (InvalidCastException ICE)
            {
                MessageBox.Show(ICE.ToString());
            }

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO CHATBERICHT (CHATBERICHTID, TEKST, DATUM, FKONTVANGER, FKVERZENDER) VALUES(:CHATBERICHTID, :TEKST, :DATUM, :FKONTVANGER, :FKVERZENDER)";
                cmd.Parameters.Add("CHATBERICHTID", OracleDbType.Int32).Value = chatID;
                cmd.Parameters.Add("TEKST", OracleDbType.Varchar2).Value = bericht;
                cmd.Parameters.Add("DATUM", OracleDbType.Date).Value = datum;
                cmd.Parameters.Add("FKONTVANGER", OracleDbType.Int32).Value = ontvanger;
                cmd.Parameters.Add("FKVERZENDER", OracleDbType.Int32).Value = afzender;

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
          
        public static void GetChatAfzender(int afzender)
        {
            Connect();

            ReadData("SELECT * FROM CHATBERICHT WHERE FKVERZENDER = " + afzender.ToString());

            try
            {
                while (dr.Read())
                {
                    int berichtId;
                    string tekst;
                    DateTime datum;
                    int ontvanger;
                    int verzender;

                    berichtId = dr.GetInt32(0);
                    tekst = dr.GetString(1);
                    datum = dr.GetDateTime(2);
                    ontvanger = dr.GetInt32(3);
                    verzender = dr.GetInt32(4);

                    ChatMessage chatmessage = new ChatMessage(berichtId, tekst, datum, ontvanger, verzender);

                    HelpHandler.AddChatMessage(chatmessage);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Disconnect();
            }
        }


        public static void GetChatOntvanger(int doel)
        {
            Connect();

            ReadData("SELECT * FROM CHATBERICHT WHERE FKONTVANGER = " + doel.ToString());

            try
            {
                while (dr.Read())
                {
                    int berichtId;
                    string tekst;
                    DateTime datum;
                    int ontvanger;
                    int verzender;

                    berichtId = dr.GetInt32(0);
                    tekst = dr.GetString(1);
                    datum = dr.GetDateTime(2);
                    ontvanger = dr.GetInt32(3);
                    verzender = dr.GetInt32(4);

                    ChatMessage chatmessage = new ChatMessage(berichtId, tekst, datum, ontvanger, verzender);

                    HelpHandler.AddChatMessage(chatmessage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Disconnect();
            }
        }
         
    }
}
