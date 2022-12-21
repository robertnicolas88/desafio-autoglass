using DesafioAutoGlass.Core.Entities;
using DesafioAutoGlass.Core.Interfaces.Repositorys;
using DesafioAutoGlass.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioAutoGlass.Infrastructure.Data.Repositorys
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        private DbSet<Product> _dbSet;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Product>();
        }

        public async Task<Product> AddAsync(Product product) 
        {
            _context.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> RemoveAsync(int id)
        {
            Product product = _dbSet.SingleOrDefault(p => p.Id == id);

            product.Deleted = true;

            _context.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public Product GetById(int id)
        {
            return _dbSet.SingleOrDefault(p => p.Id == id && !p.Deleted);
        }

        public async Task<List<Product>> GetListFilterd(int? skip, int take, Expression<Func<Product, bool>> ? where = null)
        {
            IQueryable<Product> query = _dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }

            return await query.Skip((skip ?? 0) * take).Take(take).ToListAsync();
        }

        public async Task<int> CountByFilterd(Expression<Func<Product, bool>>? where = null)
        {
            IQueryable<Product> query = _dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }

            return await query.CountAsync();
        }
    }
}
