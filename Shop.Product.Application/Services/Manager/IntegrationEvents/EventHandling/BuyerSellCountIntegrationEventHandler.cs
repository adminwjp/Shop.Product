using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Product.Application.Services.Manager.Commands;
using Shop.Product.Application.Services.Manager.IntegrationEvents.Events;

namespace Shop.Product.Application.Services.Manager.IntegrationEvents.EventHandling
{
    public class BuyerSellCountIntegrationEventHandler : BaseIntegrationEventHandler<BuyerSellCountIntegrationEventHandler,BuyerSellCountIntegrationEvent,
        BuyerSellCountCommand>
    {

        public BuyerSellCountIntegrationEventHandler(
            IMediator mediator,
            ILogger<BuyerSellCountIntegrationEventHandler> logger):base(mediator, logger)
        {
          
        }
    }
}
