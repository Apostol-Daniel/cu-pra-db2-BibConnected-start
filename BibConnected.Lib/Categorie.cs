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

        public static bool VoegCategorieToe(string niueweCategorie)
        {
            string sql;
            niueweCategorie = Helper.HandleQuotes(niueweCategorie);
            if (niueweCategorie.Length == 0)
                return false;
            if (niueweCategorie.Length > 30)
                niueweCategorie = niueweCategorie.Substring(0, 30);

            sql = "select max(cat_id) from categorie";
            int nieuwecat_id = int.Parse(DBConnector.ExecuteScalaire(sql) + 1);

            sql = $"insert into categorie (cat_id, categorie) values ({nieuwecat_id},'{niueweCategorie}')";
                return DBConnector.ExecuteCommand(sql);
        }
    }
}
