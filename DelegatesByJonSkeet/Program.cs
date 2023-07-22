using DelegatesByJonSkeet;

PizzaOrder order = new PizzaOrder();
order.Pizzas = new List<Pizza>();
List<DiscountPolicy> policy = new List<DiscountPolicy>
{
    Policies.BuyOneGetOneFree,
    Policies.FivePercentOffMoreThanFiftyDollars,
    Policies.FiveDollarsOffStuffedCrust
};

BestDiscount bestDiscount = new BestDiscount(policy);
bestDiscount.ComputePolicy(order);

//This is an example of delegates, strategy pattern and composition