using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace Hackathon.Domain.Repositories
{
    public class DataContext
    {
        private MySqlConnection MySqlConnection { get; set; }
        private MySqlTransaction MySqlTransaction { get; set; }

        public void BeginTransaction()
        {
            MySqlConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            MySqlConnection.Open();
            MySqlTransaction = MySqlConnection.BeginTransaction();
        }

        public void Commit()
        {
            MySqlTransaction.Commit();
        }

        public void Rollback()
        {
            MySqlTransaction.Rollback();
        }

        public void Finally()
        {
            if (MySqlTransaction != null)
            {
                MySqlTransaction.Dispose();
            }
            if (MySqlConnection != null)
            {
                MySqlConnection.Close();
                MySqlConnection.Dispose();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public object ExecuteScalar(dynamic command)
        {
            var mySqlCommand = (command as MySqlCommand);
            mySqlCommand.Connection = MySqlConnection;
            mySqlCommand.Transaction = MySqlTransaction;
            return mySqlCommand.ExecuteScalar();
        }

        public void ExecuteCommand(dynamic command)
        {
            var mySqlCommand = (command as MySqlCommand);
            mySqlCommand.Connection = MySqlConnection;
            mySqlCommand.Transaction = MySqlTransaction;
            mySqlCommand.ExecuteNonQuery();
        }

        public void ExecuteReader(dynamic command, dynamic dataTable)
        {
            var mySqlCommand = (command as MySqlCommand);
            mySqlCommand.Connection = MySqlConnection;
            mySqlCommand.Transaction = MySqlTransaction;
            (dataTable as DataTable).Load(mySqlCommand.ExecuteReader());
        }
    }
}
