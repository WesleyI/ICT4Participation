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
    class DatabaseHandler
    {
        List<Vrijwilliger> vrijwilligers = new List<Vrijwilliger>(); 
        List<Hulpbehoevende> hulpbehoevenden = new List<Hulpbehoevende>(); 
        List<HelpRequest> helpRequests = new List<HelpRequest>();
        List<Answer> answers = new List<Answer>();
        List<Review> reviews = new List<Review>();
        
        public string LogIn(string email, string wachtwoord)
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

        public string AllAccounts(string discriminator)
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

        public void AddVrijwilliger()
        {
            
        }

        public void DelVrijwilliger()
        {
            
        }

        public void AddHelpBehoevende()
        {
            
        }

        public void DelHelpbehoevende()
        {
            
        }

        public void AddChatMessage(int berichtId, string tekst, string datum, int fkOntvanger, int fkVerzender)
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

        public void AddAnswer()
        {
            
        }

        public void AddReview()
        {
            
        }

        public void DelReview()
        {
            
        }

        public void EditReview()
        {

        }

        public void AddMeeting()
        {
            
        }

        public void EditMeeting()
        {

        }

        public void AddHulpVraag()
        {
            
        }

        public void EditHulpVraag()
        {

        }
    }
}
