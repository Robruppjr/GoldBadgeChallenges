using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public class Badge
    {
        public Badge (){}
        public Badge(List<Door> doors)
        {
            Doors = doors;
        }
        public int BadgeID {get; set;}
        public List<Door> Doors {get; set;} = new List<Door>();
    }