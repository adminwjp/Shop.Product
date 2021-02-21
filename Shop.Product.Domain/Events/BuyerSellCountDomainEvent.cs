using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Domain.Events
{
    public class BuyerSellCountDomainEvent: INotification
    {
        public BuyerSellCountDomainEvent(string productId, string spceId, int sellCount)
        {
            ProductId = productId;
            SpceId = spceId;
            SellCount = sellCount;
        }

        public string ProductId { get; private set; }
        public string SpceId { get; private set; }
        public int SellCount { get;private set; }
    }
}
