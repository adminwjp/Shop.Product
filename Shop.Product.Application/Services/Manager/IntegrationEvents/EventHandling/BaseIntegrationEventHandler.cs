using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using Shop.Product.Application.Services.Manager.Commands;
using Shop.Product.Application.Services.Manager.IntegrationEvents.Events;
using System.Threading.Tasks;
using Utility.EventBus.Abstractions;
using Utility.EventBus.Extensions;

namespace Shop.Product.Application.Services.Manager.IntegrationEvents.EventHandling
{
    public abstract class BaseIntegrationEventHandler<IntegrationEventHandler, IntegrationEvent,Command> : IIntegrationEventHandlerAsync<IntegrationEvent>
        where IntegrationEventHandler: BaseIntegrationEventHandler<IntegrationEventHandler, IntegrationEvent,Command>
        where IntegrationEvent: BaseIntegrationEvent
        where Command: BaseCommand,new()
    {
        private readonly IMediator _mediator;
        private readonly ILogger<IntegrationEventHandler> _logger;

        public BaseIntegrationEventHandler(
            IMediator mediator,
            ILogger<IntegrationEventHandler> logger)
        {
            _mediator = mediator;
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Event handler which confirms that the grace period
        /// has been completed and order will not initially be cancelled.
        /// Therefore, the order process continues for validation. 
        /// </summary>
        /// <param name="event">       
        /// </param>
        /// <returns></returns>
        public async Task HandleAsync(IntegrationEvent @event)
        {
            using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-{ApplicationConstant.AppName}"))
            {
                _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, ApplicationConstant.AppName, @event);
               // var command = new Command(@event.ProductId, @event.SpceId);
                var command = new Command() { ProductId=@event.ProductId,SpceId=@event.SpceId};

                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty},{IdProperty1}: {CommandId},{CommandId1} ({@Command})",
                    command.GetGenericTypeName(),
                    nameof(command.ProductId),
                    command.ProductId,
                    nameof(command.SpceId),
                    command.SpceId,
                    command);

                await _mediator.Send(command);
            }
        }
    }
}
