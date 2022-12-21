using DesafioAutoGlass.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutoGlass.Core.Interfaces.Repositorys
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> RemoveAsync(int id);
        Product GetById(int id);
        Task<List<Product>> GetListFilterd(int? skip, int take, Expression<Func<Product, bool>>? where = null);
        Task<int> CountByFilterd(Expression<Func<Product, bool>>? where = null);
    }
}
