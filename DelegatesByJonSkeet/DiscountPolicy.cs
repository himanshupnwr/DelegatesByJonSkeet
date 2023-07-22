using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesByJonSkeet
{
    public delegate decimal DiscountPolicy(PizzaOrder pizzaOrder);

    public class BestDiscount
    {
        private List<DiscountPolicy> _policies;

        public BestDiscount(List<DiscountPolicy> policies)
        {
            _policies = policies;
        }

        public decimal ComputePolicy(PizzaOrder order)
        {
            return _policies.Max(policy=> policy.Invoke(order));
        }
    }

    public static class Policies
    {
        public static decimal BuyOneGetOneFree(PizzaOrder order)
        {
            var pizzas = order.Pizzas;
            if(pizzas.Count < 2)
            {
                return 0m;
            }
            return pizzas.Min(x => x.Price);
        }

        public static decimal FivePercentOffMoreThanFiftyDollars(PizzaOrder order)
        {
            decimal nonDiscounted = order.Pizzas.Sum(p => p.Price);
            return nonDiscounted >= 50? nonDiscounted * 0.05m : nonDiscounted;
        }

        public static decimal FiveDollarsOffStuffedCrust(PizzaOrder order)
        {
            return order.Pizzas.Sum(p => p.Crust == Crust.Stuffed ? 5m : 0m);
        }

        public static DiscountPolicy CreateBest(params DiscountPolicy[] policies)
        {
            return order => policies.Max(policy => policy.Invoke(order));
        }

        public static DiscountPolicy DiscountAllThePizzas()
        {
            return CreateBest(BuyOneGetOneFree, FivePercentOffMoreThanFiftyDollars, 
                FiveDollarsOffStuffedCrust);
        }
    }
}
