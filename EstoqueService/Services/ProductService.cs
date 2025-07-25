using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueService.DTOs;
using EstoqueService.Repositories;
using AutoMapper;
using EstoqueService.Models;

namespace EstoqueService.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var productEntity = await _productRepository.GetAllProductsAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(productEntity);
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var productEntity = await _productRepository.GetProductByIdAsync(id);
            return _mapper.Map<ProductDto>(productEntity) ??
                throw new KeyNotFoundException($"Produto com ID {id} não encontrado.");
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.CreateAsync(productEntity);
            return _mapper.Map<ProductDto>(productEntity);
        }

        public async Task<ProductDto?> UpdateAsync(Guid id, CreateProductDto productDto)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Produto com ID {id} não encontrado.");
            }

            _mapper.Map(productDto, existingProduct);
            await _productRepository.UpdateAsync(existingProduct);
            return _mapper.Map<ProductDto>(existingProduct);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var productEntity = await _productRepository.GetProductByIdAsync(id) ??
                throw new KeyNotFoundException($"Produto com ID {id} não encontrado.");

            await _productRepository.DeleteAsync(productEntity);
            return true;
        }

    }
}