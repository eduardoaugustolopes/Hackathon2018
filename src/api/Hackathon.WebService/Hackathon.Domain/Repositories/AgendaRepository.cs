using Hackathon.Domain.Entities;
using Hackathon.Domain.Enums;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Hackathon.Domain.Repositories
{
    public class AgendaRepository
    {
        public void Add(DataContext dataContext, Agenda agenda)
        {
            var query = new StringBuilder();

            query.Append(" INSERT INTO agenda       ");
            query.Append(" (                        ");
            query.Append(" clinica_id,              ");
            query.Append(" medico_id,               ");
            query.Append(" paciente_id,             ");
            query.Append(" data_hora_marcado,       ");
            query.Append(" data_hora_inicio,        ");
            query.Append(" data_hora_concluido,     ");
            query.Append(" tempo_estimado,          ");
            query.Append(" status                   ");
            query.Append(" )                        ");
            query.Append(" VALUES                   ");
            query.Append(" (                        ");
            query.Append(" ?clinica_id,             ");
            query.Append(" ?medico_id,              ");
            query.Append(" ?paciente_id,            ");
            query.Append(" ?data_hora_marcado,      ");
            query.Append(" ?data_hora_inicio,       ");
            query.Append(" ?data_hora_concluido,    ");
            query.Append(" ?tempo_estimado,         ");
            query.Append(" ?status                  ");
            query.Append(" );                       ");
            query.Append(" SELECT LAST_INSERT_ID(); ");
            var mySqlCommand = new MySqlCommand(query.ToString());
            mySqlCommand.Parameters.AddWithValue("?clinica_id", agenda.Clinica.Id);
            mySqlCommand.Parameters.AddWithValue("?medico_id", agenda.Medico.Id);
            mySqlCommand.Parameters.AddWithValue("?paciente_id", agenda.Paciente.Id);
            mySqlCommand.Parameters.AddWithValue("?data_hora_marcado", agenda.DataHoraMarcada);
            mySqlCommand.Parameters.AddWithValue("?data_hora_inicio", agenda.DataHoraInicio);
            mySqlCommand.Parameters.AddWithValue("?data_hora_concluido", agenda.DataHoraConcluido);
            mySqlCommand.Parameters.AddWithValue("?tempo_estimado", agenda.TempoEstimado);
            mySqlCommand.Parameters.AddWithValue("?status", agenda.Status);

            agenda.Id = Convert.ToInt32(dataContext.ExecuteScalar(mySqlCommand));
        }

        public void Update(DataContext dataContext, Agenda agenda)
        {
            var query = new StringBuilder();

            query.Append(" UPDATE agenda                               ");
            query.Append(" SET                                         ");
            query.Append(" clinica_id = ?clinica_id,                   ");
            query.Append(" medico_id = ?medico_id,                     ");
            query.Append(" paciente_id = ?paciente_id,                 ");
            query.Append(" data_hora_marcado = ?data_hora_marcado,     ");
            query.Append(" data_hora_inicio = ?data_hora_inicio,       ");
            query.Append(" tempo_estimado = ?tempo_estimado,           ");
            query.Append(" status = ?status                            ");
            query.Append(" WHERE                                       ");
            query.Append(" agenda_id = ?agenda_id                      ");
            var mySqlCommand = new MySqlCommand(query.ToString());
            mySqlCommand.Parameters.AddWithValue("?clinica_id", agenda.Clinica.Id);
            mySqlCommand.Parameters.AddWithValue("?medico_id", agenda.Medico.Id);
            mySqlCommand.Parameters.AddWithValue("?paciente_id", agenda.Paciente.Id);
            mySqlCommand.Parameters.AddWithValue("?data_hora_marcado", agenda.DataHoraMarcada);
            mySqlCommand.Parameters.AddWithValue("?data_hora_inicio", agenda.DataHoraInicio);
            mySqlCommand.Parameters.AddWithValue("?data_hora_concluido", agenda.DataHoraConcluido);
            mySqlCommand.Parameters.AddWithValue("?tempo_estimado", agenda.TempoEstimado);
            mySqlCommand.Parameters.AddWithValue("?status", agenda.Status);
            mySqlCommand.Parameters.AddWithValue("?agenda_id", agenda.Id);
            dataContext.ExecuteCommand(mySqlCommand);
        }

        public void Confirma(DataContext dataContext, int agendaId)
        {
            var query = new StringBuilder();

            query.Append(" UPDATE agenda                               ");
            query.Append(" SET                                         ");
            query.Append(" status = ?status                            ");
            query.Append(" WHERE                                       ");
            query.Append(" agenda_id = ?agenda_id                      ");
            var mySqlCommand = new MySqlCommand(query.ToString());
            mySqlCommand.Parameters.AddWithValue("?status", StatusEnum.Confirmado);
            mySqlCommand.Parameters.AddWithValue("?agenda_id", agendaId);
            dataContext.ExecuteCommand(mySqlCommand);
        }

        public void Inicia(DataContext dataContext, int agendaId)
        {
            var query = new StringBuilder();

            query.Append(" UPDATE agenda                               ");
            query.Append(" SET                                         ");
            query.Append(" data_hora_inicio = ?data_hora_inicio,       ");
            query.Append(" status = ?status                            ");
            query.Append(" WHERE                                       ");
            query.Append(" agenda_id = ?agenda_id                      ");
            var mySqlCommand = new MySqlCommand(query.ToString());
            mySqlCommand.Parameters.AddWithValue("?data_hora_inicio", DateTime.Now);
            mySqlCommand.Parameters.AddWithValue("?status", StatusEnum.Iniciado);
            mySqlCommand.Parameters.AddWithValue("?agenda_id", agendaId);
            dataContext.ExecuteCommand(mySqlCommand);
        }

        public void Cancela(DataContext dataContext, int agendaId)
        {
            var query = new StringBuilder();

            query.Append(" UPDATE agenda                               ");
            query.Append(" SET                                         ");
            query.Append(" status = ?status                            ");
            query.Append(" WHERE                                       ");
            query.Append(" agenda_id = ?agenda_id                      ");
            var mySqlCommand = new MySqlCommand(query.ToString());
            mySqlCommand.Parameters.AddWithValue("?status", StatusEnum.Cancelado);
            mySqlCommand.Parameters.AddWithValue("?agenda_id", agendaId);
            dataContext.ExecuteCommand(mySqlCommand);
        }

        public void Conclui(DataContext dataContext, int agendaId)
        {
            var query = new StringBuilder();

            query.Append(" UPDATE agenda                               ");
            query.Append(" SET                                         ");
            query.Append(" data_hora_concluido = ?data_hora_concluido, ");
            query.Append(" status = ?status                            ");
            query.Append(" WHERE                                       ");
            query.Append(" agenda_id = ?agenda_id                      ");
            var mySqlCommand = new MySqlCommand(query.ToString());
            mySqlCommand.Parameters.AddWithValue("?data_hora_concluido", DateTime.Now);
            mySqlCommand.Parameters.AddWithValue("?status", StatusEnum.Concluido);
            mySqlCommand.Parameters.AddWithValue("?agenda_id", agendaId);
            dataContext.ExecuteCommand(mySqlCommand);
        }

        public List<Agenda> Get(DataContext dataContext, int pacienteId)
        {
            var agendas = new List<Agenda>();
            var dataTable = new DataTable();
            var query = new StringBuilder();
            query.Append(" SELECT                        ");
            query.Append(" a.agenda_id,                  ");
            query.Append(" c.clinica_id,                 ");
            query.Append(" c.nome as nome_clinica,       ");
            query.Append(" c.logradouro,                 ");
            query.Append(" c.numero,                     ");
            query.Append(" c.complemento,                ");
            query.Append(" m.medico_id,                  ");
            query.Append(" m.nome as nome_medico,        ");
            query.Append(" p.paciente_id,                ");
            query.Append(" p.nome as nome_paciente,      ");
            query.Append(" a.data_hora_marcado,          ");
            query.Append(" a.data_hora_inicio,           ");
            query.Append(" a.data_hora_concluido,        ");
            query.Append(" a.tempo_estimado,             ");
            query.Append(" a.status                      ");
            query.Append(" FROM agenda a                 ");
            query.Append(" LEFT JOIN                     ");
            query.Append(" clinica c                     ");
            query.Append(" ON                            ");
            query.Append(" a.clinica_id = c.clinica_id   ");
            query.Append(" LEFT JOIN                     ");
            query.Append(" medico m                      ");
            query.Append(" ON                            ");
            query.Append(" a.medico_id = m.medico_id     ");
            query.Append(" LEFT JOIN                     ");
            query.Append(" paciente p                    ");
            query.Append(" ON                            ");
            query.Append(" a.paciente_id = p.paciente_id ");
            query.Append(" WHERE                         ");
            query.Append(" a.paciente_id = ?paciente_id  ");
            query.Append(" AND                           ");
            query.Append(" status != ?concluido          ");
            query.Append(" AND                           ");
            query.Append(" status != ?cancelado          ");
            var mySqlCommand = new MySqlCommand(query.ToString());
            mySqlCommand.Parameters.AddWithValue("?paciente_id", pacienteId);
            mySqlCommand.Parameters.AddWithValue("?concluido", StatusEnum.Concluido);
            mySqlCommand.Parameters.AddWithValue("?cancelado", StatusEnum.Cancelado);

            dataContext.ExecuteReader(mySqlCommand, dataTable);

            for (var i = 0; dataTable.Rows.Count > i; i++)
            {
                var row = dataTable.Rows[i];

                agendas.Add(new Agenda()
                {
                    Id = Convert.ToInt32(row["agenda_id"]),
                    Clinica = new Clinica()
                    {
                        Id = Convert.ToInt32(row["clinica_id"]),
                        Nome = row["nome_clinica"].ToString(),
                        Logradouro = row["logradouro"].ToString(),
                        Numero = row["numero"].ToString(),
                        Complemento = row["complemento"].ToString()
                    },
                    Medico = new Medico()
                    {
                        Id = Convert.ToInt32(row["medico_id"]),
                        Nome = row["nome_medico"].ToString()
                    },
                    Paciente = new Paciente()
                    {
                        Id = Convert.ToInt32(row["paciente_id"]),
                        Nome = row["nome_paciente"].ToString()
                    },
                    DataHoraMarcada = Convert.ToDateTime(row["data_hora_marcado"]),
                    DataHoraInicio = Convert.ToDateTime(row["data_hora_inicio"]),
                    DataHoraConcluido = Convert.ToDateTime(row["data_hora_concluido"]),
                    Status = (StatusEnum) Convert.ToInt32(row["status"]),
                    TempoEstimado = row["tempo_estimado"].ToString()
                });
            }
            return agendas;
        }
    }
}
