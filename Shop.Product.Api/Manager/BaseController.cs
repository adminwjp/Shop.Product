using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shop.Product.Application.Services.Manager;
using Utility.Application.Services.Dtos;
using Utility.Domain.Entities;
using Utility.Enums;
using Utility.Response;

namespace Shop.Product.Api.Manager
{
    [Route("api/v{version:apiVersion}/admin/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ProducesResponseType(typeof(IResponseApi), 200)]
    public class BaseController<Service,Entity, CreateInput, UpdateInput, Input, Output> : ControllerBase
        where Service: BaseAppService<Entity, CreateInput, UpdateInput, Input, Output>
        where Entity : Shop.Product.Domain.Entities.BaseEntity, new()
        where CreateInput : class
        where UpdateInput : class
        where Input : class
        where Output : class
    {
        protected Service service;
        public BaseController(Service service)
        {
            this.service = service;
        }

        /// <summary>
        /// 添加 
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        [HttpPost("insert")]
        [ProducesResponseType(typeof(ResponseApi), 200)]
        public virtual ResponseApi Insert([FromBody] CreateInput create)
        {
            int res = service.Insert(create);
            return ResponseApi.Create(Language.Chinese, res > 0 ? Code.AddSuccess : Code.AddFail);
        }

        /// <summary>
        /// 修改 
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        [HttpPost("update")]
        [ProducesResponseType(typeof(ResponseApi), 200)]
        public virtual ResponseApi Update([FromBody] UpdateInput update)
        {
            int res = service.Update(update);
            return ResponseApi.Create(Language.Chinese, res > 0 ? Code.ModifySuccess : Code.ModifyFail);
        }

        [HttpGet("delete/{id}")]
        [ProducesResponseType(typeof(ResponseApi), 200)]
        public virtual ResponseApi Delete(string id)
        {
            service.Delete(id);
            return ResponseApi.Create(Language.Chinese, Code.DeleteSuccess);
        }

        [HttpPost("delete_list")]
        [ProducesResponseType(typeof(ResponseApi), 200)]
        public virtual ResponseApi DeleteList([FromBody] DeleteEntity<string> ids)
        {
            service.Delete(ids.Ids);
            return ResponseApi.Create(Language.Chinese, Code.DeleteSuccess);
        }

        //[HttpPost("find")]
        
        //public virtual ResponseApi<IList<GetOutput>> Find([FromBody] GetInput input)
        //{
        //    var res = service.Find(input);
        //    return ResponseApi<IList<GetOutput>>.Create(Language.Chinese, Code.QuerySuccess).SetData(res);
        //}

        //[HttpPost("find/{page}/{size}")]
        //public virtual ResponseApi<IList<GetOutput>> FindByPage(GetInput input, int page = 1, int size = 10)
        //{
        //    var res = service.FindByPage(input, page, size);
        //    return ResponseApi<IList<GetOutput>>.Create(Language.Chinese, Code.QuerySuccess).SetData(res);
        //}

        [HttpPost("find/{page}/{size}")]
        public virtual ResponseApi<ResultDto<Output>> FindResultDtoByPage(Input input, int page = 1, int size = 10)
        {
            var res = service.FindResultDtoByPage(input, page, size);
            return ResponseApi<ResultDto<Output>>.Create(Language.Chinese, Code.QuerySuccess).SetData(res);
        }

     

        //[HttpPost("count")]
        //[ProducesResponseType(typeof(int), 200)]
        //public virtual int Count(GetInput input)
        //{
        //    int res = service.Count(input);
        //    return res;
        //}
    }
}
