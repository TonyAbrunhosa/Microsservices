using Basket.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Basket.Domain.Contracts.IRepository
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string userName);
        Task UpdateBasket(ShoppingCart basket);
        Task DeleteBasket(string userName);
    }
}
