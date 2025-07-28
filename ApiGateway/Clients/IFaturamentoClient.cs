using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaturamentoService.DTOs;


namespace ApiGateway.Clients
{
    public interface IFaturamentoClient
    {
        Task<InvoiceDto?> GetInvoiceByIdAsync(Guid id);
        Task<bool> CloseInvoiceAsync(Guid id);
    }
}