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
        public Guid Id { get; set; }

        [RegularExpression(ValidationRules.NameRegex, ErrorMessage = ValidationRules.NameError)]
        [DisplayName("Nome")]
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        public required string Name { get; set; }

        
    }
}