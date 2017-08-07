using Pack.Domain.Enums;
using Pack.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pack.Domain.Factory
{
    public static class DatabaseFactory
    {
        public static IDatabase GetDatabase(EnumDatabaseType sTypeConnection, string sConnectionString)
        {
            IDatabase oReturnDatabase = null;

            switch (sTypeConnection)
            {
                case EnumDatabaseType.SqlServer:
                    oReturnDatabase = new Pack.Domain.Databases.DatabaseSqlServer(sConnectionString);
                    break;
                case EnumDatabaseType.Oracle:
                    oReturnDatabase = new Pack.Domain.Databases.DatabaseOracle(sConnectionString);
                    break;
                case EnumDatabaseType.MySQL:
                    oReturnDatabase = new Pack.Domain.Databases.DatabaseMySQL(sConnectionString);
                    break;
                case EnumDatabaseType.SQLite:
                    oReturnDatabase = new Pack.Domain.Databases.DatabaseSQLite(sConnectionString);
                    break;
                default:
                    oReturnDatabase = null;
                    break;
            }

            return oReturnDatabase;
        }
    }
}
