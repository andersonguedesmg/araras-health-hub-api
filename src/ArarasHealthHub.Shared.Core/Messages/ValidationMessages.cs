using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Core.Messages
{
    public static class ValidationMessages
    {
        public const string Required = "Campo obrigatório.";
        public const string RequiredWithField = "{PropertyName} é obrigatório.";

        public static string MaxLength(int max) => $"Não pode exceder {max} caracteres.";
        public static string MaxLengthWithField(int max) => $"{{PropertyName}} não pode exceder {max} caracteres.";
        public static string MinLength(int min) => $"Deve conter no mínimo {min} caracteres.";
        public static string MinLengthWithField(int min) => $"{{PropertyName}} deve conter no mínimo {min} caracteres.";

        public const string GreaterThanZero = "Deve ser maior que zero.";
        public const string GreaterThanZeroWithField = "{PropertyName} deve ser maior que zero.";

        public const string Positive = "Deve ser um valor positivo.";
        public const string PositiveWithField = "{PropertyName} deve ser um valor positivo.";

        public const string Invalid = "Valor inválido.";
        public const string InvalidWithField = "{PropertyName} inválido.";

        public const string InvalidEmail = "E-mail inválido.";
        public const string InvalidEmailWithField = "{PropertyName} inválido.";

        public const string MustBeDifferent = "O valor informado deve ser diferente do atual.";
        public const string MustBeDifferentWithField = "{PropertyName} deve ser diferente do valor atual.";

        public const string InvalidId = "Identificador inválido.";
        public const string InvalidOrderBy = "O campo de ordenação informado não é válido.";
        public const string InvalidIdWithField = "{PropertyName} inválido.";
    }
}
