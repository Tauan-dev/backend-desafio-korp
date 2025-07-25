using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueService.DTOs
{
    public class CreateProductDto
    {

        [RegularExpression(ValidationRules.NameRegex, ErrorMessage = ValidationRules.NameError)]
        [DisplayName("Nome")]
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        public required string Name { get; set; }


        [Range(ValidationRules.MinPrice, double.MaxValue, ErrorMessage = ValidationRules.MinPriceError)]
        [DisplayName("Preço")]
        [Required(ErrorMessage = "O preço do produto é obrigatório.")]
        public decimal Price { get; set; }


        [Range(1, ValidationRules.MaxStock, ErrorMessage = ValidationRules.StockError)]
        [DisplayName("Estoque")]
        [Required(ErrorMessage = "Estoque minimo é obrigatório.")]
        public int Stock { get; set; }
    }
}