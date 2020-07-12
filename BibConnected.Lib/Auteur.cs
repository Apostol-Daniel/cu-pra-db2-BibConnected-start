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
    }
}
