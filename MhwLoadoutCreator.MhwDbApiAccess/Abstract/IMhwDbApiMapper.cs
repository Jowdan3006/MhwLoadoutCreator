using MhwLoadoutCreator.Models.Armor;
using MhwLoadoutCreator.Models.Armor.Api;
using MhwLoadoutCreator.Models.Monster;
using MhwLoadoutCreator.Models.Monster.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace MhwLoadoutCreator.MhwDbApiAccess.Abstract
{
    public interface IMhwDbApiMapper
    {
        Monsters Map(IEnumerable<MonsterApi> monsterApi);
        Armors Map(IEnumerable<ArmorApi> armorApi);
    }
}
