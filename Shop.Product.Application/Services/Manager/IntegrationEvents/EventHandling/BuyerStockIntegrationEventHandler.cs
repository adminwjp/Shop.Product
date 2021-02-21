using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Product.Application.Services.Manager.Commands;
using Shop.Product.Application.Services.Manager.IntegrationEvents.Events;

namespace Shop.Product.Application.Services.Manager.IntegrationEvents.EventHandling
{
    public class BuyerStockIntegrationEventHandler : BaseIntegrationEventHandler<BuyerStockIntegrationEventHandler, BuyerStockIntegrationEvent,
        BuyerStockCommand>
    {

        public BuyerStockIntegrationEventHandler(
            IMediator mediator,
            ILogger<BuyerStockIntegrationEventHandler> logger) : base(mediator, logger)
        {

        }
    }
}
