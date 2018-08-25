using Hackathon.Domain.Services;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Hackathon.WebService.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private PacienteService _pacienteService = new PacienteService();
        private ClinicaService _clinicaService = new ClinicaService();

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            try
            {
                var user = context.UserName;

                if (user.Length == 11)
                {
                    var usuarioVM = _pacienteService.Get(context.UserName, context.Password);
                    if (usuarioVM.Id != 0)
                    {
                        var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                        var claims = new List<string>();
                        identity.AddClaim(new Claim("PacienteId", usuarioVM.Id.ToString()));
                        //identity.AddClaim(new Claim("Administrador", usuarioVM.UsuarioAcessos.Any(x => x.AdministradorSistema).ToString()));
                        Thread.CurrentPrincipal = new GenericPrincipal(identity, claims.ToArray());
                        context.Validated(identity);
                    }
                    else
                    {
                        context.SetError("invalid_grant", _pacienteService.ResponseService.Message);
                        return;
                    }
                }
                else
                {
                    var usuarioVM = _clinicaService.Get(context.UserName, context.Password);
                    if (usuarioVM.Id != 0)
                    {
                        var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                        var claims = new List<string>();
                        identity.AddClaim(new Claim("ClinicaId", usuarioVM.Id.ToString()));
                        //identity.AddClaim(new Claim("Administrador", usuarioVM.UsuarioAcessos.Any(x => x.AdministradorSistema).ToString()));
                        Thread.CurrentPrincipal = new GenericPrincipal(identity, claims.ToArray());
                        context.Validated(identity);
                    }
                    else
                    {
                        context.SetError("invalid_grant", _pacienteService.ResponseService.Message);
                        return;
                    }
                }
                
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", "Falha ao autenticar");
            }
        }
    }
}