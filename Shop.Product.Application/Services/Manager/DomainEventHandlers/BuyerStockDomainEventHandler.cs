using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Utility.Application.IntegrationEvents;
using Shop.Product.Domain.Events;
using Shop.Product.Application.Services.Manager.IntegrationEvents.Events;

namespace Shop.Product.Application.Services.Manager.DomainEventHandlers
{
    /// <summary>
    /// 单向 订阅 存储 数据库(提交库之前 执行双向 订阅事件) 双向 订阅  存储缓存即更新缓存
    /// </summary>
    public class BuyerStockDomainEventHandler: INotificationHandler<BuyerStockDomainEvent>
    {
        private readonly ILoggerFactory _logger;
        private readonly IIntegrationEventService integrationEventService;

        public BuyerStockDomainEventHandler(
            ILoggerFactory logger,
            IIntegrationEventService integrationEventService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.integrationEventService = integrationEventService;
        }

        public async Task Handle(BuyerStockDomainEvent buyerStockDomainEvent, CancellationToken cancellationToken)
        {
            _logger.CreateLogger<BuyerStockDomainEvent>()
                .LogTrace("Product with Id: {ProductId} has been successfully updated to stock {Number} ",
                    buyerStockDomainEvent.ProductId, nameof(buyerStockDomainEvent.Number));

            //更新缓存 删除缓存 没有 从库里查询 暂无实现

            //存储集成事件日志 存不储存无所谓 安全日志
            var buyerStockIntegrationEvent = new BuyerStockIntegrationEvent(buyerStockDomainEvent.ProductId, buyerStockDomainEvent.SpceId, buyerStockDomainEvent.Number);
            await this.integrationEventService.AddAndSaveEventAsync(buyerStockIntegrationEvent);
        }
    }
}
