using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class InMemoryUsersStorage : IUsersStorage
    {
        private readonly List<UserAccount> users = new List<UserAccount>();
        public void Add(UserAccount userAccount)
        {
            users.Add(userAccount);
        }
        public List<UserAccount> GetAll()
        {
            return users;
        }
        public void Edit(UserAccount editedAccount)
        {
            var userAccount = TryGetById(editedAccount.Id);
            users.Remove(userAccount);
            users.Add(editedAccount);
        }
        public UserAccount TryGetById(int userId)
        {
            return users.FirstOrDefault(x => x.Id == userId);
        }
        public UserAccount TryGetByName(string login)
        {
            return users.FirstOrDefault(x => x.Login == login);
        }
        public void Remove(UserAccount userAccount)
        {
            users.Remove(userAccount);
        }
        public void ChangePassword(string login, string newPassword)
        {
            var userAccount = TryGetByName(login);
            userAccount.Password = newPassword;
        }
    }
}