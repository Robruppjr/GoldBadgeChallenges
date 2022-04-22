using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public class Program_UI
    {
        private readonly ClaimRepository _claimRepository = new ClaimRepository();
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
            System.Console.WriteLine("=== Welcome to Komodo Claims Department ===");
            System.Console.WriteLine("Please Make a Selection: \n" +
            "1. Enter a New Claim\n" +
            "2. See All Claims in the Queue\n" +
            "3. Take care of next Claim\n" +
            "00. Close Application\n"
            );
            var userInput = Console.ReadLine();
            switch(userInput)
            {
                case "1":
                    EnterANewClaim();
                    break;
                case "2":
                    SeeAllClaimsInQueue();
                    break;
                case "3":
                    TakeCareOfNextClaim();
                    break;
                case "00":
                    isRunning = CloseApplication();
                    break;
                default:
                    System.Console.WriteLine("Ivalid Selection. Please Try Again.");
                    PressAnyKeyToContinue();
                    break;
            }
        }
    }
    private bool CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Thank you.");
        PressAnyKeyToContinue();
        return false;
    }
    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    private void EnterANewClaim()
    {
        Console.Clear();
        var newClaim = new Claim();
        System.Console.WriteLine("== Claim Addition Menu==\n");
        System.Console.WriteLine("Please enter a new Claim ID number.");
        int userClaimID = int.Parse(Console.ReadLine());
        newClaim.ID = userClaimID;
        System.Console.WriteLine("Please slecte the Claim Type.\n" +
        "1. Car\n" +
        "2. Home\n" +
        "3. Theft\n");
        string ClaimTypeInput = Console.ReadLine();
        int claimTypeID = int.Parse(ClaimTypeInput);
        newClaim.ClaimType = (ClaimType)claimTypeID;            
        System.Console.WriteLine("Please enter a Claim Description:");
        newClaim.Description = Console.ReadLine();
        System.Console.WriteLine("Please enter the total Amount of Damage:");
        newClaim.ClaimAmount = int.Parse(Console.ReadLine());
        System.Console.WriteLine("Please enter a Date of Accident (mm/dd/yyyy): ");
        newClaim.DateOfAccident = DateTime.Parse(Console.ReadLine());
        newClaim.DateOfClaim = DateTime.Now;
        System.Console.WriteLine("The Following Claim has been entered\n" +
        $"ClaimID: {newClaim.ID}\n" +
        $"Claim Type: {newClaim.ClaimType}\n" +
        $"Claim Description: {newClaim.Description}\n" +
        $"Claim Amount: ${newClaim.ClaimAmount}\n" +
        $"Date of Accident: {newClaim.DateOfAccident}\n" +
        $"Date of Claim: {newClaim.DateOfClaim}\n" +
        $"Is Valid: {newClaim.IsValid}");
        PressAnyKeyToContinue();
    }
    private void SeeAllClaimsInQueue()
    {
        Console.Clear();
        var claims = _claimRepository.GetClaims();
        foreach (var claim in claims)
        {
            DisplayClaimsDetails(claim);
        }
        PressAnyKeyToContinue();
    }
    private void TakeCareOfNextClaim()
    {
        System.Console.WriteLine("Here are the details for the next claim to be Handled:");
        var nextClaim = _claimRepository.GetClaim();
        DisplayClaimsDetails(nextClaim);
        System.Console.WriteLine("Do you want to deal with this claim now (y/n) ?");
        string userInput = Console.ReadLine();
        if(userInput == "y")
            {
                _claimRepository.FinishClaim();
                System.Console.WriteLine("This claim has been removed from top of the Queue.");
            }
        else if(userInput == "n")
            {
                System.Console.WriteLine("You will be returned to the claims menu");
            }
        else
            {
                System.Console.WriteLine("Sorry this is an Invalid Option.");
            }
                PressAnyKeyToContinue();
    }
    private void DisplayClaimsDetails(Claim claim)
    {
        System.Console.WriteLine
        (
        $"ClaimID: {claim.ID}\n" +
        $"Claim Type: {claim.ClaimType}\n" +
        $"Claim Description: {claim.Description}\n" +
        $"Claim Amount: ${claim.ClaimAmount}\n" +
        $"Date of Accident: {claim.DateOfAccident}\n" +
        $"Date of Claim: {claim.DateOfClaim}\n" +
        $"Is Valid: {claim.IsValid}"
        );
    }
    private void SeedData()
    {
        var claim1 = new Claim(1, ClaimType.Car, "Car Accident on 465.", 400, new DateTime(04/25/2018), new DateTime(04/27/2018));
        var claim2 = new Claim(2, ClaimType.Home, "House fire in Kitchen", 4000, new DateTime(04/11/18), new DateTime(04/12/18));
        var claim3 = new Claim(3, ClaimType.Theft, "Stolen pancakes.", 4, new DateTime(04/27/18), new DateTime(06/01/18));
        _claimRepository.AddClaimToTheDatabase(claim1);
        _claimRepository.AddClaimToTheDatabase(claim2);
        _claimRepository.AddClaimToTheDatabase(claim3);
    }
    }