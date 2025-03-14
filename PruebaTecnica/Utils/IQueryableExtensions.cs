using PruebaTecnica.Dtos;

namespace PruebaTecnica.Utils
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO paginacionDTO)
        {
            return queryable
                .Skip((paginacionDTO.Page - 1) * paginacionDTO.RecordsPerPage)
                .Take(paginacionDTO.RecordsPerPage);
        }
    }
}
