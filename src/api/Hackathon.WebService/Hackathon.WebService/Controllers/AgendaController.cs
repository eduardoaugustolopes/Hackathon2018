﻿using Hackathon.Domain.Entities;
using Hackathon.Domain.Enums;
using Hackathon.Domain.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Hackathon.WebService.Controllers
{
    [Authorize]
    [RoutePrefix("Api/Agenda")]
    public class AgendaController : ApiController
    {
        [HttpGet]
        [Route("GetAgendaPaciente")]
        public HttpResponseMessage GetAgendaPaciente()
        {
            try
            {
                var agendaService = new AgendaService();

                var pacienteLogadoId = PacienteService.ObtemUsuarioLogadoId((User.Identity as ClaimsIdentity).Claims.ToList());
                var agenda = agendaService.Get(pacienteLogadoId);

                if (agendaService.ResponseService.Type.Equals("Error"))
                {
                    return Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest, agendaService.ResponseService.Message);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        Agenda = agenda,
                        Message = agendaService.ResponseService.Message,
                        Type = agendaService.ResponseService.Type
                    });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, "Erro ao recuperar a agenda.");
            }
        }

        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Save(Agenda agenda)
        {
            try
            {
                var agendaService = new AgendaService();

                agenda.Paciente = new Paciente() { Id = PacienteService.ObtemUsuarioLogadoId((User.Identity as ClaimsIdentity).Claims.ToList()) };

                agendaService.Save(agenda);

                if (agendaService.ResponseService.Type == ResponseTypeEnum.Error)
                {
                    return Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest, agendaService.ResponseService.Message);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        Message = agendaService.ResponseService.Message,
                        Type = agendaService.ResponseService.Type.ToString(),
                        Fields = agendaService.ResponseService.FieldsInvalids
                    });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro ao cadastrar.");
            }
        }

        [HttpPost]
        [Route("Confirma")]
        public HttpResponseMessage Confirma(int agendaId)
        {
            try
            {
                var agendaService = new AgendaService();

                agendaService.Confirma(agendaId);

                if (agendaService.ResponseService.Type == ResponseTypeEnum.Error)
                {
                    return Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest, agendaService.ResponseService.Message);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        Message = agendaService.ResponseService.Message,
                        Type = agendaService.ResponseService.Type.ToString(),
                        Fields = agendaService.ResponseService.FieldsInvalids
                    });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro ao confirmar.");
            }
        }

        [HttpPost]
        [Route("Inicia")]
        public HttpResponseMessage Inicia(int agendaId)
        {
            try
            {
                var agendaService = new AgendaService();

                agendaService.Inicia(agendaId);

                if (agendaService.ResponseService.Type == ResponseTypeEnum.Error)
                {
                    return Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest, agendaService.ResponseService.Message);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        Message = agendaService.ResponseService.Message,
                        Type = agendaService.ResponseService.Type.ToString(),
                        Fields = agendaService.ResponseService.FieldsInvalids
                    });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro ao iniciar.");
            }
        }

        [HttpPost]
        [Route("Cancela")]
        public HttpResponseMessage Cancela(int agendaId)
        {
            try
            {
                var agendaService = new AgendaService();

                agendaService.Cancela(agendaId);

                if (agendaService.ResponseService.Type == ResponseTypeEnum.Error)
                {
                    return Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest, agendaService.ResponseService.Message);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        Message = agendaService.ResponseService.Message,
                        Type = agendaService.ResponseService.Type.ToString(),
                        Fields = agendaService.ResponseService.FieldsInvalids
                    });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro ao confirmar.");
            }
        }

        [HttpPost]
        [Route("Conclui")]
        public HttpResponseMessage Conclui(int agendaId)
        {
            try
            {
                var agendaService = new AgendaService();

                agendaService.Conclui(agendaId);

                if (agendaService.ResponseService.Type == ResponseTypeEnum.Error)
                {
                    return Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest, agendaService.ResponseService.Message);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        Message = agendaService.ResponseService.Message,
                        Type = agendaService.ResponseService.Type.ToString(),
                        Fields = agendaService.ResponseService.FieldsInvalids
                    });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro ao confirmar.");
            }
        }
    }
}
