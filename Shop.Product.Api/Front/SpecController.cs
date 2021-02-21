using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.Response;

namespace Shop.Product.Api.Front
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ProducesResponseType(typeof(ResponseApi), 200)]
    public class SpecController: ControllerBase
    {
    }
}
