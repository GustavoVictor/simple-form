using System.Linq;

namespace Formulario.Domain.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Pagination<T>(this IQueryable<T> list, int page, int itensPerPage)
        {
            return list.Skip(page * itensPerPage)
                       .Take(itensPerPage);
        }
    }
}
