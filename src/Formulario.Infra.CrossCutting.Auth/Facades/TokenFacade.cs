using Formulario.Infra.CrossCutting.Auth.DTO;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Formulario.Infra.CrossCutting.Auth.Facades
{
    public class TokenFacade : ITokenFacade
    {
        private readonly IConfiguration _configuration;

        public TokenFacade(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(dynamic user)
        {
            try
            {
                var tokenConfigurations =
                        _configuration.GetSection("TokenConfigurations")
                            ?.Get<ConfiguracoesTokenDTO>();

                if (tokenConfigurations == null)
                    throw new ArgumentNullException("Não foi possível encontrar as configurações do Token JWT.");

                var _tokenHandler = new JwtSecurityTokenHandler();
                var _key = Encoding.ASCII.GetBytes(tokenConfigurations.Secret);

                var _tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Name)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(tokenConfigurations.ExpiresIn),
                    NotBefore = DateTime.UtcNow,
                    SigningCredentials = new SigningCredentials(
                                                new SymmetricSecurityKey(_key),
                                                    SecurityAlgorithms.HmacSha256Signature)
                };

                var _generatedToken = _tokenHandler.CreateToken(_tokenDescriptor);

                return _tokenHandler.WriteToken(_generatedToken);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
