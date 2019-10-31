using MhwLoadoutCreator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MhwLoadoutCreator.MhwDbApiAccess.Abstract
{
    public interface IMhwDbApiMapper
    {
        Monsters Map(MonstersApi monstersApi);
        Monster Map(Monsters monsters, int id);
    }
}
