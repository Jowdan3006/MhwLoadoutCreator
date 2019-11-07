using System;
using System.Collections.Generic;
using System.Text;

namespace MhwLoadoutCreator.Models.Armor
{
    public class Armor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Rank { get; set; }
        public int Rarity { get; set; }
        public Defense Defense { get; set; }
    }
}
