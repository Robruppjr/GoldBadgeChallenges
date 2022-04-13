using System.Collections.Generic;
using Xunit;

public class POCOs_TestingSite
{
    [Fact]
    public void CreateAnInstanceOf_Ingredient()
    {
        Ingredient ingredient = new Ingredient("Beef Patty");
        ingredient.ID=1;
        int expectedIngredientID=1;
        int actualIngredientID= ingredient.ID;
        Assert.Equal(expectedIngredientID,actualIngredientID);
    }
    [Fact]
    public void CreateAnInstanceOf_MenuItem()
    {
        MenuItem menuItem = new MenuItem();
        menuItem.Ingredients=new List<Ingredient>
        {
            new Ingredient("Bun"),
            new Ingredient("Lettuce"),
            new Ingredient("Beef Patty"),
        };
        int expected=3;
        int actual=menuItem.Ingredients.Count;
        Assert.Equal(expected,actual);
    }
}