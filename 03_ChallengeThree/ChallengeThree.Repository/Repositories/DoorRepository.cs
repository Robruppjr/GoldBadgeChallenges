using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public class DoorRepository
    {
        private readonly List<Door> _doorDatabase = new List<Door>();
        private int _count;
        public bool AddDoorToTheDatabase(Door door)
        {
            if(door != null)
            {
                _count++;
                door.ID = _count;
                _doorDatabase.Add(door);
                return true;
            }
            return false;
        }
        public List<Door> GetDoors()
        {
            return _doorDatabase;
        }
        public Door GetDoorByName(string name)
        {
            var door = _doorDatabase.SingleOrDefault(d => d.Name == name);
            return door;
        }
        public bool UpdateDoorData(string name, Door newDoorData)
        {
            var oldDoorData = GetDoorByName(name);
            if(oldDoorData != null)
            {
                oldDoorData.Name = newDoorData.Name;
                return true;
            }
            return false;
        }
        public bool RemoveDoor(string name)
        {
            var doorToBeDeleted = _doorDatabase.FirstOrDefault(d => d.Name == name);
            return _doorDatabase.Remove(doorToBeDeleted);
        }
    }