using Microsoft.AspNetCore.Mvc;
using Shop.Product.Application.Services.Manager;
using Shop.Product.Application.Services.Manager.CatalogAttributes;
using Shop.Product.Application.Services.Manager.CatalogAttributes.Dtos;
using Shop.Product.Domain.Entities;
using Utility.Response;

namespace Shop.Product.Api.Manager
{
    [Route("api/v{version:apiVersion}/admin/catalog_attribute")]
    [ApiController]
    [ApiVersion("1.0")]
    [ProducesResponseType(typeof(IResponseApi), 200)]
    public class CatalogAttributeController : BaseController<BaseAppService<CatalogAttribueEntity, CreateCatalogAttributeInput, UpdateCatalogAttributeInput,
        CatalogAttributeInput, CatalogAttributeOutput>,
        CatalogAttribueEntity, CreateCatalogAttributeInput, UpdateCatalogAttributeInput, CatalogAttributeInput, CatalogAttributeOutput>
    {
        public CatalogAttributeController(CatalogAttributeAppService service) : base(service)
        {

        }

    }
}
