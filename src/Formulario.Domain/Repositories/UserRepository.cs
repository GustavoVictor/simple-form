using Formulario.Domain.Entities;
using Formulario.Infra.Data;

namespace Formulario.Domain.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
            
        }
    }
}