using Dapper;
using Dapper.Contrib.Extensions;
using Discount.Domain.Contracts.IRepository;
using Discount.Domain.Entities;
using Shared.ConnectionNpgSql;
using System.Threading.Tasks;

namespace Discount.Infra.Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly NpgSqlConn _npgSqlConn;

        public DiscountRepository(NpgSqlConn npgSqlConn)
        {
            _npgSqlConn = npgSqlConn;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            var affected = await _npgSqlConn.GetConnection().ExecuteAsync(@"
                INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)", 
                new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

            if (affected == 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            var affected = await _npgSqlConn.GetConnection().ExecuteAsync($@"
                DELETE FROM Coupon WHERE ProductName = '{productName}'");

            return affected > 0;
        }

        public void Dispose()
        {
            _npgSqlConn.Dipose();
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            return await _npgSqlConn.GetConnection().QueryFirstOrDefaultAsync<Coupon>(@$"
                SELECT * FROM Coupon WHERE ProductName = '{productName}'");
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            var affected = await _npgSqlConn.GetConnection().ExecuteAsync(@"
                UPDATE Coupon SET ProductName = @ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id",
                            new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount, Id = coupon.Id });

            if (affected == 0)
                return false;

            return true;
        }
    }
}
