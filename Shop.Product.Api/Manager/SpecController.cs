using Microsoft.AspNetCore.Mvc;
using Shop.Product.Application.Services.Manager.Specs;
using Shop.Product.Application.Services.Manager.Specs.Dtos;
using Shop.Product.Domain.Entities;
using Utility.Response;

namespace Shop.Product.Api.Manager
{
    [Route("api/v{version:apiVersion}/admin/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ProducesResponseType(typeof(IResponseApi), 200)]
    public class SpecController : BaseController<SpecApplicationService, SpecEntity, CreateSpecInput, UpdateSpecInput, SpecInput, SpecOutput>
    {
        public SpecController(SpecApplicationService service):base(service)
        {
            
        }
       
    }
}
