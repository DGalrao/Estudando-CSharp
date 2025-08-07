using Application.UseCases;
using Core.Entities;
using Core.Interfaces;
using Moq;
using Xunit;

public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _mockRepo;
    private readonly ProductService _service;

    public ProductServiceTests()
    {
        _mockRepo = new Mock<IProductRepository>();
        _service = new ProductService(_mockRepo.Object);
    }

    [Fact]
    public async Task AddAsync_ShouldAddProduct()
    {
        var product = new Product { Id = Guid.NewGuid(), Name = "Test Product", Price = 10.0m };
        _mockRepo.Setup(repo => repo.AddAsync(product)).ReturnsAsync(product);

        var result = await _service.AddAsync(product);

        Assert.Equal(product, result);
        _mockRepo.Verify(repo => repo.AddAsync(product), Times.Once);
    }
}
