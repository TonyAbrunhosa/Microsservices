using Dapper.Contrib.Extensions;

namespace Discount.Domain.Entities
{
    [Table("Coupon")]
    public class Coupon
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
