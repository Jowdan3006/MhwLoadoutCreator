using System;
using System.Collections.Generic;
using System.Text;

namespace MhwLoadoutCreator.Models.Abstract
{
    public interface IMonsters
    {
        IEnumerable<IMonster> MonsterList { get; set; }
    }
}
