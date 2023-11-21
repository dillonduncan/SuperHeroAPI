using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace SuperHeroAPI.Controllers
{
    public class TokenValidationnHandler : DelegatingHandler
    {
        /// <summary>
        /// Interceta la peticion y comprueba que el token este valido o este
        /// </summary>
        /// <param name="request"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;
            //comprobamos si en el header no se mande la Authorization
            if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
            {
                return false;
            }
            // si se mandó entonces miramos si se mando el tipo de seguridad Bearer y recuperamos el token sin Bearer
            var bearerToken = authzHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;
            string token;
            // determina si existe el token tipo bearer
            if (!TryRetrieveToken(request, out token))
            {
                statusCode = HttpStatusCode.Unauthorized;
                return base.SendAsync(request, cancellationToken);
            }
            try
            {
                // obtenemos las configuraciond e JWT
                var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
                var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
                var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
                var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));

                SecurityToken securitytoken;
                var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                // Generamos un validador de token y se usa el método que valido el tiempo
                TokenValidationParameters validationparameters = new TokenValidationParameters()
                {
                    ValidAudience = audienceToken,
                    ValidIssuer = issuerToken,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = securityKey
                };
                // Extraer y asignar el token al hilo principal y el usuario actual
                Thread.CurrentPrincipal = tokenHandler.ValidateToken(token, validationparameters, out securitytoken);
                HttpContext.Current.User = tokenHandler.ValidateToken(token, validationparameters, out securitytoken);
                return base.SendAsync(request, cancellationToken);
            }
            catch (SecurityTokenValidationException)
            {
                // en caso de error del token invalido
                statusCode = HttpStatusCode.Unauthorized;
            }
            catch (Exception)
            {
                // en caso de otro error
                statusCode = HttpStatusCode.InternalServerError;
            }
            return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode));
        }
        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }

    }
}