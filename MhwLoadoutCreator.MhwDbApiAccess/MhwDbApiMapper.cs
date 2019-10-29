using MhwLoadoutCreator.MhwDbApiAccess.Abstract;
using MhwLoadoutCreator.Models;
using MhwLoadoutCreator.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MhwLoadoutCreator.MhwDbApiAccess
{
    public class MhwDbApiMapper : IMhwDbApiMapper
    {
        public IMonsters Map(IMonstersApi monstersApi)
        {
            IMonsters monsters = new Monsters()
            {
                MonsterList = monstersApi.MonsterList.Select(monster => new Monster() { Name = monster.Name }).ToArray()
            };

            return monsters;
        }

        public IMonster Map(MonsterApi monsterApi)
        {
            throw new NotImplementedException();
        }
    }
}
