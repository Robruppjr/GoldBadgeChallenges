using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public class MenuItem
    {
    public MenuItem(){}
    public MenuItem(string name, string description, List<Ingredient> ingredients, decimal price)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    public int ID {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}
    public List<Ingredient> Ingredients  {get; set;} = new List<Ingredient>();
    public decimal Price {get; set;}
    }
