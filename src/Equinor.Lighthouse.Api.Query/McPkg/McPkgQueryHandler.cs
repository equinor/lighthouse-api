using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Infrastructure;
using Equinor.Lighthouse.Api.Query.LciObjects;
using Equinor.Lighthouse.Api.Query.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Equinor.Lighthouse.Api.Query.McPkg;

public class McPkgQueryHandler : IRequestHandler<McPkgQuery, PaginatedList<McPkgDto>>
{
    private readonly FAMContext _context;
    private readonly IMapper _mapper;

    public McPkgQueryHandler(IMapper mapper, FAMContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<PaginatedList<McPkgDto>> Handle(McPkgQuery request, CancellationToken cancellationToken)
    {
        var contextMscMcPkgs = _context.McPkgs.AsQueryable();

        //TODO synaps paging
        var list = await contextMscMcPkgs.ProjectTo<McPkgDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

        if (request.PageSize == 0 || request.PageSize > list.Count)
        {
            return new PaginatedList<McPkgDto>(list, list.Count,1 ,list.Count);
        }

        var pagedList = list.Skip(request.PageSize * request.PageNumber).Take(request.PageSize).ToList();
        return new PaginatedList<McPkgDto>(pagedList, list.Count, request.PageNumber, request.PageSize);
    }
}
