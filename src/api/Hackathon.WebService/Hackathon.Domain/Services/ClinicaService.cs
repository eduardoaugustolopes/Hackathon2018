using Hackathon.Domain.Entities;
using Hackathon.Domain.Enums;
using Hackathon.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Hackathon.Domain.Services
{
    public class ClinicaService
    {
        public ResponseService ResponseService;
        private DataContext _dataContext;
        private ClinicaRepository _clinicaRepository;

        public ClinicaService()
        {
            _dataContext = new DataContext();
            _clinicaRepository = new ClinicaRepository();
            ResponseService = new ResponseService();
        }

        public Clinica Get(string login, string senha)
        {
            try
            {
                var clinica = new Clinica();

                _dataContext.BeginTransaction();

                clinica = _clinicaRepository.Get(_dataContext, login, senha);

                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Success,
                    Message = "Usuário consultado com sucesso."
                };

                return clinica;
            }
            catch (Exception e)
            {
                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Error,
                    Message = "Houve uma falha ao consultar o usuário."
                };

                return new Clinica();
            }
            finally
            {
                _dataContext.Finally();
            }
        }

        public static int ObtemUsuarioLogadoId(List<System.Security.Claims.Claim> claims)
        {
            var claimUsuarioId = claims.Find(x => x.Type == "ClinicaId");

            if (claimUsuarioId != null)
                return Convert.ToInt32(claimUsuarioId.Value);
            else
                return 0;
        }
    }
}
