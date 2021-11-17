using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IUsersStorage
    {
        void Add(UserRegistrationInfo user);
        List<UserRegistrationInfo> GetAll();
        UserRegistrationInfo TryGetById(Guid userId);
    }
}