using System;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Query;
using Equinor.Lighthouse.Api.Query.LciObjects;
using Microsoft.AspNetCore.Mvc;

namespace Equinor.Lighthouse.Api.WebApi.Caches;

public interface IObjectsCache
{
    Task<ActionResult<PaginatedList<LciObjectDto>>> GetObjects(Func<Task<PaginatedList<LciObjectDto>>> query);
}
