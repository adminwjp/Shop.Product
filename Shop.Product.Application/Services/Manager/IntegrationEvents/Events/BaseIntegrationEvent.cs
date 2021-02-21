using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.EventBus.Events;

namespace Shop.Product.Application.Services.Manager.IntegrationEvents.Events
{
    public abstract class BaseIntegrationEvent : IntegrationEvent
    {
        public BaseIntegrationEvent(string productId, string spceId, int number)
        {
            ProductId = productId;
            SpceId = spceId;
            Number = number;
        }

        public string ProductId { get; set; }
        public string SpceId { get; set; }
        public int Number { get; set; }
    }
}
