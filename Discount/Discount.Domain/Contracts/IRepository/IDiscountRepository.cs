using Discount.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Discount.Domain.Contracts.IRepository
{
    public interface IDiscountRepository: IDisposable
    {
        Task<Coupon> GetDiscount(string productName);
        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(string productName);
    }
}
