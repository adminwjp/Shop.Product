using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Manager.Commands
{
    public abstract class BaseCommand : IRequest<bool>
    {
        protected BaseCommand()
        {

        }

        protected BaseCommand(string productId, string spceId, int number)
        {
            ProductId = productId;
            SpceId = spceId;
            Number = number;
        }

        [DataMember]
        public string ProductId { get; set; }
        [DataMember]
        public string SpceId { get; set; }
        [DataMember]
        public int Number { get; set; }
    }
}
