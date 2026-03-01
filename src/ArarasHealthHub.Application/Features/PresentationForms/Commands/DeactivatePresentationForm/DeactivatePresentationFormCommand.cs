using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.PresentationForms.Commands.DeactivatePresentationForm
{
    public sealed record DeactivatePresentationFormCommand(int Id) : IRequest<Result>;
}
