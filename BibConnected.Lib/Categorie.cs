using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BibConnected.Lib
{
    public class Categorie
    {
        public static string ZoekCategorie(int cat_id)
        {
            string sql;
            sql = "select * from categorie where cat_id = " + cat_id.ToString();
            DataTable dtCategorie = DBConnector.ExecuteSelect(sql);
            if (dtCategorie.Rows.Count > 0)
                return dtCategorie.Rows[0]["categorie"].ToString();
            else
                return null;
        }
    }
}
