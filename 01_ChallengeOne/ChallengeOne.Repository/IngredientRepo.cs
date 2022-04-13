using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class IngredientRepo
    {
        private readonly List<Ingredient> _ingredientDb = new List<Ingredient>();
        private int _count;
        public bool AddIngredientToDatabase(Ingredient ingredient)
        {
            if(ingredient != null)
            {
                _count++;
                ingredient.ID=_count;
                _ingredientDb.Add(ingredient);
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Ingredient> GetAllIngredients()
        {
            return _ingredientDb;
        }
        public Ingredient GetIngredintByID(int id)
        {
            foreach (var ingredient in _ingredientDb)
            {
                if(ingredient.ID == id)
                {
                    return ingredient;
                }
            }
            return null;
        }
    }
