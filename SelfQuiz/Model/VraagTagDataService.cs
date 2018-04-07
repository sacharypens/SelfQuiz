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
    class VraagTagDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        public List<VraagTag> getVraagTags()
        {
            // SQL statement wordt bewaard in een string.
            string sql = "Select * from VraagTag order by id";
            // Uitvoeren van sql statement.
            // Type casten van het generieke return type naar een collectie van Vragen.
            return (List<VraagTag>) db.Query<VraagTag>(sql);
        }

        public void UpdatevraagTag(VraagTag vraagTag)
        {
            // SQL statement update
            string sql = "Update VraagTag set vraagId = @vraagId, tagId = @tagId where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                vraagTag.VraagId,
                vraagTag.TagId
            });
        }

        public void InsertVraagTag(VraagTag vraagTag)
        {
            // SQL statement insert
            string sql = "Insert into VraagTag(vraagId, tagId) values (@vraagId, @tagId)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                vraagTag.VraagId,
                vraagTag.TagId
            });
        }

        public void DeleteVraagTag(VraagTag vraagTag)
        {
            // SQL statement delete
            string sql = "Delete VraagTag where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { vraagTag.Id });
        }
    }
}
