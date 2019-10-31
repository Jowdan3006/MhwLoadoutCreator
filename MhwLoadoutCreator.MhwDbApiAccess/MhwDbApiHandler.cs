using MhwLoadoutCreator.MhwDbApiAccess.Abstract;
using MhwLoadoutCreator.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MhwLoadoutCreator.MhwDbApiAccess
{
    public class MhwDbApiHandler : IMhwDbApiHandler
    {
        private HttpClient _httpClient { get; set; }
        private IMhwDbApiMapper _mhwDbApiMapper { get; set; }
        private Monsters _monsters { get; set; }
        private DateTime _dateInit { get; set; }

        public MhwDbApiHandler(HttpClient httpClient, IMhwDbApiMapper mhwDbApiMapper)
        {
            _httpClient = httpClient;
            _mhwDbApiMapper = mhwDbApiMapper;
            _dateInit = DateTime.Now;
        }

        public async Task<Monsters> Get()
        {
            if (_monsters == null || _dateInit.AddDays(7) < DateTime.Now)
            {
                var response = await _httpClient.GetStringAsync("monsters");
                MonstersApi result = new MonstersApi() { MonsterList = MonsterApi.FromJson(response) };
                _monsters = _mhwDbApiMapper.Map(result);
                _monsters.DateInit = _dateInit;
            }
            return _monsters;
        }

        public async Task<Monster> Get(int id)
        {
            if (_monsters == null || _dateInit.AddDays(7) < DateTime.Now)
            {
                return _mhwDbApiMapper.Map(await Get(), id);
            }
            return _mhwDbApiMapper.Map(_monsters, id);
        }
    }
}
