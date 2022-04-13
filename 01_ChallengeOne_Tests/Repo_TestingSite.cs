using System.Collections.Generic;
using Xunit;

public class Repo_TestingSite
{
    private readonly MenuItemRepository _menuItemRepo;
    private readonly IngredientRepo _ingredientRepo;
    private MenuItem _menuItem;
    private Ingredient _ingredient;
    public Repo_TestingSite()
    {
        _menuItemRepo = new MenuItemRepository();
        _ingredientRepo = new IngredientRepo();
        _menuItem = new MenuItem("Burger", "A simple Burger", new List<Ingredient>{_ingredient}, 5m);
        _menuItemRepo.AddMenuItemToDatabase(_menuItem);
    }
    [Fact]
    public void AddMenuItemToDatabase_ShouldReturnTrue()
    {
        var menuItem = new MenuItem("Salad","A Simple Salad", new List<Ingredient> {_ingredient}, 7.50m);
        var expectingTrue = _menuItemRepo.AddMenuItemToDatabase(menuItem);
        Assert.True(expectingTrue);
    }
    [Fact]
    public void AddIngredientToDatabase_ShouldReturnTrue()
    {
        var ingredient = new Ingredient("Lettuce");
        var expectedTrue = _ingredientRepo.AddIngredientToDatabase(ingredient);
        Assert.True(expectedTrue);
    }
    [Fact]
    public void GetAllMenuItems_CountShouldMatch()
    {
        var menuItem = new MenuItem("Burger2", "A simple Burger2", new List<Ingredient>{_ingredient}, 5m);
        var menuItem2 = new MenuItem("Salad","A Simple Salad", new List<Ingredient> {_ingredient}, 7.50m);
        _menuItemRepo.AddMenuItemToDatabase(menuItem);
        _menuItemRepo.AddMenuItemToDatabase(menuItem2);
        var expextedMenutItemCount = 3;
        var actual = _menuItemRepo.GetAllMenuItems().Count;
        Assert.Equal(expextedMenutItemCount,actual);
    }
    [Fact]
    public void GetAllIngredients_CountShouldMatch()
    {
        var ingredient = new Ingredient("Tomato");
        var ingredient2 = new Ingredient("Spam");
        _ingredientRepo.AddIngredientToDatabase(ingredient);
        _ingredientRepo.AddIngredientToDatabase(ingredient2);
        var expectedIngredientCount = 2;
        var actual = _ingredientRepo.GetAllIngredients().Count;
        Assert.Equal(expectedIngredientCount,actual);
    }
    [Fact]
    public void RetriveIngredientsByID_ShouldReturnCorrectID_True()
    {
        var ingredient1 = new Ingredient("Beans");
        _ingredientRepo.AddIngredientToDatabase(ingredient1);
        var ingredient = _ingredientRepo.GetIngredintByID(1);
        var actula = ingredient.ID;
        var expected=1;
        Assert.Equal(expected,actula);
    }
    [Fact]
    public void RetriveMenuItemsByID_ShouldReturnCorrectID_True()
    {
        var menuItem3 = new MenuItem("Fries", "A simple side that pairs well with a Burger", new List<Ingredient> {_ingredient}, 3.15m);
        _menuItemRepo.AddMenuItemToDatabase(menuItem3);
        var menuItem = _menuItemRepo.GetMenuItemByID(2);
        var actual = menuItem.ID;
        var expected=2;
        Assert.Equal(expected,actual);
    }
    [Fact]
    public void DeleteMenutItem_ShouldReturn_True()
    {
        var oldMenuItem = _menuItem.ID;
        var expected = _menuItemRepo.DeleteMenuItemFromDatabase(oldMenuItem);
        Assert.True(expected);
    }
}