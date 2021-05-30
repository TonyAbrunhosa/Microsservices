using Catalog.Domain.Contracts.IRepository;
using Catalog.Domain.Contracts.IService;
using Catalog.Domain.Entities;
using Shared.Base.Contracts;
using Shared.Base.Entity;
using System.Threading.Tasks;

namespace Catalog.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ICommandResult> CreateProduct(Product product)
        {
            await _productRepository.CreateProduct(product);
            return new CommandResult(true, "Success", await GetProduct(product.Id));
        }

        public async Task<ICommandResult> DeleteProduct(string id)
        {
            if(await _productRepository.DeleteProduct(id))
                return new CommandResult(true, "Success");
            else
                return new CommandResult(false, "Erro ao remover Produto.");
        }

        public async Task<ICommandResult> GetProduct(string id)
        {
            return new CommandResult(true, "Success", await _productRepository.GetProduct(id));
        }

        public async Task<ICommandResult> GetProductByCategory(string categoryName)
        {
            return new CommandResult(true, "Success", await _productRepository.GetProductByCategory(categoryName));
        }

        public async Task<ICommandResult> GetProductByName(string name)
        {
            return new CommandResult(true, "Success", await _productRepository.GetProductByName(name));
        }

        public async Task<ICommandResult> GetProducts()
        {
            return new CommandResult(true, "Success", await _productRepository.GetProducts());
        }

        public async Task<ICommandResult> UpdateProduct(Product product)
        {
            if (await _productRepository.UpdateProduct(product))
                return new CommandResult(true, "Success");
            else
                return new CommandResult(false, "Erro ao atualzar Produto.");
        }
    }
}
