using System.Collections.Generic;
using projetApi.Models;
using projetApi.Services;

public class ProductController
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    // GET:
    public IEnumerable<Product> GetProducts()
    {
        return _productService.GetAllProducts();
    }

    // GET: id
    public Product GetProductById(int id)
    {
        return _productService.GetProductById(id);
    }

    // POST:
    public Product CreateProduct(Product product)
    {
        return _productService.CreateProduct(product);
    }

    // PUT:
    public void UpdateProduct(int id, Product product)
    {
        _productService.UpdateProduct(product);
    }

    // DELETE:
    public void DeleteProduct(int id)
    {
        _productService.DeleteProduct(id);
    }
}

