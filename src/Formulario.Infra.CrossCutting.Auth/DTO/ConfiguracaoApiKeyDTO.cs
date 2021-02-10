using System;

namespace Formulario.Infra.CrossCutting.Auth.DTO
{
    public class ConfiguracaoApiKeyDTO
    {
        public string Id { get; set; }

        public string SistemaId { get; set; }

        public string UsuarioId { get; set; }

        public string ApiKey { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}
