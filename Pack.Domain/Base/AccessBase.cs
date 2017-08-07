using Pack.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pack.Domain.Factory;
using Pack.Infrastructure.Utils;
using Pack.Domain.Enums;

namespace Pack.Domain.Base
{
    public abstract class Access<T> : IAccess<T>
    {

        protected const string SELECTED_DATABASE_TYPE = "SelectedDatabaseType";
        protected const string CONNECTIONSTRING_DATABASE = "ConnectionStringDatabase";

        protected IDatabase oData { get; set; }

        public Access()
        {
            EnumDatabaseType enumSelectedDatabaseType;
            string sValueSelectedDatabaseType = string.Empty;
            string sKeyConnectionString = string.Empty;
            string sConnectionString = string.Empty;

            sValueSelectedDatabaseType = Tools.GetConfig(SELECTED_DATABASE_TYPE);
            sKeyConnectionString = string.Format("{0}_{1}", CONNECTIONSTRING_DATABASE, sValueSelectedDatabaseType);

            enumSelectedDatabaseType = (EnumDatabaseType) Enum.Parse(typeof(EnumDatabaseType), sValueSelectedDatabaseType);
            sConnectionString = Tools.GetConfig(sKeyConnectionString);

            this.oData = DatabaseFactory.GetDatabase(enumSelectedDatabaseType, sConnectionString);
        }

        public abstract int Delete(T o);

        public abstract int Insert(T o);

        public abstract DataTable List(T o);

        public abstract DataTable ReturnValue(T o);

        public abstract int Update(T o);
    }
}
