using System.Collections.Generic;
using Xunit;
public class UnitTest1
{
    private readonly BadgeRepository _badgeRepo;
    private readonly DoorRepository _doorRepo = new DoorRepository();
    public UnitTest1()
    {
        _badgeRepo = new BadgeRepository(_doorRepo);
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
    [Fact]
    public void Test1()
    {

    }
}