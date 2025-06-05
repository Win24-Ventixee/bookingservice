using System.Linq.Expressions;
using Presentation.Data.Entities;
using Presentation.Models;

namespace Presentation.Data.Repositories
{
  public interface IBookingRepository : IBaseRepository<BookingEntity>
  {
    Task<RepositoryResult<IEnumerable<BookingEntity>>> GetAllAsync();
    Task<RepositoryResult<BookingEntity?>> GetAsync(Expression<Func<BookingEntity, bool>> expression);
  }
}