using Microsoft.AspNetCore.Mvc;
using Shop.Product.Application.Services.Front.Catalogs;
using Shop.Product.Application.Services.Front.Catalogs.Dtos;
using System.Collections.Generic;
using Utility.Enums;
using Utility.Response;

namespace Shop.Product.Api.Front
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ProducesResponseType(typeof(IResponseApi), 200)]
    public class CatalogController: ControllerBase
    {
       private readonly  ICatalogAppService service;

        public CatalogController(ICatalogAppService service)
        {
            this.service = service;
        }


        [HttpGet("get")]
        [ProducesResponseType(typeof(ResponseApi<IList<CatalogOutput>>), 200)]
        public virtual ResponseApi<IList<CatalogOutput>> Bottom()
        {
            var datas = service.Catalogs();
            return ResponseApi<IList<CatalogOutput>>.Create(Language.Chinese,Code.QuerySuccess).SetData(datas);
        }

        [HttpGet("navgation")]
        [ProducesResponseType(typeof(ResponseApi<IList<CatalogOutput>>), 200)]
        public virtual ResponseApi<IList<NavgationOutput>> NavgationCatalogs()
        {
            var datas = service.NavgationCatalogs();
            return ResponseApi<IList<NavgationOutput>>.Create(Language.Chinese, Code.QuerySuccess).SetData(datas);
        }

       
        [ProducesResponseType(typeof(ResponseApi<IList<CatalogOutput>>), 200)]
        [HttpGet("bottom")]
        public virtual ResponseApi<IList<BottomOutput>> Catalogs()
        {
            var datas = service.Bottom();
            return ResponseApi<IList<BottomOutput>>.Create(Language.Chinese, Code.QuerySuccess).SetData(datas);
        }

        [ProducesResponseType(typeof(ResponseApi<IList<CatalogOutput>>), 200)]
        [HttpGet("bottom_link")]
        public virtual ResponseApi<IList<BottomNavgationOutput>> BottomLink()
        {
            var datas = service.BottomLink();
            return ResponseApi<IList<BottomNavgationOutput>>.Create(Language.Chinese, Code.QuerySuccess).SetData(datas);
        }
    }
}
