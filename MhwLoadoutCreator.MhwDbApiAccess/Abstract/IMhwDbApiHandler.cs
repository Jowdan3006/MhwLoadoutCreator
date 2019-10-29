using MhwLoadoutCreator.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MhwLoadoutCreator.MhwDbApiAccess.Abstract
{
    public interface IMhwDbApiHandler
    {
        Task<IMonsters> Get();
        Task<IMonster> Get(int id);
    }
}
