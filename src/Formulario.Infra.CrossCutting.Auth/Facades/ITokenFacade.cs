namespace Formulario.Infra.CrossCutting.Auth.Facades
{
    public interface ITokenFacade
    {
        string GenerateToken(dynamic user);
    }
}
