using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaturamentoService.DTOs
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }
        public string FiscalNumber { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public List<InvoiceProductDto> Products { get; set; } = new();
    }
}