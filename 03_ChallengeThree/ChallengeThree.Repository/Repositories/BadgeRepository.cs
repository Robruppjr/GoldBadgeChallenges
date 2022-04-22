using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public class BadgeRepository
    {
        private readonly Dictionary<int, Badge> _badgeDB = new Dictionary<int, Badge>(); 
        private readonly DoorRepository _dRepo;
        private int _count = 0;
        public BadgeRepository(DoorRepository dRepo)
        {
            _dRepo = new DoorRepository();
        }
        public bool AddBadgeToDB(Badge badge)
        {
            if(badge is null)
            {
                return false;
            }
            _count++;
            badge.BadgeID = _count;
            _badgeDB.Add(badge.BadgeID, badge);
            return true;
        }
        public Dictionary<int, Badge> GetBadges()
        {
            return _badgeDB;
        }
        public Badge GetBadgeByKey(int userKeyInput)
        {
            foreach (KeyValuePair<int, Badge> badge in _badgeDB)
            {
                if (badge.Key == userKeyInput)
                {
                    return badge.Value;
                }
                return null;
            }
            return null;
        }
    }