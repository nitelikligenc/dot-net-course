using NitelikliGenc.WebAPI.Business.Services.Concrete;
using NitelikliGenc.WebAPI.DataAccess.Repositories;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.Business.Services.Products;

public class ProductService : BaseService<Product>, IProductService
{
    private readonly IGenericRepository<Product> _repository;
    public ProductService(IGenericRepository<Product> repository) : base(repository)
    {
        _repository = repository;
    }
}