﻿using Pack.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pack.Domain.Enums;
using System.Data;
using System.Data.SQLite;

namespace Pack.Domain.Databases
{
    public class DatabaseSQLite : DatabaseBase
    {
        private SQLiteConnection oConnection { get; set; }
        private SQLiteCommand oCommand { get; set; }
        private SQLiteDataAdapter oAdapter { get; set; }

        public DatabaseSQLite(string sConnectionString)
        {
            this.oConnection = new SQLiteConnection(sConnectionString);
            this.oCommand = new SQLiteCommand(string.Empty, oConnection);
        }

        public override bool AddParameter(string parameterName, object value)
        {
            this.oCommand.Parameters.Add(new SQLiteParameter(parameterName, value));

            return true;
        }

        public override void ClearParameters()
        {
            if (this.oCommand != null)
            {
                if (this.oCommand.Parameters != null)
                {
                    this.oCommand.Parameters.Clear();
                }
            }
        }

        public override bool Close()
        {
            if (this.oCommand.Connection.State.Equals(ConnectionState.Open))
            {
                this.oCommand.Connection.Close();
            }

            return true;
        }

        public override int Execute(string sComando, EnumExecutionType execution)
        {
            this.oCommand.CommandText = sComando;
            this.oCommand.CommandType = this.ConvertToCommandType(execution);

            try
            {
                this.Open();
                return this.oCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Close();
            }
        }

        public override DataSet ExecuteToDataSet(string sComando, EnumExecutionType execution)
        {
            this.oCommand.CommandText = sComando;
            this.oCommand.CommandType = this.ConvertToCommandType(execution);

            try
            {
                this.Open();

                this.oAdapter = new SQLiteDataAdapter(this.oCommand);
                this.oDataSetReturn = new DataSet();

                this.oAdapter.Fill(this.oDataSetReturn);

                return this.oDataSetReturn;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Close();
            }
        }

        public override DataTable ExecuteToDataTable(string sComando, EnumExecutionType execution)
        {
            this.oCommand.CommandText = sComando;
            this.oCommand.CommandType = this.ConvertToCommandType(execution);

            try
            {
                this.Open();

                this.oAdapter = new SQLiteDataAdapter(this.oCommand);
                this.oTableReturn = new DataTable();

                this.oAdapter.Fill(this.oTableReturn);

                return this.oTableReturn;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Close();
            }
        }

        public override bool Open()
        {
            if (!this.oCommand.Connection.State.Equals(ConnectionState.Open))
            {
                this.oCommand.Connection.Open();
            }

            return true;
        }
    }
}
