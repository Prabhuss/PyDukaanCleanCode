using PyConsumerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PyConsumerApp.DataService
{
   public interface ICartDataService
    {
        Task<List<UserCart>> GetCartItemAsync();
        Task<List<UserCart>> GetOrderedItemsAsync();
        //Task<List<UserCart>> GetCartItemAsync(int userId);
        //Task<List<UserCart>> GetOrderedItemsAsync(int userId);
        //Task<Status> RemoveCartItemAsync(int userId, int productId);
        //Task<Status> AddCartItemAsync(int userId, int productId);
        //Task<Status> UpdateQuantityAsync(int userId, int productId, int quantity);
        //Task<Status> RemoveCartItemsAsync(int userId);
    }
}
