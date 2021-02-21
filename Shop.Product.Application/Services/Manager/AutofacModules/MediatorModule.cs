using System.Linq;
using System.Reflection;
using Autofac;
using FluentValidation;
using MediatR;
using Shop.Product.Application.Services.Manager.Commands;
using Shop.Product.Application.Services.Manager.DomainEventHandlers;
using Shop.Product.Application.Services.Manager.Validations;

namespace Shop.Product.Application.Services.Manager.AutofacModules
{
    public class MediatorModule : Utility.Infrastructure.AutofacModules.MediatorModule
    {
        protected override void DefaultLoad(ContainerBuilder builder)
        { 
            // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
            builder.RegisterAssemblyTypes(typeof(BaseCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            // Register the DomainEventHandler classes (they implement INotificationHandler<>) in assembly holding the Domain Events
            builder.RegisterAssemblyTypes(typeof(BuyerStockDomainEventHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(INotificationHandler<>));

            // Register the Command's Validators (Validators based on FluentValidation library)
            builder
                .RegisterAssemblyTypes(typeof(BaseCommandValidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();
            base.DefaultLoad(builder);
        }
    }
}
