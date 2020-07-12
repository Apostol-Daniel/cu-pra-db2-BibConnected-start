using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// to use SQL and System Configuration
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BibConnected.Lib
{
    public class DBConnector
    {

        public static DataTable ExecuteSelect(string sqlInstructie) 
        {
            string constring = ConfigurationManager.ConnectionStrings["bibliotheek"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sqlInstructie, constring);
            try
            {
                da.Fill(ds);
            }
            catch(Exception fout)
            {
                string foutmelding = fout.Message;
                return null;
            }
            return ds.Tables[0];
        }

    }
}
