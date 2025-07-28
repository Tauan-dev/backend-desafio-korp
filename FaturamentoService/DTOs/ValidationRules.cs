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

        

    }
}