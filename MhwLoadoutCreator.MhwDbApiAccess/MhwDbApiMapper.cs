using MhwLoadoutCreator.MhwDbApiAccess.Abstract;
using MhwLoadoutCreator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
                    Id = monster.Id
                }
                ).ToArray()
            };
            return monsters;
        }
    }
}
