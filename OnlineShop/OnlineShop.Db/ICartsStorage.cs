using OnlineShop.Db.Models;
using System.Threading.Tasks;

namespace OnlineShop.Db
{
    public interface ICartsStorage
    {
        Task AddAsync(Product product, string userId);
        Task DecreaseAmountAsync(Product product, string userId);
        Task ClearAsync(string userId);
        Task<Cart> TryGetByUserIdAsync(string userId);
    }
}