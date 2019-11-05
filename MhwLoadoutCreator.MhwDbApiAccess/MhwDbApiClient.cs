using MhwLoadoutCreator.MhwDbApiAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MhwLoadoutCreator.MhwDbApiAccess
{
    public class MhwDbApiClient : IMhwDbApiClient
    {
        private HttpClient _httpClient { get; set; }

        public MhwDbApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Get(string endpoint)
        {
            return await _httpClient.GetStringAsync(endpoint);
        }
    }
}
