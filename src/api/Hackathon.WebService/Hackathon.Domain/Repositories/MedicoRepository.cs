using Hackathon.Domain.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;

namespace Hackathon.Domain.Repositories
{
    public class MedicoRepository
    {
        public Medico Get(DataContext dataContext, string crm)
        {
            var medico = new Medico();
            var dataTable = new DataTable();
            var query = new StringBuilder();
            query.Append(" SELECT       ");
            query.Append(" *            ");
            query.Append(" FROM medico  ");
            query.Append(" WHERE        ");
            query.Append(" crm = ?crm   ");
            var mySqlCommand = new MySqlCommand(query.ToString());

            mySqlCommand.Parameters.AddWithValue("?crm", crm);

            dataContext.ExecuteReader(mySqlCommand, dataTable);
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                medico = new Medico()
                {
                    Id = Convert.ToInt32(row["medico_id"]),
                    Crm = row["crm"].ToString(),
                    Nome = row["nome"].ToString(),
                    Telefone = row["telefone"].ToString()
                };
            }
            return medico;
        }
    }
}
