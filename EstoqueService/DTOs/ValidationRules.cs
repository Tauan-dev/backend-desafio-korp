using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueService.DTOs
{
    public static class ValidationRules
    {

        public const string NameRegex = @"^[\p{L}\p{M}\s'-]{1,100}$";
        public const string NameError = "O nome do produto deve conter apenas letras, com no máximo 100 caracteres.";

        public const int MaxStock = 10000;
        public const string StockError = "O estoque não pode exceder 10.000 unidades.";

        public const double MinPrice = 0.01;
        public const string MinPriceError = "O preço deve ser maior que zero.";

    }
}