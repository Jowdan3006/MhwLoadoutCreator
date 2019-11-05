using MhwLoadoutCreator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MhwLoadoutCreator.MhwDbApiAccess.Abstract
{
    public interface IMhwDbApiHandler
    {
        Task<Monsters> Get();
        Task<Monster> Get(long id);
    }
}
