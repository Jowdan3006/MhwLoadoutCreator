using System;
using System.Collections.Generic;
using System.Text;

namespace MhwLoadoutCreator.Models.Abstract
{
    public interface IMonstersApi
    {
        IEnumerable<MonsterApi> MonsterList { get; set; }
    }
}
