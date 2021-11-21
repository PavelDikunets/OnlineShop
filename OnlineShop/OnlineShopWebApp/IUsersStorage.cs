using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IUsersStorage
    {
        void Add(UserAccount user);
        List<UserAccount> GetAll();
        UserAccount TryGetById(Guid userId);
        UserAccount TryGetByName(string name);
    }
}