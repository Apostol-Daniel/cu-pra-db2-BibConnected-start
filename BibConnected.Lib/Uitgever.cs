using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BibConnected.Lib
{
    public class Uitgever
    {
        public static DataTable GeefAlleUitgevers()
        {
            string sp = "pra_UitgeverSelectAllAsc";
            return DBConnector.ExecuteSPWithDataTable(sp, null);
        }
    }
}
