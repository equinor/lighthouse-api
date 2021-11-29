using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.MainApi.Certificate
{
    public interface ICertificateApiService
    {
        Task<PCSCertificateTagsModel> TryGetCertificateTagsAsync(
            string plant, 
            string projectName,
            string certificateNo,
            string certificateType);
        
        Task<IEnumerable<PCSCertificateModel>> GetAcceptedCertificatesAsync(
            string plant, 
            DateTime cutoffAcceptedTime);
    }
}
