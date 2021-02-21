using Shop.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.Domain.Repositories;

namespace Shop.Product.Domain.Repositories
{
    /// <summary>
    /// 产品 规格 仓库
    /// </summary>
   public interface ISpecRepository : IBaseRepository<SpecEntity>
    {
        bool AddSocket(string id, int num);

        bool RemoveSocket(string id, int num);

        bool UpdatePrice(string id, decimal newPrice);
    }
}
