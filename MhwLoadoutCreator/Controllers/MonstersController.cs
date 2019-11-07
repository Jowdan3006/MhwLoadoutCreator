using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MhwLoadoutCreator.MhwDbApiAccess.Abstract;
using MhwLoadoutCreator.Models.Monster;
using Microsoft.AspNetCore.Mvc;

namespace MhwLoadoutCreator.Controllers
{
    [Route("api/[controller]")]
    public class MonstersController : Controller
    {
        private IMhwDbApiHandler<Monster, Monsters> _mhwDbApiHandler { get; set; }

        public MonstersController(IMhwDbApiHandler<Monster, Monsters> mhwDbApiHandler)
        {
            _mhwDbApiHandler = mhwDbApiHandler ?? throw new ArgumentNullException(nameof(mhwDbApiHandler));
        }

        [HttpGet]
        public async Task<Monsters> Get()
        {
            return await _mhwDbApiHandler.Get();
        }

        [HttpGet("{id}")]
        public async Task<Monster> Get(int id)
        {
            return await _mhwDbApiHandler.Get(id);
        }
    }
}
