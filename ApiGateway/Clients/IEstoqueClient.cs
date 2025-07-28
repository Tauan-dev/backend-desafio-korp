using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueService.DTOs;


namespace ApiGateway.Clients
{
    public interface IEstoqueClient
    {
        Task<ProductDto> GetProductByIdAsync(Guid id);
        Task<bool> DecreaseStockAsync(Guid id, int quantity);
    }
}