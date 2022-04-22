using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public class Door
    {
        public Door (){}
        public Door(string name)
        {
            Name = name;
        }
        public string Name { get; set;}
        public int ID {get; set;}
    }