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

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [RegularExpression(ValidationRules.ProductNameRegex, ErrorMessage = ValidationRules.ProductNameError)]
        public string ProductName { get; set; } = string.Empty;

        [Required(ErrorMessage = "O preço do produto é obrigatório.")]
        [Range(ValidationRules.MinPrice, double.MaxValue, ErrorMessage = ValidationRules.MinPriceError)]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = ValidationRules.PriceError)]
        public decimal ProductPrice { get; set; }

        [Range(ValidationRules.MinQuantity, int.MaxValue, ErrorMessage = ValidationRules.QuantityError)]
        public int Quantity { get; set; }
    }
}