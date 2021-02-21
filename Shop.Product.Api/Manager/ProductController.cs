using Microsoft.AspNetCore.Mvc;
using Shop.Product.Application.Services.Manager.Products;
using Shop.Product.Application.Services.Manager.Products.Dtos;
using Shop.Product.Domain.Entities;
using Utility.Response;

namespace Shop.Product.Api.Manager
{
    [Route("api/v{version:apiVersion}/admin/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ProducesResponseType(typeof(IResponseApi), 200)]
    public class ProductController : BaseController<ProductApplicationService, ProductEntity, CreateProductInput, UpdateProductInput,ProductInput, ProductOutput>
    {
        public ProductController(ProductApplicationService service) : base(service)
        {

        }
      
    }
}
