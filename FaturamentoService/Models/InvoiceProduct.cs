using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaturamentoService.Models
{
    public class InvoiceProduct
    {
        public Guid Id { get; set; }

        public Guid InvoiceId { get; set; }
        public required Invoice Invoice { get; set; }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}