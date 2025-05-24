using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq.Expressions;

namespace AutoDetailingApp.Data.Repository.Interfaces
{
    public interface IRepository<TType, TId>
    {
        //Create
        Task AddAsync(TType item);
		void Add(TType item);

		//Read
		Task<TType?> GetByIdAsync(TId id);
		Task<IEnumerable<TType>> GetAllAsync();
		Task<IEnumerable<TType>> FindAsync(Expression<Func<TType, bool>> predicate);
		Task<bool> ExistsAsync(Expression<Func<TType, bool>> predicate);

		//Update
		Task<bool> UpdateAsync(TType item);
		bool Update(TType item);
    }
}
