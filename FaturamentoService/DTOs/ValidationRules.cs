using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaturamentoService.DTOs
{
    public class ValidationRules
    {
        public const string InvoiceNumberRegex = @"^[A-Z0-9\-]{3,20}$";
        public const string InvoiceNumberError = "O número da nota deve conter entre 3 e 20 caracteres, com letras maiúsculas, números ou hífens.";

        public const int MinQuantity = 1;
        public const string QuantityError = "A quantidade deve ser pelo menos 1.";

        public const double MinPrice = 0.01;
        public const string MinPriceError = "O preço deve ser maior que zero.";
        public const string PriceError = "O preço deve ser um número positivo com até 2 casas decimais.";

        public const string ProductNameRegex = @"^[\w\s]{2,100}$";
        public const string ProductNameError = "O nome do produto deve conter entre 2 e 100 caracteres.";
    }
}