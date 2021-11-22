using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IUsersStorage
    {
        void Add(UserAccount userAccount);
        List<UserAccount> GetAll();
        UserAccount TryGetById(Guid userId);
        UserAccount TryGetByName(string name);
        void Remove(UserAccount userAccount);
    }
}