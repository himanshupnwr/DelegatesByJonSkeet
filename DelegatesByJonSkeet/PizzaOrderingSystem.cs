using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesByJonSkeet
{
    internal class PizzaOrderingSystem
    {
        readonly DiscountPolicy discountPolicy;

        public PizzaOrderingSystem(DiscountPolicy discountPolicy)
        {
            this.discountPolicy = discountPolicy;
        }

        public decimal ComputePrice(PizzaOrder order)
        {
            decimal nonDiscounted = order.Pizzas.Sum(p => p.Price);
            decimal discountValue = discountPolicy(order);

            return nonDiscounted - discountValue;
        }

    }
}
