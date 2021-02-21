using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.EventBus.Events;

namespace Shop.Product.Application.Services.Manager.IntegrationEvents.Events
{
    public class BuyerSellCountIntegrationEvent: BaseIntegrationEvent
    {
        public BuyerSellCountIntegrationEvent(string productId, string spceId, int number) : base(productId, spceId,number)
        {
        }
    }
}
