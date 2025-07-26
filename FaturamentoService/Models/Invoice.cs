using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaturamentoService.Models
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public string FiscalNumber { get; set; } = string.Empty;
        public InvoiceStatus Status { get; set; } = InvoiceStatus.Open;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<InvoiceProduct> Products { get; set; } = new();
    }
}