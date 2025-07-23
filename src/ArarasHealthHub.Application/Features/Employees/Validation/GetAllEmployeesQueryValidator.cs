using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Employees.Queries.GetAllEmployees;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Employees.Validation
{
    public class GetAllEmployeesQueryValidator : AbstractValidator<GetAllEmployeesQuery>
    {
        public GetAllEmployeesQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("O número da página deve ser maior ou igual a 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("O tamanho da página deve ser maior ou igual a 1.")
                .LessThanOrEqualTo(100).WithMessage("O tamanho da página não pode exceder 100.");

            RuleFor(x => x.SortOrder)
                .Must(BeValidSortOrder).WithMessage("A ordem de classificação deve ser 'asc' ou 'desc'.");

            RuleFor(x => x.OrderBy)
                .Must(BeValidOrderByProperty).WithMessage("O campo para ordenação não é válido.");
        }

        private bool BeValidSortOrder(string sortOrder)
        {
            return sortOrder.ToLower() == "asc" || sortOrder.ToLower() == "desc";
        }

        private bool BeValidOrderByProperty(string orderBy)
        {
            var allowedProperties = new[] { "id", "name", "cpf", "function" };
            return allowedProperties.Contains(orderBy.ToLower());
        }
    }
}
