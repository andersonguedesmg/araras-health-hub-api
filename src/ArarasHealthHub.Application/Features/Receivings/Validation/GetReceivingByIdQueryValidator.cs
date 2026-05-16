using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Receivings.Queries.GetReceivingById;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Receivings.Validation
{
    public class GetReceivingByIdQueryValidator : AbstractValidator<GetReceivingByIdQuery>
    {
        public GetReceivingByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");
        }
    }
}
