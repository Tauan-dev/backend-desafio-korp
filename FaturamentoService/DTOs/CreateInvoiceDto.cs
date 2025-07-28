using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FaturamentoService.DTOs
{
    public class CreateInvoiceDto
    {
        [Required(ErrorMessage = "O número da nota fiscal é obrigatório.")]
        [RegularExpression(ValidationRules.InvoiceNumberRegex, ErrorMessage = ValidationRules.InvoiceNumberError)]
        public string FiscalNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "A nota fiscal deve conter ao menos um produto.")]
        public List<CreateInvoiceProductDto> Products { get; set; } = new();
    }
}