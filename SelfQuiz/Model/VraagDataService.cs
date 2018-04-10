using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfQuiz.Model
{
    class VraagDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        public List<Vraag> getVragen()
        {
            // SQL statement wordt bewaard in een string.
            string sql = "Select * from SelfQuiz.Vraag order by naam";
            // Uitvoeren van sql statement.
            // Type casten van het generieke return type naar een collectie van Vragen.
            return (List<Vraag>) db.Query<Vraag>(sql);
        }

        public void UpdateVraag(Vraag vraag)
        {
            // SQL statement update
            string sql = "Update SelfQuiz.Vraag set naam = @naam, antwoord = @antwoord, soortId = @soortId where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                vraag.Id,
                vraag.Naam,
                vraag.Antwoord,
                vraag.SoortId
            });
        }

        public void InsertVraag(Vraag vraag)
        {
            // SQL statement insert
            string sql = "Insert into SelfQuiz.Vraag(naam, antwoord, soortId) values (@naam, @antwoord, @soortId)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                vraag.Naam,
                vraag.Antwoord,
                vraag.SoortId
            });
        }

        public void DeleteVraag(Vraag vraag)
        {
            // SQL statement delete
            string sql = "Delete SelfQuiz.Vraag where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { vraag.Id });
        }
    }
}
