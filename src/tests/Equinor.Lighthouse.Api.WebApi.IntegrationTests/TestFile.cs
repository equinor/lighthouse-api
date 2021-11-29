using System;
using System.Net.Http;
using System.Text;

namespace Equinor.Lighthouse.Api.WebApi.IntegrationTests
{
    public class TestFile
    {
        private readonly byte[] _bytes;
        private readonly string _fileName;

        public TestFile(string content, string fileName)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            _fileName = fileName;
            _bytes = Encoding.UTF8.GetBytes(content);
        }
    }
}
