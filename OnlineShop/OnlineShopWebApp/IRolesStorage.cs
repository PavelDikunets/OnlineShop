using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IRolesStorage
    {
        void Add(Role role);
        List<Role> GetAll();
        Role TryGetByName(string name);
        void Remove(string name);
    }
}