using Hackathon.Domain.Entities;
using Hackathon.Domain.Enums;
using Hackathon.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Hackathon.Domain.Services
{
    public class PacienteService
    {
        public ResponseService ResponseService;
        private DataContext _dataContext;
        private PacienteRepository _pacienteRepository;

        public PacienteService()
        {
            _dataContext = new DataContext();
            _pacienteRepository = new PacienteRepository();
            ResponseService = new ResponseService();
        }

        public Paciente Get(string login, string senha)
        {
            try
            {
                var paciente = new Paciente();

                _dataContext.BeginTransaction();

                paciente = _pacienteRepository.Get(_dataContext, login, senha);

                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Success,
                    Message = "Usuário consultado com sucesso."
                };

                return paciente;
            }
            catch (Exception e)
            {
                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Error,
                    Message = "Houve uma falha ao consultar o usuário."
                };

                return new Paciente();
            }
            finally
            {
                _dataContext.Finally();
            }
        }

        public static int ObtemUsuarioLogadoId(List<System.Security.Claims.Claim> claims)
        {
            var claimUsuarioId = claims.Find(x => x.Type == "PacienteId");

            if (claimUsuarioId != null)
                return Convert.ToInt32(claimUsuarioId.Value);
            else
                return 0;
        }
    }
}
