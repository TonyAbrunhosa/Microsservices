using Basket.Domain.Contracts.IRepository;
using Basket.Domain.Contracts.IService;
using Basket.Domain.Entities;
using Shared.Base.Contracts;
using Shared.Base.Entity;
using System.Threading.Tasks;

namespace Basket.Application.Service
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<ICommandResult> DeleteBasket(string userName)
        {
            await _basketRepository.DeleteBasket(userName);
            return new CommandResult(true, "Success");
        }

        public async Task<ICommandResult> GetBasket(string userName)
        {
            return new CommandResult(true, "Success", await _basketRepository.GetBasket(userName));
        }

        public async Task<ICommandResult> UpdateBasket(ShoppingCart basket)
        {
            await _basketRepository.UpdateBasket(basket);
            return new CommandResult(true, "Success", await _basketRepository.GetBasket(basket.UserName));
        }
    }
}
