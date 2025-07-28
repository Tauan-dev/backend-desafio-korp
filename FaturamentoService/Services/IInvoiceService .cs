using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaturamentoService.DTOs;

namespace FaturamentoService.Services
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceDto>> GetAllAsync();
        Task<InvoiceDto?> GetByIdAsync(Guid id);
        Task<InvoiceDto> CreateAsync(CreateInvoiceDto invoiceDto);
        Task<InvoiceDto?> UpdateAsync(Guid id, CreateInvoiceDto invoiceDto);
        Task<bool> CloseInvoiceAsync(Guid id);


    }
}