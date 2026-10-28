using Domain.Models;

namespace Domain.Interfaces;

public interface IProductRepository
{
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int id);
    List<Product> GetProducts();
    Product GetProduct(int id);
    Product GetProductsByCategory(int categoryId);
    int GetAmountOfProducts();
    int GetAmountOfProductsByCategory(int categoryId);
    int GetMinPriceOfProductByCategory(int categoryId);
    int GetMaxPriceOfProductByCategory(int categoryId);
    int GetAveragePriceOfProductByCategory(int categoryId);
    int GetTotalPriceOfProducts();
}
