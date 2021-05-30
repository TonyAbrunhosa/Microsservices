using Basket.Domain.Entities;
using Shared.Base.Contracts;
using System.Threading.Tasks;

namespace Basket.Domain.Contracts.IService
{
    public interface IBasketService
    {
        Task<ICommandResult> GetBasket(string userName);
        Task<ICommandResult> UpdateBasket(ShoppingCart basket);
        Task<ICommandResult> DeleteBasket(string userName);
    }
}
