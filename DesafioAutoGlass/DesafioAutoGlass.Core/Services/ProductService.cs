using AutoMapper;
using DesafioAutoGlass.Application.DTOs;
using DesafioAutoGlass.Core.DTOs;
using DesafioAutoGlass.Core.Entities;
using DesafioAutoGlass.Core.Interfaces.Repositorys;
using DesafioAutoGlass.Core.Interfaces.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioAutoGlass.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(
            IProductRepository productRepository,
            IMapper mapper
            )
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        private bool Validate(ProductDto productDto)
        {
            if(productDto.FabricationDate >= productDto.ValidateDate)
                throw new ApplicationException("Data de Fabricação não pode ser maior ou igual a Data de Validade");

            return true;
        }

        public async Task<Product> AddAsync(ProductDto productDto)
        {
            Validate(productDto);

            Product product = _mapper.Map<ProductDto, Product>(productDto);

            return await _productRepository.AddAsync(product);
        }

        public async Task<Product> UpdateAsync(ProductDto productDto)
        {
            Validate(productDto);

            Product product = _mapper.Map<ProductDto, Product>(productDto);

            return await _productRepository.UpdateAsync(product);
        }

        public async Task<Product> RemoveAsync(int id)
        {
            return await _productRepository.RemoveAsync(id);
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public async Task<ProductListDto> GetByFilterAsync(ProductSearchDto filter)
        {

             var resultList = await _productRepository.GetListFilterd(filter.Skip, filter.Take, 
                     x => !x.Deleted &&
                     x.Status && 
                     (string.IsNullOrEmpty(filter.Description) || 
                     x.Description.ToLower().Contains(filter.Description.ToLower())));

             var countProducts = await _productRepository.CountByFilterd(x => 
                    !x.Deleted &&
                    x.Status &&
                    (string.IsNullOrEmpty(filter.Description) || 
                    x.Description.ToLower().Contains(filter.Description.ToLower())));

            return new ProductListDto
            {
                Products = resultList,
                Count = countProducts
            };
        }
    }
}
