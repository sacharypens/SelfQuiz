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
    class TagDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        public List<Tag> getTags()
        {
            // SQL statement wordt bewaard in een string.
            string sql = "Select * from Tag order by naam";
            // Uitvoeren van sql statement.
            // Type casten van het generieke return type naar een collectie van Vragen.
            return (List<Tag>) db.Query<Tag>(sql);
        }

        public void Updatetag(Tag tag)
        {
            // SQL statement update
            string sql = "Update Tag set naam = @naam where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                tag.Naam
            });
        }

        public void InsertTag(Tag tag)
        {
            // SQL statement insert
            string sql = "Insert into Tag(naam) values (@naam)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                tag.Naam
            });
        }

        public void DeleteTag(Tag tag)
        {
            // SQL statement delete
            string sql = "Delete Tag where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { tag.Id });
        }
    }
}
