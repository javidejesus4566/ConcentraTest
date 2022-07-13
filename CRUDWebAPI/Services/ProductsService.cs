namespace CRUDWebAPI.Services;

using AutoMapper;
using CRUDWebAPI.Authorization;
using CRUDWebAPI.Entities;
using CRUDWebAPI.Helpers;
using CRUDWebAPI.Models.Products;

public interface IProductsService
{ 
    IEnumerable<ProductEntity> GetAll();
    ProductEntity GetById(int id);
    void Register(ProductRequest model);
    void Update(int id, UpdateProductRequest model);
    void Delete(int id);
}

public class ProductsService : IProductsService
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;

    public ProductsService(
        DataContext context,
        IJwtUtils jwtUtils,
        IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }


    public IEnumerable<ProductEntity> GetAll()
    {
        return _context.Product;
    }

    public ProductEntity GetById(int id)
    {
        return getProduct(id);
    }

    public void Register(ProductRequest model)
    {
        // validate
        if (_context.Product.Any(x => x.ProductName == model.ProductName))
            throw new AppException("Product Name '" + model.ProductName + "' is already taken");

        // map model to new product object
        var product = _mapper.Map<ProductEntity>(model);


        // save product
        _context.Product.Add(product);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateProductRequest model)
    {
        var product = getProduct(id);

        // validate
        if (model.ProductName != product.ProductName && _context.Product.Any(x => x.ProductName == model.ProductName))
            throw new AppException("Product Name '" + model.ProductName + "' is already taken");

        // copy model to product and save
        _mapper.Map(model, product);
        _context.Product.Update(product);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var product = getProduct(id);
        _context.Product.Remove(product);
        _context.SaveChanges();
    }

    // helper methods

    private ProductEntity getProduct(int id)
    {
        var product = _context.Product.Find(id);
        if (product == null) throw new KeyNotFoundException("Product not found");
        return product;
    }
}