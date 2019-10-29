using MhwLoadoutCreator.Models;
using MhwLoadoutCreator.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MhwLoadoutCreator.MhwDbApiAccess.Abstract
{
    public interface IMhwDbApiMapper
    {
        IMonsters Map(IMonstersApi monstersApi);
        IMonster Map(MonsterApi monsterApi);
    }
}
