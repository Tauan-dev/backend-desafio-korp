using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaturamentoService.Models.Enums;

namespace FaturamentoService.DTOs
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }
        public string FiscalNumber { get; set; } = string.Empty;
        public InvoiceStatus Status { get; set; } 
        public List<InvoiceProductDto> Products { get; set; } = new();
    }
}