using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace ArarasHealthHub.Shared.Core.Pagination
{
    public class PagedQueryValidator<TQuery> : AbstractValidator<TQuery>
        where TQuery : PagedRequest
    {
        protected PagedQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0)
                .WithMessage("O número da página deve ser maior que zero.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .WithMessage("A quantidade de registros por página deve ser maior que zero.")
                .LessThanOrEqualTo(100)
                .WithMessage("A quantidade máxima de registros por página é 100.");

            RuleFor(x => x.SortOrder)
                .Must(x => x is null || x.ToLower() is "asc" or "desc")
                .WithMessage("A ordenação deve ser 'asc' ou 'desc'.");
        }
    }
}
