using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using ApiJwtEFInMemory.AuthToken;
using ApiJwtEFInMemory.DDD.Domain.Entities;
using ApiJwtEFInMemory.DDD.Domain.Interfaces.Services;
using ApiJwtEFInMemory.DDD.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiJwtEFInMemory.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        public object Post(
            [FromBody] Usuario usuario,
            [FromServices]IUsuarioService usrService,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)
        {
            bool credenciaisValidas = false;
            if (usuario != null && !String.IsNullOrWhiteSpace(usuario.ID))
            {
                var usuarioBase = usrService.GetById(usuario.ID);
                credenciaisValidas = (usuarioBase != null && usuarioBase.Equals(usuario));
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.ID, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.ID)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }
    }
}