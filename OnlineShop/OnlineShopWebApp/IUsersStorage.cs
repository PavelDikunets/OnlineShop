using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IUsersStorage
    {
        void Add(UserAccount userAccount);
        List<UserAccount> GetAll();
        UserAccount TryGetById(int userId);
        UserAccount TryGetByName(string name);
        void Remove(UserAccount userAccount);
        void Edit(UserAccount editedAccount);
        void ChangePassword(string login, string newPassword);
    }
}