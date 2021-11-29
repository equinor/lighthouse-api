using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.MainApi.Plant;

public interface IPlantApiService
{
    Task<List<PCSPlant>> GetAllPlantsForUserAsync(Guid azureOid);
}