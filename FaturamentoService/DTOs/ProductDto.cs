using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaturamentoService.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}