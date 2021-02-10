using Formulario.Domain.ViewModels.Form;

namespace Formulario.Domain.Interfaces.Identities
{
    public interface IForm
    {
         dynamic Create(FormViewModel user);

         dynamic Update(FormViewModel user);
    }
}