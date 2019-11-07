using MhwLoadoutCreator.Models.Armor;
using MhwLoadoutCreator.Models.Monster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MhwLoadoutCreator.MhwDbApiAccess.Abstract
{
    public interface IMhwDbApiHandler<IModel, IModels>
    {
        Task<IModels> Get();
        Task<IModel> Get(int id);
    }
}
