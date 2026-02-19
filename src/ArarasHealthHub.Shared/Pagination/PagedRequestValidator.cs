using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace ArarasHealthHub.Shared.Pagination
{
    public class PagedRequestValidator<T> : AbstractValidator<T>
        where T : PagedRequest
    {
        public PagedRequestValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0)
                .WithMessage("O número da página deve ser maior que zero.");

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100)
                .WithMessage("O tamanho da página deve estar entre 1 e 100.");

            RuleFor(x => x.SortOrder)
                .Must(x => x is "asc" or "desc")
                .WithMessage("O tipo de ordenação deve ser 'asc' ou 'desc'.");
        }
    }
}
