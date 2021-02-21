using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Manager.Commands
{
    public class BuyerSellCountCommand : BaseCommand
    {
        public BuyerSellCountCommand() : base()
        {

        }
        public BuyerSellCountCommand(string productId, string spceId, int number) :base(productId,spceId,number)
        {
        }
    }
}
