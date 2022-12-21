using DesafioAutoGlass.Application.DTOs;
using DesafioAutoGlass.Core.DTOs;
using DesafioAutoGlass.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioAutoGlass.Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<Product> AddAsync(ProductDto productDto);
        Task<Product> UpdateAsync(ProductDto productDto);
        Task<Product> RemoveAsync(int id);
        Product GetById(int id);
        Task<ProductListDto> GetByFilterAsync(ProductSearchDto filter);
    }
}
