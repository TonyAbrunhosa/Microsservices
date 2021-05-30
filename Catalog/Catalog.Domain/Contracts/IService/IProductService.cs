using Catalog.Domain.Entities;
using Shared.Base.Contracts;
using System.Threading.Tasks;

namespace Catalog.Domain.Contracts.IService
{
    public interface IProductService
    {
        Task<ICommandResult> GetProducts();
        Task<ICommandResult> GetProduct(string id);
        Task<ICommandResult> GetProductByName(string name);
        Task<ICommandResult> GetProductByCategory(string categoryName);
        Task<ICommandResult> CreateProduct(Product product);
        Task<ICommandResult> UpdateProduct(Product product);
        Task<ICommandResult> DeleteProduct(string id);
    }
}
