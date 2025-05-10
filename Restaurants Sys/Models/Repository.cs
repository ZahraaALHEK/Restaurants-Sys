
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Restaurants_Sys.Controllers;
using Restaurants_Sys.Data;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace Restaurants_Sys.Models;
public class Repository<T> : IRepository<T> where T : class
{
    

    protected RestaurantDbContext _context{get;set;}
    private DbSet<T> _dbSet {get;set;}
 

    public Repository(RestaurantDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
         await _dbSet.AddAsync(entity);
    await _context.SaveChangesAsync();
        
    }
    public async Task<IEnumerable<T>> GetAllFillterAsync(Expression<Func<T, bool>> filter)
    {
    return await _dbSet.Where(filter).ToListAsync();
    }
    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
    public async Task <IEnumerable<T>> GetAllAsync(){
               return await _dbSet.ToListAsync();

    }
    public async Task<T> GetByIdAsync(int id, QueryOptions<T> options)
    {
    IQueryable<T> query = _dbSet;
    
    if(options.HasWhere)
    {
        query = query.Where(options.Where);
    }
    
    if(options.HasOrderBy)
    {
        query = query.OrderBy(options.OrderBy); // Note: Added assignment here
    }
    
    foreach (string include in options.GetIncludes())
    {
        query = query.Include(include);
    }
    
    var key = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.FirstOrDefault();
    string primaryKeyName = key?.Name;
    
    return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, primaryKeyName) == id);
}    
public Task UpdateAsync (T entity){
                throw new NotImplementedException();

    }

}