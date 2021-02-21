using MediatR;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Utility.Application.IntegrationEvents;
using Shop.Product.Domain.Events;
using Shop.Product.Application.Services.Manager.IntegrationEvents.Events;

namespace Shop.Product.Application.Services.Manager.DomainEventHandlers
{
    public class BuyerSellCountDomainEventHandler : INotificationHandler<BuyerSellCountDomainEvent>
    {
        private readonly ILoggerFactory _logger;
        private readonly IIntegrationEventService integrationEventService;

        public BuyerSellCountDomainEventHandler(
            ILoggerFactory logger,
            IIntegrationEventService integrationEventService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.integrationEventService = integrationEventService;
        }

        public async Task Handle(BuyerSellCountDomainEvent buyerSellCountDomain, CancellationToken cancellationToken)
        {
            _logger.CreateLogger<BuyerStockDomainEvent>()
                .LogTrace("Product with Id: {ProductId} has been successfully updated to sellCount {SellCount} ",
                    buyerSellCountDomain.ProductId, nameof(buyerSellCountDomain.SellCount));

            //更新缓存 删除缓存 没有 从库里查询 暂无实现

            //存储集成事件日志 存不储存无所谓 安全日志
            var buyerStockIntegrationEvent = new BuyerSellCountIntegrationEvent(buyerSellCountDomain.ProductId, buyerSellCountDomain.SpceId, buyerSellCountDomain.SellCount);
            await this.integrationEventService.AddAndSaveEventAsync(buyerStockIntegrationEvent);
        }
    }
}
