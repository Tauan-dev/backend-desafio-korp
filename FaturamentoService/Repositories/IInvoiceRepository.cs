using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaturamentoService.Models;

namespace FaturamentoService.Repositories
{
    public interface IInvoiceRepository
    {
        Task<Invoice> CreateAsync(Invoice invoice);
        Task<Invoice?> GetByIdAsync(Guid id);
        Task<List<Invoice>> GetAllAsync();
        Task UpdateAsync(Invoice invoice);
    }
}