using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FaturamentoService.DTOs
{
    public class CreateInvoiceProductDto
    {
        [Required(ErrorMessage = "O ID do produto é obrigatório.")]
        public Guid ProductId { get; set; }
       
        [Range(ValidationRules.MinQuantity, int.MaxValue, ErrorMessage = ValidationRules.QuantityError)]
        public int Quantity { get; set; }
    }
}