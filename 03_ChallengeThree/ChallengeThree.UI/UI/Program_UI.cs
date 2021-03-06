using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public class Program_UI
    {
        private readonly BadgeRepository _badgeRepo;
        private readonly DoorRepository _doorRepo = new DoorRepository();
        public Program_UI()
        {
            _badgeRepo = new BadgeRepository(_doorRepo);
        }
        public void Run()
        {
            SeedData();
            RunApplication();
        }
        private void RunApplication()
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.Clear();
                System.Console.WriteLine("=== Komodo Insurance Badge Menu ===");
                System.Console.WriteLine("Hello Security Admin, What would you like to do? \n" +
                "1.Add a badge\n" +
                "2.Edit a Badge\n" +
                "3. List All Badges\n" +
                "00. Close Appilication\n"
                );
                var userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditABadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "00":
                        isRunning = CloseApplication();
                        break;
                    default:
                        System.Console.WriteLine("Incalid Selection. Please Try Again.");
                        PressAnyKeyToContinue();
                        break;
                }
            }
        }
    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    private bool CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Thank you.");
        PressAnyKeyToContinue();
        return false;
    }
    private void ListAllBadges()
    {
        Console.Clear();
        var badges = _badgeRepo.GetBadges();
        foreach (var badge in badges)
        {
            DisplayBadges(badge);
        }
        PressAnyKeyToContinue();
    }
    private void DisplayBadges(KeyValuePair<int, Badge> badge)
    {
        System.Console.WriteLine
        (
            $"Badge #" + "   " +$"{badge.Key}\n" +
            "Door Access:"
            
        );
            foreach (var door in badge.Value.Doors)
            {
                System.Console.WriteLine(door.Name);
            }
    }
    private void EditABadge()
    {
        Console.Clear();
        var availBadges = _badgeRepo.GetBadges();
        foreach (var badge in availBadges)
        {
            DisplayBadges(badge);
        }
        System.Console.WriteLine("What is the badge number to update:");
        var userInputID = int.Parse(Console.ReadLine());
        var userSelectedBadge = _badgeRepo.GetBadgeByID(userInputID);
        if(userSelectedBadge != null)
            {
                Console.Clear();
                var newDoor = new Door();
                System.Console.WriteLine("Would you like to add or remove a door?");
                var userInputAddRemove = Console.ReadLine();
                if (userInputAddRemove == "ADD".ToLower())
                {
                    System.Console.WriteLine("List a door that it needs access to:");
                    newDoor.Name = Console.ReadLine();
                    var addedDoor = _doorRepo.AddDoorToTheDatabase(newDoor);
                    userSelectedBadge.Doors.Add(newDoor);
                    bool hasAssignedDoors = false;
                    while(!hasAssignedDoors)
                    {
                        System.Console.WriteLine("Any Other Doors? y/n");
                        var userInputHasAnotherDoor = Console.ReadLine();
                        if(userInputHasAnotherDoor == "Y".ToLower())
                        {
                            var userNewDoor = new Door();
                            System.Console.WriteLine("List a door that it needs access to:");
                            userNewDoor.Name = Console.ReadLine();
                            var selectedDoor = _doorRepo.AddDoorToTheDatabase(userNewDoor);
                            userSelectedBadge.Doors.Add(userNewDoor);
                        }
                        else
                        {
                            hasAssignedDoors = true;
                        }
                    }
                }
                if(userInputAddRemove == "REMOVE".ToLower())
                {
                    Console.Clear();
                    foreach(var door in userSelectedBadge.Doors)
                    {
                        DisplayDoors(door);
                    }
                    System.Console.WriteLine("Please list a door that needs to be removed:");
                    var userInputRemove = Console.ReadLine();
                    var selectedDoorRemove = _doorRepo.GetDoorByName(userInputRemove);
                    userSelectedBadge.Doors.Remove(selectedDoorRemove);
                    bool hasAssignedDoors = false;
                    while(!hasAssignedDoors)
                    {
                        System.Console.WriteLine("Any Other Doors? y/n");
                        var userInputHasAnotherDoor = Console.ReadLine();
                        if(userInputHasAnotherDoor == "Y".ToLower())
                        {
                            var userNewDoorRemove = new Door();
                            System.Console.WriteLine("List a door that it needs to be removed:");
                            var userInputRemove2 = Console.ReadLine();
                            var selectedDoorRemove2 = _doorRepo.GetDoorByName(userInputRemove2);
                            userSelectedBadge.Doors.Remove(selectedDoorRemove2);
                        }
                        else
                        {
                            hasAssignedDoors = true;
                        }
                }
            }
            else
            {
                System.Console.WriteLine("Sorry this Badge does not exist.");
            }
                PressAnyKeyToContinue();
        }
    }
    private void DisplayDoors(Door door)
    {
        System.Console.WriteLine($"{door.Name}");
    }
    private void DisplayBadgeDetails(Badge selectedBadge)
    {
        foreach (var door in selectedBadge.Doors)
            {
                System.Console.WriteLine(door.Name);
            }
    }
    private void AddABadge()
    {
        Console.Clear();
        var newBadge = new Badge();
        var newDoor = new Door();
        System.Console.WriteLine("What is the number on the badge: \n");
        newBadge.BadgeID = int.Parse(Console.ReadLine());
        System.Console.WriteLine("List a Door that it needs access to: \n");
        newDoor.Name = Console.ReadLine();
        _doorRepo.AddDoorToTheDatabase(newDoor);
        newBadge.Doors.Add(newDoor);
        bool hasAssignedDoors = false;
        while(!hasAssignedDoors)
        {
            System.Console.WriteLine("Any other Doors? (y/n)");
            var userInputAddDoor = Console.ReadLine();
            if (userInputAddDoor == "Y".ToLower())
            {
                var addNewDoor = new Door();
                System.Console.WriteLine("List a Door that it needs access to: \n");
                addNewDoor.Name = Console.ReadLine();
                _doorRepo.AddDoorToTheDatabase(addNewDoor);
                newBadge.Doors.Add(addNewDoor);
            }
            else 
            {
                hasAssignedDoors = true;
            }
        }
        bool isSuccessful = _badgeRepo.AddBadgeToDB(newBadge);
        if (isSuccessful)
        {
            System.Console.WriteLine($"Badge: {newBadge.BadgeID} was added to the Database.");
        }
        PressAnyKeyToContinue();
    }
    private void SeedData()
        {
            var door = new Door("A7");
            var door1 = new Door("A1");
            var door2 = new Door("A4");
            var door3 = new Door("B1");
            var door4 = new Door("B2");
            var door5 = new Door("A5");
            _doorRepo.AddDoorToTheDatabase(door);
            _doorRepo.AddDoorToTheDatabase(door1);
            _doorRepo.AddDoorToTheDatabase(door2);
            _doorRepo.AddDoorToTheDatabase(door3);
            _doorRepo.AddDoorToTheDatabase(door4);
            _doorRepo.AddDoorToTheDatabase(door5);
            var badge = new Badge (new List<Door>{door});
            var badge1 = new Badge (new List<Door>{door1,door2,door3,door4});
            var badge3 = new Badge (new List<Door>{door2,door5}); 
            _badgeRepo.AddBadgeToDB(badge);
            _badgeRepo.AddBadgeToDB(badge1);
            _badgeRepo.AddBadgeToDB(badge3);
        }
    }
