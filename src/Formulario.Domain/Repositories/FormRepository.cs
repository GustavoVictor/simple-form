using Formulario.Domain.Entities;
using Formulario.Infra.Data;

namespace Formulario.Domain.Repositories
{
    public class FormRepository : Repository<Form>, IFormRepository
    {
        public FormRepository(Context context) : base(context) 
        {
            
        }
    }
}