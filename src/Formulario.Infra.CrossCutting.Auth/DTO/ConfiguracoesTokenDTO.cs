namespace Formulario.Infra.CrossCutting.Auth.DTO
{
    public class ConfiguracoesTokenDTO
    {
        public string Secret { get; set; }

        public double ExpiresIn { get; set; }
    }
}
