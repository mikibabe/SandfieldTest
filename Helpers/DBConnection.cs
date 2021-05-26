using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SandfieldTest.Helpers
{
    public class DBConnection
    {
        public static SqlConnection GetDBConnection(string connectionstring)
        {
            return new SqlConnection(connectionstring);
        }

    }
}
