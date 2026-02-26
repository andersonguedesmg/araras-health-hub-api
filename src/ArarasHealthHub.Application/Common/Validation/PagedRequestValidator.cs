using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Common.Validation
{
    public class PagedRequestValidator<T> : AbstractValidator<T>
        where T : PagedRequest
    {
        protected PagedRequestValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0)
                .WithMessage("Número da página deve ser maior que zero.");

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100)
                .WithMessage("Tamanho da página deve estar entre 1 e 100.");

            RuleFor(x => x.SortOrder)
                .Must(x => x is null ||
                           x.Equals("asc", StringComparison.OrdinalIgnoreCase) ||
                           x.Equals("desc", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Ordenação deve ser 'asc' ou 'desc'.");
        }
    }
}
