using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();

    public Task<List<Product>> GetAllAsync() => Task.FromResult(_products);

    public Task<Product?> GetByIdAsync(Guid id) =>
        Task.FromResult(_products.FirstOrDefault(p => p.Id == id));

    public Task AddAsync(Product product)
    {
        product.Id = Guid.NewGuid();
        _products.Add(product);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Product product)
    {
        var index = _products.FindIndex(p => p.Id == product.Id);
        if (index >= 0)
            _products[index] = product;

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        _products.RemoveAll(p => p.Id == id);
        return Task.CompletedTask;
    }
}
