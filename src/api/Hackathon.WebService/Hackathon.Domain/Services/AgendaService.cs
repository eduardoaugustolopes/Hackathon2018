using Hackathon.Domain.Entities;
using Hackathon.Domain.Enums;
using Hackathon.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Hackathon.Domain.Services
{
    public class AgendaService
    {
        public ResponseService ResponseService;
        private DataContext _dataContext;
        private AgendaRepository _agendaRepository;

        public AgendaService()
        {
            _dataContext = new DataContext();
            _agendaRepository = new AgendaRepository();
            ResponseService = new ResponseService();
        }

        public List<Agenda> Get(int pacienteId)
        {
            try
            {
                var agendas = new List<Agenda>();

                _dataContext.BeginTransaction();

                agendas = _agendaRepository.Get(_dataContext, pacienteId);

                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Success,
                    Message = "Agenda consultada com sucesso."
                };

                return agendas;
            }
            catch (Exception e)
            {
                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Error,
                    Message = "Houve uma falha ao consultar a agenda."
                };

                return new List<Agenda>();
            }
            finally
            {
                _dataContext.Finally();
            }
        }

        public void Save(Agenda agenda)
        {
            try
            {
                _dataContext.BeginTransaction();

                if (ValidaAgenda(agenda))
                {
                    if (agenda.Id > 0)
                    {
                        _agendaRepository.Update(_dataContext, agenda);
                    }
                    else
                    {
                        _agendaRepository.Add(_dataContext, agenda);
                    }

                    _dataContext.Commit();

                    ResponseService = new ResponseService()
                    {
                        Type = ResponseTypeEnum.Success,
                        Message = "Agenda cadastrada com sucesso."
                    };
                }

            }
            catch (Exception e)
            {
                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Error,
                    Message = "Houve uma falha ao cadastrar a agenda."
                };
                _dataContext.Rollback();
            }
            finally
            {
                _dataContext.Finally();
            }
        }

        public void Confirma(int agendaId)
        {
            try
            {
                _dataContext.BeginTransaction();

                _agendaRepository.Confirma(_dataContext, agendaId);

                _dataContext.Commit();

                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Success,
                    Message = "Confirmado com sucesso."
                };
            }
            catch (Exception e)
            {
                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Error,
                    Message = "Houve uma falha ao confirmar."
                };
                _dataContext.Rollback();
            }
            finally
            {
                _dataContext.Finally();
            }
        }

        public void Inicia(int agendaId)
        {
            try
            {
                _dataContext.BeginTransaction();

                _agendaRepository.Inicia(_dataContext, agendaId);

                _dataContext.Commit();

                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Success,
                    Message = "Iniciado com sucesso."
                };
            }
            catch (Exception e)
            {
                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Error,
                    Message = "Houve uma falha ao iniciar."
                };
                _dataContext.Rollback();
            }
            finally
            {
                _dataContext.Finally();
            }
        }

        public void Cancela(int agendaId)
        {
            try
            {
                _dataContext.BeginTransaction();

                _agendaRepository.Cancela(_dataContext, agendaId);

                _dataContext.Commit();

                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Success,
                    Message = "Cancelado com sucesso."
                };
            }
            catch (Exception e)
            {
                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Error,
                    Message = "Houve uma falha ao cancelar."
                };
                _dataContext.Rollback();
            }
            finally
            {
                _dataContext.Finally();
            }
        }

        public void Conclui(int agendaId)
        {
            try
            {
                _dataContext.BeginTransaction();

                _agendaRepository.Conclui(_dataContext, agendaId);

                _dataContext.Commit();

                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Success,
                    Message = "Concluído com sucesso."
                };
            }
            catch (Exception e)
            {
                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Error,
                    Message = "Houve uma falha ao concluir."
                };
                _dataContext.Rollback();
            }
            finally
            {
                _dataContext.Finally();
            }
        }

        public bool ValidaAgenda(Agenda agenda)
        {
            ResponseService = new ResponseService();

            if (agenda.Clinica == null || agenda.Clinica.Id == 0)
            {
                ResponseService.FieldsInvalids.Add("Clinica");
                ResponseService.Message += "Não foi possível identificar a clínica.";
            }
            if (agenda.Medico == null || agenda.Medico.Id == 0)
            {
                ResponseService.FieldsInvalids.Add("Medico");
                ResponseService.Message += "Não foi possível identificar o médico.";
            }
            if (agenda.Paciente == null || agenda.Paciente.Id == 0)
            {
                ResponseService.FieldsInvalids.Add("Paciente");
                ResponseService.Message += "Não foi possível identificar o paciente.";
            }
            if (agenda.DataHoraMarcada < DateTime.Now)
            {
                ResponseService.FieldsInvalids.Add("DataHoraMarcada");
                ResponseService.Message += "A data marcada deve ser maior que a atual.";
            }
            if (string.IsNullOrEmpty(agenda.TempoEstimado))
            {
                ResponseService.FieldsInvalids.Add("TempoEstimado");
                ResponseService.Message += "O tempo estimado não foi informado.";
            }

            if (ResponseService.FieldsInvalids.Count > 0)
            {
                ResponseService.Message += "Informe os dados corretamente.";
            }

            ResponseService.Type =
                string.IsNullOrEmpty(ResponseService.Message) ?
                    ResponseTypeEnum.Success :
                    ResponseTypeEnum.Warning;
            return ResponseService.Type == ResponseTypeEnum.Success;
        }
    }
}
