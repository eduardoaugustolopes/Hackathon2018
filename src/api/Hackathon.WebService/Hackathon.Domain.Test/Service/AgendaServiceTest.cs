using Hackathon.Domain.Entities;
using Hackathon.Domain.Enums;
using Hackathon.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Hackathon.Domain.Test.Service
{
    [TestClass]
    public class AgendaServiceTest
    {
        AgendaService agendaService = new AgendaService();

        [TestMethod, TestCategory("[Agenda] 2. Service Agenda")]
        public void Agenda_Get_Paciente()
        {
            var agenda = agendaService.Get(1);

            Assert.AreEqual(ResponseTypeEnum.Success, agendaService.ResponseService.Type);
        }

        [TestMethod, TestCategory("[Agenda] 1. Service Agenda")]
        public void Agenda_Add_ComSucesso()
        {
            var agenda = new Agenda()
            {
                Clinica = new Clinica()
                {
                    Id = 1
                },
                Medico = new Medico()
                {
                    Id = 2
                },
                Paciente = new Paciente()
                {
                    Id = 1
                },
                DataHoraMarcada = new DateTime(2018, 08, 26, 14, 0, 0),
                TempoEstimado = "00:30:00"
            };

            agendaService.Save(agenda);

            Assert.AreEqual(ResponseTypeEnum.Success, agendaService.ResponseService.Type);
        }

        [TestMethod, TestCategory("[Agenda] 2. Service Agenda")]
        public void Agenda_Update_ComSucesso()
        {
            var agenda = new Agenda()
            {
                Id = 1,
                Clinica = new Clinica()
                {
                    Id = 1
                },
                Medico = new Medico()
                {
                    Id = 1
                },
                Paciente = new Paciente()
                {
                    Id = 1
                },
                DataHoraMarcada = new DateTime(2018, 08, 26, 14, 0, 0),
                TempoEstimado = "01:00:00"
            };

            agendaService.Save(agenda);

            Assert.AreEqual(ResponseTypeEnum.Success, agendaService.ResponseService.Type);
        }

        [TestMethod, TestCategory("[Agenda] 2. Service Agenda")]
        public void Agenda_Confirma_ComSucesso()
        {
            agendaService.Confirma(1);

            Assert.AreEqual(ResponseTypeEnum.Success, agendaService.ResponseService.Type);
        }

        [TestMethod, TestCategory("[Agenda] 2. Service Agenda")]
        public void Agenda_Cancela_ComSucesso()
        {
            agendaService.Cancela(2);

            Assert.AreEqual(ResponseTypeEnum.Success, agendaService.ResponseService.Type);
        }

        [TestMethod, TestCategory("[Agenda] 2. Service Agenda")]
        public void Agenda_Conclui_ComSucesso()
        {
            agendaService.Conclui(3);

            Assert.AreEqual(ResponseTypeEnum.Success, agendaService.ResponseService.Type);
        }
    }
}
