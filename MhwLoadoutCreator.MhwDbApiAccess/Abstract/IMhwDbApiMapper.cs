using MhwLoadoutCreator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MhwLoadoutCreator.MhwDbApiAccess.Abstract
{
    public interface IMhwDbApiMapper
    {
        Monsters Map(IEnumerable<MonsterApi> monsterApi);
    }
}
