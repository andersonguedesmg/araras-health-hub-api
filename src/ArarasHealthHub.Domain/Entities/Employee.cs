using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Cpf { get; private set; } = string.Empty;
        public string Function { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;

        private Employee() { }

        public Employee(string name, string cpf, string function, string phone)
        {
            Name = name;
            Cpf = cpf;
            Function = function;
            Phone = phone;
        }

        public void Update(string name, string function, string phone)
        {
            Name = name;
            Function = function;
            Phone = phone;
        }
    }
}
