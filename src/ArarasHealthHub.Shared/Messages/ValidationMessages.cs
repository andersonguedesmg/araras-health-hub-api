using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Messages
{
    public static class ValidationMessages
    {
        public const string Required = "Valor obrigatório.";
        public const string RequiredField = "{PropertyName} é obrigatório.";
        public const string RequiredObject = "O objeto de {PropertyName} é obrigatório.";

        public static string MaxLength(int max) => $"Não pode exceder {max} caracteres.";
        public static string MaxLengthField(int max) => $"{{PropertyName}} não pode exceder {max} caracteres.";

        public static string MinLength(int min) => $"Deve conter no mínimo {min} caracteres.";
        public static string MinLengthField(int min) => $"{{PropertyName}} deve conter no mínimo {min} caracteres.";

        public const string GreaterThanZero = "Deve ser maior que zero.";
        public const string GreaterThanZeroField = "{PropertyName} deve ser maior que zero.";

        public const string Positive = "Deve ser um valor positivo.";
        public const string PositiveField = "{PropertyName} deve ser um valor positivo.";

        public const string Invalid = "Valor inválido.";
        public const string InvalidField = "{PropertyName} inválido.";

        public const string InvalidId = "Identificador inválido.";
        public const string InvalidIdField = "{PropertyName} inválido.";

        public const string InvalidFormat = "Formato inválido.";
        public const string InvalidFormatField = "{PropertyName} inválido.";

        public const string InvalidEmail = "E-mail inválido.";
        public const string InvalidEmailField = "{PropertyName} inválido.";

        public const string MustBeDifferent = "O valor informado deve ser diferente do atual.";
        public const string MustBeDifferentField = "{PropertyName} deve ser diferente do valor atual.";

        public const string InvalidOrderBy = "O campo de ordenação informado não é válido.";

        public const string InvalidCpfFormat = "O CPF deve estar no formato XXX.XXX.XXX-XX.";
        public const string InvalidCnpjFormat = "O CNPJ deve estar no formato 'XX.XXX.XXX/XXXX-XX'.";
        public const string InvalidPhoneFormat = "O telefone informado não possui um formato válido.";
    }
}
