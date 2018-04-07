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
    class SoortDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        public List<Soort> getSoorten()
        {
            // SQL statement wordt bewaard in een string.
            string sql = "Select * from Soort order by naam";
            // Uitvoeren van sql statement.
            // Type casten van het generieke return type naar een collectie van Vragen.
            return (List<Soort>) db.Query<Soort>(sql);
        }

        public void Updatesoort(Soort soort)
        {
            // SQL statement update
            string sql = "Update Soort set naam = @naam where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                soort.Naam
            });
        }

        public void InsertSoort(Soort soort)
        {
            // SQL statement insert
            string sql = "Insert into Soort(naam) values (@naam)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                soort.Naam
            });
        }

        public void DeleteSoort(Soort soort)
        {
            // SQL statement delete
            string sql = "Delete Soort where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { soort.Id });
        }
    }
}
