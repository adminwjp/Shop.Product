using MediatR;
using Shop.Product.Domain.Entities;
using Shop.Product.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
//using Utility.Domain.Entities;

namespace Shop.Product.Application.Services.Manager.Commands
{
    public abstract class BaseCommandHandler<CommandHandler, Command> : IRequestHandler<Command, bool>
         where CommandHandler : BaseCommandHandler<CommandHandler, Command>
        where Command:BaseCommand
    {
        [Autofac.Annotation.Autowired]
        protected ProductDbContext ProductDbContext { get; set; }

        /// <summary>
        /// Handler which processes the command when
        /// customer executes cancel order from app
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public virtual async Task<bool> Handle(Command command, CancellationToken cancellationToken)
        {
            if(command.SpceId != null)
            {
                return await HandleProcess<SpecEntity>(command,cancellationToken);
            }
            else
            {
                return await HandleProcess<ProductEntity>(command, cancellationToken);
            }
        }
        public virtual async Task<bool> HandleProcess<Entity>(Command command, CancellationToken cancellationToken)
            where Entity:BaseEntity
        {
            var itemToUpdate = await ProductDbContext.Set<Entity>().FindAsync(command.SpceId!=null? command.SpceId: command.ProductId);
            if (itemToUpdate == null)
            {
                return false;
            }
            Update(command,itemToUpdate);
            return await ProductDbContext.SaveEntitiesAsync(cancellationToken);
        }
        protected virtual void Update<Entity>(Command command, Entity entity)
        {

        }
    }
}
