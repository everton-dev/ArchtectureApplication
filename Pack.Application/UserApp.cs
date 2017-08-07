using Pack.Application.Base;
using Pack.Domain.DAO;
using Pack.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pack.Application
{
    public class UserApp : ApplicationBase<User>
    {
        public override ReturnDefault<int> Delete(User oParameter)
        {
            ReturnDefault<int> oReturn = new ReturnDefault<int>();

            try
            {
                oReturn.Data = new UsuarioDAO().Delete(oParameter);
                oReturn.ReturnType = Entity.Enums.EnumReturnType.Success;

                return oReturn;
            }
            catch (Exception e)
            {
                oReturn.Data = 0;
                oReturn.ReturnType = Entity.Enums.EnumReturnType.Error;
                oReturn.Exception = e;
                oReturn.Message = e.Message;

                return oReturn;
            }
        }

        public override ReturnDefault<int> Insert(User oParameter)
        {
            ReturnDefault<int> oReturn = new ReturnDefault<int>();

            try
            {
                oReturn.Data = new UsuarioDAO().Insert(oParameter);
                oReturn.ReturnType = Entity.Enums.EnumReturnType.Success;

                return oReturn;
            }
            catch (Exception e)
            {
                oReturn.Data = 0;
                oReturn.ReturnType = Entity.Enums.EnumReturnType.Error;
                oReturn.Exception = e;
                oReturn.Message = e.Message;

                return oReturn;
            }
        }

        public override ReturnDefault<List<User>> List(User oParameter)
        {
            ReturnDefault<List<User>> oReturn = new ReturnDefault<List<User>>();

            try
            {
                oReturn.Data = this.ConvertDataTable(new UsuarioDAO().List(oParameter));
                oReturn.ReturnType = Entity.Enums.EnumReturnType.Success;

                return oReturn;
            }
            catch (Exception e)
            {
                oReturn.Data = null;
                oReturn.ReturnType = Entity.Enums.EnumReturnType.Error;
                oReturn.Exception = e;
                oReturn.Message = e.Message;

                return oReturn;
            }
        }

        public override ReturnDefault<List<User>> ReturnValue(User oParameter)
        {
            ReturnDefault<List<User>> oReturn = new ReturnDefault<List<User>>();

            try
            {
                oReturn.Data = this.ConvertDataTable(new UsuarioDAO().ReturnValue(oParameter));
                oReturn.ReturnType = Entity.Enums.EnumReturnType.Success;

                return oReturn;
            }
            catch (Exception e)
            {
                oReturn.Data = null;
                oReturn.ReturnType = Entity.Enums.EnumReturnType.Error;
                oReturn.Exception = e;
                oReturn.Message = e.Message;

                return oReturn;
            }
        }

        public override ReturnDefault<int> Update(User oParameter)
        {
            ReturnDefault<int> oReturn = new ReturnDefault<int>();

            try
            {
                oReturn.Data = new UsuarioDAO().Update(oParameter);
                oReturn.ReturnType = Entity.Enums.EnumReturnType.Success;

                return oReturn;
            }
            catch (Exception e)
            {
                oReturn.Data = 0;
                oReturn.ReturnType = Entity.Enums.EnumReturnType.Error;
                oReturn.Exception = e;
                oReturn.Message = e.Message;

                return oReturn;
            }
        }
    }
}
