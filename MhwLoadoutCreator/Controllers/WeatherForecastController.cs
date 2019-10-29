using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MhwLoadoutCreator.MhwDbApiAccess.Abstract;
using MhwLoadoutCreator.Models;
using MhwLoadoutCreator.Models.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MhwLoadoutCreator.Controllers
{
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {

        private IMhwDbApiHandler _mhwDbApiHandler { get; set; }

        public WeatherForecastController(IMhwDbApiHandler mhwDbApiHandler)
        {
            _mhwDbApiHandler = mhwDbApiHandler;
        }

        [HttpGet]
        public async Task<IMonsters> Get()
        {
            return await _mhwDbApiHandler.Get();
        }

        [HttpPost]
        public int Post(int monsterId)
        {
            return monsterId;

            //return await _mhwDbApiHandler.Get(id);
        }
    }
}
