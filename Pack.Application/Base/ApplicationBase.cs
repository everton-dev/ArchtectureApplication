using Pack.Entity;
using Pack.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pack.Application.Base
{
    public abstract class ApplicationBase<T>
    {
        protected List<T> ConvertDataTable(DataTable oTable)
        {
            return Tools.ConvertDataTableToList<T>(oTable) as List<T>;
        }
        public abstract ReturnDefault<List<T>> List(T oParameter);
        public abstract ReturnDefault<List<T>> ReturnValue(T oParameter);
        public abstract ReturnDefault<int> Insert(T oParameter);
        public abstract ReturnDefault<int> Update(T oParameter);
        public abstract ReturnDefault<int> Delete(T oParameter);
    }
}
