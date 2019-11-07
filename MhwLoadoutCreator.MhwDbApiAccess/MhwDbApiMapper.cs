using MhwLoadoutCreator.MhwDbApiAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MhwLoadoutCreator.Models.Monster.Api;
using MhwLoadoutCreator.Models.Monster;
using MhwLoadoutCreator.Models.Armor;
using MhwLoadoutCreator.Models.Armor.Api;

namespace MhwLoadoutCreator.MhwDbApiAccess
{
    public class MhwDbApiMapper : IMhwDbApiMapper
    {
        public Monsters Map(IEnumerable<MonsterApi> monsterApi)
        {
            Monsters monsters = new Monsters()
            {
                MonsterList = monsterApi.Select(monster => new Monster()
                {
                    Name = monster.Name,
                    Id = monster.Id.Value
                }
                ).ToArray()
            };
            return monsters;
        }

        public Armors Map(IEnumerable<ArmorApi> armorApi)
        {
            Armors armors = new Armors()
            {
                ArmorList = armorApi.Select(armor => new Armor()
                {
                    Id = armor.Id.Value,
                    Name = armor.Name,
                    Rank = armor.Rank,
                    Rarity = armor.Rarity.Value,
                    Type = armor.Type,
                    Defense = new Models.Armor.Defense()
                    {
                        Base = armor.Defense.Base.Value,
                        Max = armor.Defense.Max.Value,
                        Augmented = armor.Defense.Augmented.Value
                    }

                })
            };
            return armors;
        }
    }
}
