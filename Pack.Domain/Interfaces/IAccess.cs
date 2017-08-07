using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pack.Domain.Interfaces
{
    public interface IAccess<T>
    {
        /// <summary>
        /// Return a list into DataTable.
        /// </summary>
        /// <returns></returns>
        DataTable List(T o);
        /// <summary>
        /// Return only a unique object from table in Database.
        /// </summary>
        /// <param name="o">Parameter to find the object.</param>
        /// <returns></returns>
        DataTable ReturnValue(T o);
        /// <summary>
        /// Insert a object in table.
        /// </summary>
        /// <param name="o">Object to into.</param>
        /// <returns></returns>
        int Insert(T o);
        /// <summary>
        /// Update a row in Database.
        /// </summary>
        /// <param name="o">Object will be update.</param>
        /// <returns></returns>
        int Update(T o);
        /// <summary>
        /// Delete a row in table.
        /// </summary>
        /// <param name="o">Object will be deleted.</param>
        /// <returns></returns>
        int Delete(T o);
    }
}
