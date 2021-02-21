using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Domain.Events
{
    public class BuyerStockDomainEvent: INotification
    {
        public BuyerStockDomainEvent(string productId, string spceId, int number)
        {
            ProductId = productId;
            SpceId = spceId;
            Number = number;
        }

        public string ProductId { get;private set; }
        public string SpceId { get; private set; }
        public int Number { get; private set; }


    }
}
