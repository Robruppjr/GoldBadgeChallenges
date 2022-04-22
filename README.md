# **GOLD BADGE CHALLENGES** 
## Challenge 1: *Komodo Cafe*

> This is a mock Application for a user intaract with a menu for a resturant. With the intent to change the Menu Items. 
### This Mock Application allows a user to:
1. Add a Menu Item to the Databse. 
    *this will include naming the Menu Item, writing a description, listing the ingredients, and giving the Menu Item a price.* 
2. View All the Items on the Menu. 
    *this will just display the name of the Menu Item*
3. View Menu Items by selecting their ID number.
    *this will allow the user to see the name, description, list of ingredients, and price of the Menu Item*
4. Delete a Item of the Menu.
    *this will allow the user to delete a specific item of off the menu*
5. Close the application
    *This will allow the user to close the application.*

---

## Challenge 2:
Claim has properties:
ClaimID
ClaimType
Description
ClaimAmount
DateOfIncident
DateOfClaim
IsValid

(Claim has to be made within 30 days of incident)
31 is invalid

ClaimType (will be Enum):
Car
Home
Theft

Methods in App:
-Show a Claims agent menu
-Choose a menu Item:
    - see all claims
    -take care of next claim
        -Show Claim details
        -ask if you want to deal with claim now(pull claim off top of queue or go back to the main menu.)
    -enter a new claim
        -ask to enter Claim id
        -claim type
        -claim description
        -amount of damage
        -date of accident
        -date of claim
        -Is claim valid

Overall Goal:
Claim class
Claim Repository 
Test Class for Repository
Program File/UI

## Challenge 3:
Komodo Insurance Badges
Badge Class:
    - BadgeID
    -List of door names for access
Door Class:
    -Name
Badge Repository:
    -Create a Dictionary of Badges
    -Key will be BadgeID
    -Value will be List of Door Names.
Door Repository:
    -Create a List of Doors
    -Doors need to be able to be added 
    -Doors need to be removed
    -Doors need to be Listed (no need for getting single door)
Prograim:
    - Createa a new badge
    -Update doors from an existing badge.
    -show a list with all badge numbers and door access
