using Catalog.Domain.Contracts.IRepository;
using Catalog.Domain.Entities;
using MongoDB.Driver;
using Shared.ConnectionMongo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private MongoConn _mongoConn;

        public ProductRepository(MongoConn mongoConn)
        {
            _mongoConn = mongoConn;
        }

        public async Task CreateProduct(Product product)
        {
            await _mongoConn.Collection<Product>().InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            DeleteResult deleteResult = await _mongoConn.Collection<Product>().DeleteOneAsync(Builders<Product>.Filter.Eq(x=> x.Id, id));
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _mongoConn.Collection<Product>().Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            return await _mongoConn.Collection<Product>().Find(x => x.Category == categoryName).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            return await _mongoConn.Collection<Product>().Find(x => x.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _mongoConn.Collection<Product>().Find(x=> true).ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            ReplaceOneResult replaceOneResult = await _mongoConn.Collection<Product>().ReplaceOneAsync(x => x.Id == product.Id, product);
            return replaceOneResult.IsAcknowledged && replaceOneResult.ModifiedCount > 0;
        }
    }
}
