using OnlineShop.WebApp.Areas.Admin.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.WebApp
{
    public class InMemoryRolesStorage : IRolesStorage
    {
        private readonly List<Role> roles = new List<Role>();
        public void Add(Role role)
        {
            roles.Add(role);
        }

        public List<Role> GetAll()
        {
            return roles;
        }

        public Role TryGetByName(string name)
        {
            return roles.FirstOrDefault(x => x.Name == name);
        }

        public void Remove(string roleName)
        {
            roles.RemoveAll(x => x.Name == roleName);
        }
    }
}