using System;
using System.Collections.Generic;
using System.Text;

namespace MhwLoadoutCreator.Models.Monster
{
    public class Monsters
    {
        public IEnumerable<Monster> MonsterList { get; set; }
        public DateTime DateInit { get; set; }
    }
}
