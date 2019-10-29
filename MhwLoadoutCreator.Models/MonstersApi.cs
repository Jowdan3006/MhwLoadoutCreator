using MhwLoadoutCreator.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MhwLoadoutCreator.Models
{
    public class MonstersApi : IMonstersApi
    {
        public IEnumerable<MonsterApi> MonsterList { get; set; }
    }
}
