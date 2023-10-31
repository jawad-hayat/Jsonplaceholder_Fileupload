using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public abstract class DbConnectionDapper
    {
        private readonly IConfiguration _config;

        public DbConnectionDapper(IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection OpenConnection()
        {
            return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        }
    }
}
