using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MhwLoadoutCreator.MhwDbApiAccess.Abstract
{
    public interface IMhwDbApiClient
    {
        Task<string> Get(string endpoint);
    }
}
