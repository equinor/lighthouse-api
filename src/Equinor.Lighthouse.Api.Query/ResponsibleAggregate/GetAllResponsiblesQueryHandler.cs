﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ResponsibleAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Query.ResponsibleAggregate;

public class GetAllResponsiblesQueryHandler : IRequestHandler<GetAllResponsiblesQuery, Result<IEnumerable<ResponsibleDto>>>
{
    private readonly IReadOnlyContext _context;

    public GetAllResponsiblesQueryHandler(IReadOnlyContext context) => _context = context;

    public async Task<Result<IEnumerable<ResponsibleDto>>> Handle(GetAllResponsiblesQuery request, CancellationToken cancellationToken)
    {
        var responsibles = await (from r in _context.QuerySet<Responsible>()
            select r).ToListAsync(cancellationToken);
        return new SuccessResult<IEnumerable<ResponsibleDto>>(responsibles.Select(
            responsible => new ResponsibleDto(
                responsible.Id,
                responsible.Code,
                responsible.Description,
                responsible.RowVersion.ConvertToString())));
    }
}