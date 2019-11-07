using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MhwLoadoutCreator.MhwDbApiAccess.Abstract;
using MhwLoadoutCreator.Models.Armor;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MhwLoadoutCreator.Controllers
{
    [Route("api/[controller]")]
    public class ArmorController : Controller
    {
        private IMhwDbApiHandler<Armor, Armors> _mhwDbApiHandler { get; set; }

        public ArmorController(IMhwDbApiHandler<Armor, Armors> mhwDbApiHandler)
        {
            _mhwDbApiHandler = mhwDbApiHandler ?? throw new ArgumentNullException(nameof(mhwDbApiHandler));
        }

        [HttpGet]
        public async Task<Armors> Get()
        {
            return await _mhwDbApiHandler.Get();
        }

        [HttpGet, Route("{action}")]
        public async Task<object> Equip(string e)
        {
            try
            {
                List<int> equippedArmor = e.Split(",").Select(x => Int32.Parse(x)).ToList();
                if (equippedArmor.Count > 5)
                {
                    Response.StatusCode = 400;
                    return Content("Please ensure a maximum of 5 Armor Id's are inlcuded in this request.");
                }
                if (equippedArmor.Count <= 0)
                {
                    Response.StatusCode = 400;
                    return Content("Please ensure you have inlcuded at least 1 Armor Id to equip and that the Id is a valid integer.");
                }
                return equippedArmor;
            }
            catch(FormatException)
            {
                Response.StatusCode = 400;
                return Content("Please ensure that the supplied Id(s) is a valid integer and that each integer is seperated by a comma e.g \"12,49,498\"");
            };

            
        }
    }
}