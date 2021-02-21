using Microsoft.AspNetCore.Mvc;
using Shop.Product.Application.Services.Manager;
using Shop.Product.Application.Services.Manager.ProductAttributes;
using Shop.Product.Application.Services.Manager.ProductAttributes.Dtos;
using Shop.Product.Domain.Entities;
using Utility.Response;

namespace Shop.Product.Api.Manager
{

    [Route("api/v{version:apiVersion}/admin/product_attribute")]
    [ApiController]
    [ApiVersion("1.0")]
    [ProducesResponseType(typeof(IResponseApi), 200)]
    public class ProductAttributeController : BaseController<BaseAppService<ProductAttribueEntity, CreateProductAttributeInput, UpdateProductAttributeInput, ProductAttributeInput, ProductAttributeOutput>,
   ProductAttribueEntity, CreateProductAttributeInput, UpdateProductAttributeInput, ProductAttributeInput, ProductAttributeOutput>
    {
        public ProductAttributeController(ProductAttributeAppService service) : base(service)
        {

        }

    }
}
