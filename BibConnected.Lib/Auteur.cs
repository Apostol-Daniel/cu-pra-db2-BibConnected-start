using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace BibConnected.Lib
{
    public class Auteur
    {
        public static DataTable GeefAlleAuteurs()
        {
            string sql;
            sql = "select * from auteur";
            return DBConnector.ExecuteSelect(sql);
        }

        public static DataTable GeefAlleAuteurs(string veldNaam, Enumeraties.SortOrder volgorder)
        {
            string sql;
            sql = "select * from auteur";
            sql += "order by" + veldNaam + " " + volgorder.ToString();
            return DBConnector.ExecuteSelect(sql);
        }
    } 
}
