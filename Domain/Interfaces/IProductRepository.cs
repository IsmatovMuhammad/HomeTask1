using Domain.Models;

namespace Domain.Interfaces;

public interface IProductRepository
{
    Task AddProduct(Product product);
    Task UpdateProduct(Product product);
    Task DeleteProduct(int id);
    Task<List<Product>> GetProducts();
    Task<Product> GetProduct(int id);
    Task<Product> GetProductsByCategory(int categoryId);
    Task<int> GetAmountOfProducts();
    Task<int> GetAmountOfProductsByCategory(int categoryId);
    Task<int> GetMinPriceOfProductByCategory(int categoryId);
    Task<int> GetMaxPriceOfProductByCategory(int categoryId);
    Task<int> GetAveragePriceOfProductByCategory(int categoryId);
    Task<int> GetTotalPriceOfProducts();
}
