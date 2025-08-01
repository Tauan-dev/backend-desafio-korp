using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueService.DTOs;

namespace EstoqueService.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(Guid id);
        Task<ProductDto> CreateAsync(CreateProductDto dto);
        Task<ProductDto?> UpdateAsync(Guid id, CreateProductDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DecreaseStockAsync(Guid id, int quantity);

    }

}