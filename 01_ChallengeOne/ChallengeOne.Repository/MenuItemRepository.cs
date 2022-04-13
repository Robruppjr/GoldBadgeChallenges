using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public class MenuItemRepository
    {
        private readonly List<MenuItem> _menuItemDatabase = new List<MenuItem>();
        private int _count;
        public bool AddMenuItemToDatabase(MenuItem menuItem)
        {
            if(menuItem != null)
            {
            _count++;
            menuItem.ID =_count;
            _menuItemDatabase.Add(menuItem);
            return true;
            }
            else
            {
                return false;
            }
        }
        public List<MenuItem> GetAllMenuItems()
        {
            return _menuItemDatabase;
        }
        public MenuItem GetMenuItemByID(int id)
        {
            foreach (var menuItem in _menuItemDatabase)
            {
                if(menuItem.ID == id)
                {
                    return menuItem;
                }
            }
            return null;
        }
        public bool DeleteMenuItemFromDatabase(int id)
        {
            var menuItem = GetMenuItemByID(id);
            if(menuItem != null)
            {
                _menuItemDatabase.Remove(menuItem);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
