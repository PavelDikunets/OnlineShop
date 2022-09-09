
using OnlineShop.WebApp.Models;
using System;
using System.Threading.Tasks;

namespace OnlineShop.WebApp.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
