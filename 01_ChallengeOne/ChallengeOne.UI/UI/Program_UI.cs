using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public class Program_UI
    {
        private readonly MenuItemRepository _menuItemRepository = new MenuItemRepository();
        private readonly IngredientRepo _ingredientRepo = new IngredientRepo();
        public void Run()
        {
            SeedData();
            RunApplication();
        }
    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("== Welcome to Komodo Cafe Menu App ==");
            System.Console.WriteLine("Please Make a Selection: \n" +
            "1. Add Menu Item to Database\n" +
            "2. View Menu\n" +
            "3. View Menu Item\n" +
            "4. Delete Menu Item\n" +
            "00. Close Application\n"
            );
            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddMenuItemToDatabase();
                    break;
                case "2":
                    ViewAllMenuItems();
                    break;
                case "3":
                    ViewMenuItemsByID();
                    break;
                case "4":
                    DeleteMenuItem();
                    break;
                case "00":
                    isRunning = CloseApplication();
                    break;
                default:
                    System.Console.WriteLine("Invalid Selection. Please Try Again.");
                    PressAnyKeyToContinue();
                    break;
            }
        }
    }
    private bool CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Thank you!");
        PressAnyKeyToContinue();
        return false;
    }
    private void DeleteMenuItem()
    {
        Console.Clear();
        System.Console.WriteLine("=== Menu Item Removal Page ===");
        var menuItems = _menuItemRepository.GetAllMenuItems();
        foreach (MenuItem menuItem in menuItems)
        {
            DisplayMenuItemListing(menuItem);
        }
        try
        {
            System.Console.WriteLine("Please select a Menu Item by its ID:");
            var userInputSelected = int.Parse(Console.ReadLine());
            bool isSuccessful = _menuItemRepository.DeleteMenuItemFromDatabase(userInputSelected);
            if(isSuccessful)
                {
                    System.Console.WriteLine("Menu Item WAS SUCCESSFULLY Deleted.");
                }
            else
            {
                System.Console.WriteLine("Menu Item FAILED to be Deleted.");
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry, Invalid Selection.");
        }
    }
    private void DisplayMenuItemListing(MenuItem menuItem)
    {
        System.Console.WriteLine($"Menu Item ID: {menuItem.ID}\n Menu Item Name: {menuItem.Name}\n" +
        "----------------------------------------------\n");
    }
    private void ViewMenuItemsByID()
    {
        Console.Clear();
        System.Console.WriteLine("---Menu Item Details---");
        var menuItems = _menuItemRepository.GetAllMenuItems();
        foreach (var menuItem in menuItems)
        {
            DisplayMenuItemListing(menuItem);
        }
        try
        {
            System.Console.WriteLine("Please Select a Menu Item by it's ID:");
            var userSelectedInput = int.Parse(Console.ReadLine());
            var selectedMenuItem = _menuItemRepository.GetMenuItemByID(userSelectedInput);
            if(selectedMenuItem != null)
            {
                DisplayMenuItemDetails(selectedMenuItem);
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry, Invalid Selection.");
        }
    }
    private void DisplayMenuItemDetails(MenuItem selectedMenuItem)
    {
        Console.Clear();
        System.Console.WriteLine($"Menu Item ID: {selectedMenuItem.ID}\n" + $"Menu Item Name: {selectedMenuItem.Name}\n");
        System.Console.WriteLine("-- Ingredients--");
        if(selectedMenuItem.Ingredients.Count > 0)
        {
            foreach (var ingredient in selectedMenuItem.Ingredients)
            {
                DisplayIngredientInfo(ingredient);
            }
        }
        else
        {
            System.Console.WriteLine("There are no ingredients");
        }
        PressAnyKeyToContinue();
    }
    private void DisplayIngredientInfo(Ingredient ingredient)
    {
        System.Console.WriteLine($"Ingredient Name: {ingredient.Name}\n" + "--------------------------------\n");
    }
    private void ViewAllMenuItems()
    {
        Console.Clear();
        System.Console.WriteLine("=== Komodo Cafe Menu===\n");
        var menuItemsInDb = _menuItemRepository.GetAllMenuItems();
        foreach(var menuItem in menuItemsInDb)
        {
            DisplayMenuItemListing(menuItem);
        }
        PressAnyKeyToContinue();
    }
    private void AddMenuItemToDatabase()
    {
        Console.Clear();
        var newMenuItem = new MenuItem();
        var currentIngredients = _ingredientRepo.GetAllIngredients();
        System.Console.WriteLine("Please enter Menu Item Name:");
        newMenuItem.Name = Console.ReadLine();
        bool hasAssignedIngredients = false;
        while(!hasAssignedIngredients)
        {
            System.Console.WriteLine("Would you like to add ingredients to your Menu Item? y/n");
            var userInputAddIngredients = Console.ReadLine();
            if (userInputAddIngredients == "Y".ToLower())
            {
                foreach (var ingredient in currentIngredients)
                {
                    System.Console.WriteLine($"{ingredient.ID} {ingredient.Name}");
                }
                var userInputIngredienSelection = int.Parse(Console.ReadLine());
                var selectedIngredient = _ingredientRepo.GetIngredintByID(userInputIngredienSelection);
                if(selectedIngredient != null)
                {
                    newMenuItem.Ingredients.Add(selectedIngredient);
                }
                else
                {
                    System.Console.WriteLine($"Sorry there are no ingredients with the ID: {userInputIngredienSelection}.");
                }
            }
            else
            {
                hasAssignedIngredients = true;
            }
        }
        bool isSuccessful = _menuItemRepository.AddMenuItemToDatabase(newMenuItem);
        if(isSuccessful)
        {
            System.Console.WriteLine($"Menu Item: {newMenuItem.Name} was Added to the Database.");
        }
        else
        {
            System.Console.WriteLine("Menu Item Failed to be added to the Database.");
        }
        PressAnyKeyToContinue();
    }
    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    private void SeedData()
    {
        var lettuce = new Ingredient("Lettuce");
        var patty = new Ingredient("Beef Patty");
        var bun = new Ingredient("Bun");
        var potatoes = new Ingredient("Potatoes");
        var salt = new Ingredient("Salt");
        var oliveOil = new Ingredient("Olive Oil");
        var tomato = new Ingredient("Tomato");
        _ingredientRepo.AddIngredientToDatabase(lettuce);
        _ingredientRepo.AddIngredientToDatabase(patty);
        _ingredientRepo.AddIngredientToDatabase(bun);
        _ingredientRepo.AddIngredientToDatabase(potatoes);
        _ingredientRepo.AddIngredientToDatabase(oliveOil);
        _ingredientRepo.AddIngredientToDatabase(tomato);
        _ingredientRepo.AddIngredientToDatabase(salt);
        var burger = new MenuItem("Burger", "A Simple Burger", new List<Ingredient> {lettuce, patty, bun, salt, tomato}, 7.50m);
        var salad = new MenuItem("Salad", "A Simple Salad", new List<Ingredient> {lettuce, salt, oliveOil, tomato}, 5.25m);
        var fries = new MenuItem("French Fries", "A great side to a burger.", new List<Ingredient> {potatoes, oliveOil, salt}, 2.50m);
        _menuItemRepository.AddMenuItemToDatabase(burger);
        _menuItemRepository.AddMenuItemToDatabase(salad);
        _menuItemRepository.AddMenuItemToDatabase(fries);
    }
}
