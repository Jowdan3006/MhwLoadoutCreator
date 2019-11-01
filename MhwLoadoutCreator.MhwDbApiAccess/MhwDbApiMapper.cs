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
        public Monsters Map(MonstersApi monstersApi)
        {
            Monsters monsters = new Monsters()
            {
                MonsterList = monstersApi.MonsterList.Select(monster => new Monster()
                {
                    Name = monster.Name,
                    Id = (int)monster.Id
                }
                ).ToArray()
            };

            return monsters;
        }

        public Monster Map(Monsters monsters, int id)
        {
            throw new NotImplementedException();
            //return monsters.MonsterList.Select(monster => monster);
        }
    }
}
