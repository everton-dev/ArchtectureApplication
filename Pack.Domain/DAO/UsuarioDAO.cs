using Pack.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pack.Entity;

namespace Pack.Domain.DAO
{
    public class UsuarioDAO : Access<User>
    {
        public override int Delete(User o)
        {
            oData.AddParameter("id_user", o.Id);

            return oData.Execute("proc_update_users", Enums.EnumExecutionType.StoredProcedure);
        }
        public override int Insert(User o)
        {
            oData.AddParameter("login", o.Login);
            oData.AddParameter("password", o.Password);
            oData.AddParameter("activev", o.Active);

            return oData.Execute("proc_insert_users", Enums.EnumExecutionType.StoredProcedure);
        }
        public override DataTable List(User o)
        {
            if(o != null)
            {
                if (!o.Id.Equals(0))
                    oData.AddParameter("id_user", o.Id);

                if (!string.IsNullOrEmpty(o.Login))
                    oData.AddParameter("login", o.Login);

                if (o.Active.HasValue)
                    oData.AddParameter("active", o.Active.Value);
            }

            return oData.ExecuteToDataTable("proc_list_users", Enums.EnumExecutionType.StoredProcedure);
        }
        public override DataTable ReturnValue(User o)
        {
            if (!o.Id.Equals(0))
                oData.AddParameter("id_user", o.Id);

            if (!string.IsNullOrEmpty(o.Login))
                oData.AddParameter("login", o.Login);

            if (o.Active.HasValue)
                oData.AddParameter("active", o.Active.Value);

            return oData.ExecuteToDataTable("proc_list_users", Enums.EnumExecutionType.StoredProcedure);
        }
        public override int Update(User o)
        {
            oData.AddParameter("id_user", o.Id);
            oData.AddParameter("login", o.Login);
            oData.AddParameter("password", o.Password);
            oData.AddParameter("active", o.Active.Value);

            return oData.Execute("proc_update_users", Enums.EnumExecutionType.StoredProcedure);
        }
    }
}
