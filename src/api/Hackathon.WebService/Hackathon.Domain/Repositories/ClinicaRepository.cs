using Hackathon.Domain.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;

namespace Hackathon.Domain.Repositories
{
    public class ClinicaRepository
    {
        public Clinica Get(DataContext dataContext, string login, string senha)
        {
            var clinica = new Clinica();
            var dataTable = new DataTable();
            var query = new StringBuilder();
            query.Append(" SELECT                 ");
            query.Append(" *                      ");
            query.Append(" FROM clinica           ");
            query.Append(" WHERE                  ");
            query.Append(" usuario = ?usuario AND ");
            query.Append(" senha = ?senha         ");
            var mySqlCommand = new MySqlCommand(query.ToString());

            mySqlCommand.Parameters.AddWithValue("?usuario", login);
            mySqlCommand.Parameters.AddWithValue("?senha", senha);

            dataContext.ExecuteReader(mySqlCommand, dataTable);
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                clinica = new Clinica()
                {
                    Id = Convert.ToInt32(row["clinica_id"]),
                    Nome = row["nome"].ToString(),
                    Telefone = row["telefone"].ToString(),
                    Logradouro = row["logradouro"].ToString(),
                    Numero = row["numero"].ToString(),
                    Bairro = row["bairro"].ToString(),
                    Cep = row["cep"].ToString(),
                    Cidade = row["cidade"].ToString(),
                    Uf = row["uf"].ToString(),
                    Localizacao = row["localizacao"].ToString()
                };
            }
            return clinica;
        }
    }
}
