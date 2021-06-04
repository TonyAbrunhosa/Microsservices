using Discount.Domain.Contracts.IRepository;
using Discount.Domain.Contracts.IService;
using Discount.Domain.Entities;
using Shared.Base.Contracts;
using Shared.Base.Entity;
using System.Threading.Tasks;

namespace Discount.Application.Service
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountService(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<ICommandResult> CreateDiscount(Coupon coupon)
        {
            return new CommandResult(true, "Success", await _discountRepository.CreateDiscount(coupon));
        }

        public async Task<ICommandResult> DeleteDiscount(string productName)
        {
            return new CommandResult(true, "Success", await _discountRepository.DeleteDiscount(productName));
        }

        public async Task<ICommandResult> GetDiscount(string productName)
        {
            return new CommandResult(true, "Success", await _discountRepository.GetDiscount(productName));
        }

        public async Task<ICommandResult> UpdateDiscount(Coupon coupon)
        {
            return new CommandResult(true, "Success", await _discountRepository.UpdateDiscount(coupon));
        }
    }
}
