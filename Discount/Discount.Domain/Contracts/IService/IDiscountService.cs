using Discount.Domain.Entities;
using Shared.Base.Contracts;
using System.Threading.Tasks;

namespace Discount.Domain.Contracts.IService
{
    public interface IDiscountService
    {
        Task<ICommandResult> GetDiscount(string productName);
        Task<ICommandResult> CreateDiscount(Coupon coupon);
        Task<ICommandResult> UpdateDiscount(Coupon coupon);
        Task<ICommandResult> DeleteDiscount(string productName);
    }
}
