using System;
using System.Collections.Generic;
using System.Text;

namespace MhwLoadoutCreator.Models.Armor
{
    public class Armors
    {
        public IEnumerable<Armor> ArmorList { get; set; }
        public DateTime DateInit { get; set; }
    }
}
