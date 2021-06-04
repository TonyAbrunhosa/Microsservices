using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ConnectionNpgSql
{
    public class NpgSqlConn
    {
        public string StringConnection { get; set; }
        private NpgsqlConnection npgsqlConnection { get; set; }

        public NpgsqlConnection GetConnection()
        {
            npgsqlConnection = new NpgsqlConnection(StringConnection);
            return npgsqlConnection;
        }
        public void Dipose()
        {
            npgsqlConnection.Dispose();
        }
    }
}
