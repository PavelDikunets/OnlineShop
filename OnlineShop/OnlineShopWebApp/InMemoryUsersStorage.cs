using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class InMemoryUsersStorage : IUsersStorage
    {
        private readonly List<UserRegistrationInfo> users = new List<UserRegistrationInfo>();
        public void Add(UserRegistrationInfo user)
        {
            users.Add(user);
        }

        public List<UserRegistrationInfo> GetAll()
        {
            return users;
        }
        public UserRegistrationInfo TryGetById(Guid userId)
        {
            return users.FirstOrDefault(x => x.Id == userId);
        }
    }
}