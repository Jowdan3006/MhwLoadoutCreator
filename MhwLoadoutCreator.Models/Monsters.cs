using MhwLoadoutCreator.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MhwLoadoutCreator.Models
{
    public class Monsters : IMonsters
    {
        public IEnumerable<IMonster> MonsterList { get; set; }
    }
}
