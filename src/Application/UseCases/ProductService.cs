using Core.Entities;
using Core.Interfaces;

namespace Application.UseCases;

public class ProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public Task<List<Product>> GetAllAsync() => _repo.GetAllAsync();

    public Task<Product?> GetByIdAsync(Guid id) => _repo.GetByIdAsync(id);

    public async Task<Product> AddAsync(Product product)
    {
        await _repo.AddAsync(product);
        return product;
    }

    public Task UpdateAsync(Product product) => _repo.UpdateAsync(product);

    public Task DeleteAsync(Guid id) => _repo.DeleteAsync(id);
}
