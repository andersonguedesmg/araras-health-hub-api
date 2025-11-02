using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Common.Helpers
{
    public static class CpfValidatorHelper
    {
        public static bool IsValidCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            if (cpf.All(c => c == cpf.First()))
                return false;

            int[] multiplier1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf = cpf.Substring(0, 9);
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

            int remainder = sum % 11;
            remainder = remainder < 2 ? 0 : 11 - remainder;
            string digit1 = remainder.ToString();

            int[] multiplier2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            tempCpf = tempCpf + digit1;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

            remainder = sum % 11;
            remainder = remainder < 2 ? 0 : 11 - remainder;
            string digit2 = remainder.ToString();

            return cpf.EndsWith(digit1 + digit2);
        }
    }
}
