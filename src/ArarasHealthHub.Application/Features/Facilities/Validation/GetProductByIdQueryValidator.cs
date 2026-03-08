using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Facilities.Queries.GetFacilityById;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Facilities.Validation
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetFacilityByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");
        }
    }
}
