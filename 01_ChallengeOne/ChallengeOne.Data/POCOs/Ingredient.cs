using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public class Ingredient
    {
        public Ingredient (){}
        public Ingredient(string name)
        {
            Name=name;
        }
        public int ID {get; set;}
        public string Name{get; set;}
    }
