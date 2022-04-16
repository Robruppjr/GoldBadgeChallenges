using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public class Program_UI
    {
        private readonly BadgeRepository _badgeRepo = new BadgeRepository();
        private readonly DoorRepository _doorRepo = new DoorRepository();
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

    private void DisplayBadges(KeyValuePair<int, List<Door>> badge)
    {
        System.Console.WriteLine
        (
            "Badge #" + "   " + "Door Access\n" +
            $"{badge.Key}" + "   " + $"{badge.Value}\n"
            );
    }

    private void EditABadge()
    {
        throw new NotImplementedException();
    }

    private void AddABadge()
    {
        throw new NotImplementedException();
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
            var badge = new Badge (12345, new List<Door>{door});
            var badge1 = new Badge (22345, new List<Door>{door1,door2,door3,door4});
            var badge3 = new Badge (32345, new List<Door>{door2,door5}); 
            _badgeRepo.AddBadgeToDB(badge);
            _badgeRepo.AddBadgeToDB(badge1);
            _badgeRepo.AddBadgeToDB(badge3);
        }
    }
