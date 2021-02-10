using Formulario.Domain.ViewModels.User;

namespace Formulario.Domain.Interfaces.Identities
{
    public interface IUser
    {
         dynamic Auth(AuthViewModel auth);

         dynamic Create(CreateViewModel user);
    }
}