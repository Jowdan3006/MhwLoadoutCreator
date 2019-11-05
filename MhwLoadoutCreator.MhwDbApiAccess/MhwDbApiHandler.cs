using MhwLoadoutCreator.MhwDbApiAccess.Abstract;
using MhwLoadoutCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MhwLoadoutCreator.MhwDbApiAccess
{
    public class MhwDbApiHandler : IMhwDbApiHandler
    {
        private IMhwDbApiClient _mhwDbApiClient { get; set; }
        private IMhwDbApiMapper _mhwDbApiMapper { get; set; }
        private Monsters _monsters { get; set; }
        private DateTime _dateInit { get; set; }

        public MhwDbApiHandler(IMhwDbApiClient mhwDbApiClient, IMhwDbApiMapper mhwDbApiMapper)
        {
            _mhwDbApiClient = mhwDbApiClient;
            _mhwDbApiMapper = mhwDbApiMapper;
            _dateInit = DateTime.Now;
        }

        public async Task<Monsters> Get()
        {
            if (_monsters == null || DateTime.Compare(_dateInit.AddDays(7), DateTime.Now) < 0)
            {
                var response = await _mhwDbApiClient.Get("monsters");
                List<MonsterApi> result = new List<MonsterApi>(MonsterApi.FromJson(response));
                _monsters = _mhwDbApiMapper.Map(result);
                _dateInit = DateTime.Now;
                _monsters.DateInit = _dateInit;
            }
            return _monsters;
        }

        public async Task<Monster> Get(long id)
        {
            if (_monsters == null || DateTime.Compare(_dateInit.AddDays(7), DateTime.Now) < 0)
            {
                await Get();
            }
            return _monsters.MonsterList.Where(x => x.Id == id).First();
        }
    }
}
