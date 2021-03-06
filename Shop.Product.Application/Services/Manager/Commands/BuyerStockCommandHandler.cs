﻿using Shop.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Manager.Commands
{
    public class BuyerStockCommandHandler : BaseCommandHandler<BuyerStockCommandHandler, BuyerStockCommand>
    {
        
        public override async Task<bool> Handle(BuyerStockCommand command, CancellationToken cancellationToken)
        {
            if (command.SpceId != null)
            {
                var itemToUpdate = await ProductDbContext.Set<SpecEntity>().FindAsync(command.SpceId);
                if (itemToUpdate == null)
                {
                    return false;
                }
                itemToUpdate.AddStock(command.Number);//更新规格 库存数量

            }
            var productToUpdate = await ProductDbContext.Set<ProductEntity>().FindAsync(command.ProductId);
            if (productToUpdate == null)
            {
                return false;
            }
            productToUpdate.AddStock(command.Number);//更新规格对应产品 库存数量
            return await ProductDbContext.SaveEntitiesAsync(cancellationToken);//提交库里
        }
    }
}
