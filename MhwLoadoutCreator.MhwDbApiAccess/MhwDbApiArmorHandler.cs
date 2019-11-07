using MhwLoadoutCreator.MhwDbApiAccess.Abstract;
using MhwLoadoutCreator.Models;
using MhwLoadoutCreator.Models.Armor;
using MhwLoadoutCreator.Models.Armor.Api;
using MhwLoadoutCreator.Models.Monster;
using MhwLoadoutCreator.Models.Monster.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MhwLoadoutCreator.MhwDbApiAccess
{
    public class MhwDbApiArmorHandler : IMhwDbApiHandler<Armor, Armors>
    {
        private IMhwDbApiClient _mhwDbApiClient { get; set; }
        private IMhwDbApiMapper _mhwDbApiMapper { get; set; }
        private Armors _armors { get; set; }
        private DateTime _dateInit { get; set; }

        public MhwDbApiArmorHandler(IMhwDbApiClient mhwDbApiClient, IMhwDbApiMapper mhwDbApiMapper)
        {
            _mhwDbApiClient = mhwDbApiClient;
            _mhwDbApiMapper = mhwDbApiMapper;
            _dateInit = DateTime.Now;
        }

        public async Task<Armors> Get()
        {
            if (_armors == null || DateTime.Compare(_dateInit.AddDays(7), DateTime.Now) < 0)
            {
                var response = await _mhwDbApiClient.Get("armor");
                List<ArmorApi> result = new List<ArmorApi>(ArmorApi.FromJson(response));
                _armors = _mhwDbApiMapper.Map(result);
                _dateInit = DateTime.Now;
                _armors.DateInit = _dateInit;
            }
            return _armors;
        }

        public async Task<Armor> Get(int id)
        {
            if (_armors == null || DateTime.Compare(_dateInit.AddDays(7), DateTime.Now) < 0)
            {
                await Get();
            }
            return _armors.ArmorList.Where(x => x.Id == id).First();
        }
    }
}
