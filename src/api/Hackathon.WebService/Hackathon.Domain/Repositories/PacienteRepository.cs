using Hackathon.Domain.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;

namespace Hackathon.Domain.Repositories
{
    public class PacienteRepository
    {
        public Paciente Get(DataContext dataContext, string login, string senha)
        {
            var paciente = new Paciente();
            var dataTable = new DataTable();
            var query = new StringBuilder();
            query.Append(" SELECT             ");
            query.Append(" *                  ");
            query.Append(" FROM paciente      ");
            query.Append(" WHERE              ");
            query.Append(" cpf = ?login AND   ");
            query.Append(" senha = ?senha     ");
            var mySqlCommand = new MySqlCommand(query.ToString());

            mySqlCommand.Parameters.AddWithValue("?login", login);
            mySqlCommand.Parameters.AddWithValue("?senha", senha);

            dataContext.ExecuteReader(mySqlCommand, dataTable);
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                paciente = new Paciente()
                {
                    Id = Convert.ToInt32(row["paciente_id"]),
                    Cpf = row["cpf"].ToString(),
                    Nome = row["nome"].ToString(),
                    Telefone = row["telefone"].ToString(),
                    Logradouro = row["logradouro"].ToString(),
                    Numero = row["numero"].ToString(),
                    Bairro = row["bairro"].ToString(),
                    Cep = row["cep"].ToString(),
                    Cidade = row["cidade"].ToString(),
                    Uf = row["uf"].ToString(),
                    Localizacao = row["localizacao"].ToString(),
                    DataNascimento = Convert.ToDateTime(row["data_nascimento"])
                };
            }
            return paciente;
        }
    }
}
