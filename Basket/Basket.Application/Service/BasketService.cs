using Basket.Domain.Contracts.IRepository;
using Basket.Domain.Contracts.IService;
using Basket.Domain.Entities;
using Discount.Grpc.Protos;
using Shared.Base.Contracts;
using Shared.Base.Entity;
using System.Threading.Tasks;

namespace Basket.Application.Service
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoServiceClient;

        public BasketService(IBasketRepository basketRepository, DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
        {
            _basketRepository = basketRepository;
            _discountProtoServiceClient = discountProtoServiceClient;
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
            foreach (var item in basket.Items)
            {
                item.Price -= (await GetDiscount(item.ProductName)).Amount;                
            }

            await _basketRepository.UpdateBasket(basket);
            return new CommandResult(true, "Success", await _basketRepository.GetBasket(basket.UserName));
        }

        private async Task<CouponModel> GetDiscount(string productName)
        {
            return await _discountProtoServiceClient.GetDiscountAsync(new GetDiscountRequest { ProductName = productName });
        }
    }
}
