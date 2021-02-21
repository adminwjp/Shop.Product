using Microsoft.AspNetCore.Mvc;
using Shop.Product.Application.Services.Manager.Catalogs;
using Shop.Product.Application.Services.Manager.Catalogs.Dtos;
using Shop.Product.Application.Services.Manager.Dtos;
using Shop.Product.Domain.Entities;
using System.Collections.Generic;
using Utility.Response;

namespace Shop.Product.Api.Manager
{
    [Route("api/v{version:apiVersion}/admin/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ProducesResponseType(typeof(IResponseApi), 200)]
    public class CatalogController : BaseController<CatalogAppService,
        CatalogEntity, CreateCatalogInput, UpdateCatalogInput, CatalogInput, CatalogOutput>
    {
        public CatalogController(CatalogAppService service) : base(service)
        {

        }

        [HttpGet("catalog")]
        public virtual ResponseApi<List<CatalogDto>> FindCatalog()
        {
            var res = service.FindCatalog();
            return ResponseApi<List<CatalogDto>>.CreateSuccess().SetData(res);
        }
    }
}
