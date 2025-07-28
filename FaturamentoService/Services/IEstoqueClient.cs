using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaturamentoService.DTOs;

namespace FaturamentoService.Services
{
    public interface IEstoqueClient
    {
        Task<ProductDto?> GetProductByIdAsync(Guid id);
    }
}