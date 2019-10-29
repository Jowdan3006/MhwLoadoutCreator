using MhwLoadoutCreator.MhwDbApiAccess.Abstract;
using MhwLoadoutCreator.Models;
using MhwLoadoutCreator.Models.Abstract;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MhwLoadoutCreator.MhwDbApiAccess
{
    public class MhwDbApiHandler : IMhwDbApiHandler
    {
        private HttpClient _httpClient { get; set; }
        private IMhwDbApiMapper _mhwDbApiMapper { get; set; }
        public object IMonsters { get; private set; }

        public MhwDbApiHandler(HttpClient httpClient, IMhwDbApiMapper mhwDbApiMapper)
        {
            _httpClient = httpClient;
            _mhwDbApiMapper = mhwDbApiMapper;
        }

        public async Task<IMonsters> Get()
        {
            var response = await _httpClient.GetStringAsync("monsters");
            IMonstersApi result = new MonstersApi() { MonsterList = MonsterApi.FromJson(response) };
            return _mhwDbApiMapper.Map(result);
        }

        public async Task<IMonster> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
