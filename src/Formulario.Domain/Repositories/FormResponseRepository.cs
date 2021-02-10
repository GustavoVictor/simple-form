using Formulario.Domain.Entities;
using Formulario.Infra.Data;

namespace Formulario.Domain.Repositories
{
    public class FormResponseRepository : Repository<FormResponse>, IFormResponseRepository
    {
        public FormResponseRepository(Context context) : base(context) 
        {
            
        }
    }
}