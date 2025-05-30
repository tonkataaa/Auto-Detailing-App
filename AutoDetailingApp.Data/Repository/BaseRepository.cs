namespace AutoDetailingApp.Data.Repository
{
	using System.Linq;
	using System.Threading.Tasks;
	using System.Collections.Generic;

	using AutoDetailingApp.Data.Repository.Interfaces;
	using Microsoft.EntityFrameworkCore;
	using AutoDetailingApp.Data;
	using System.Linq.Expressions;
	using AutoDetailingApp.Models;

	public class BaseRepository<TType, TId> : IRepository<TType, TId>
		where TType : class
	{
		private readonly AutoDetailingDbContext dbContext;
		private readonly DbSet<TType> dbSet;

		public BaseRepository(AutoDetailingDbContext dbContext)
		{
			this.dbContext = dbContext;
			this.dbSet = this.dbContext.Set<TType>();
		}

		public void Add(TType item)
		{
			this.dbSet.Add(item);
			this.dbContext.SaveChanges();
		}

		public async Task AddAsync(TType item)
		{
			await this.dbSet.AddAsync(item);
			await this.dbContext.SaveChangesAsync();
		}
		public bool Update(TType item)
		{
			try
			{
				this.dbSet.Attach(item);
				this.dbContext.Entry(item).State = EntityState.Modified;
				this.dbContext.SaveChanges();

				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public async Task<bool> UpdateAsync(TType item)
		{
			try
			{
				this.dbSet.Attach(item);
				this.dbContext.Entry(item).State = EntityState.Modified;
				await this.dbContext.SaveChangesAsync();

				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public async Task<TType?> GetByIdAsync(TId id)
		{
			return await dbSet.FindAsync(id);
		}

		public async Task<IEnumerable<TType>> GetAllAsync()
		{
			return await dbSet.ToListAsync();
		}

		public async Task<IEnumerable<TType>> FindAsync(Expression<Func<TType, bool>> predicate)
		{
			return await dbSet.Where(predicate).ToListAsync();
		}

		public async Task<bool> ExistsAsync(Expression<Func<TType, bool>> predicate)
		{
			return await dbSet.AnyAsync(predicate);
		}

		public bool Delete(TType entity)
		{
			this.dbSet.Remove(entity);
			this.dbContext.SaveChanges();

			return true;
		}

		public async Task<bool> DeleteAsync(TType entity)
		{
			this.dbSet.Remove(entity);
			await this.dbContext.SaveChangesAsync();

			return true;
		}

		public async Task<Appointment?> GetByEmailAsync(string email)
		{
			return await this.dbContext.Appointments
				.FirstOrDefaultAsync(p => p.Email == email);
		}

		public async Task<ContactRequest?> GetByContactEmailAsync(string email)
		{
			return await this.dbContext.ContactRequests
				.FirstOrDefaultAsync(p => p.Email == email);
		}
	}
}
