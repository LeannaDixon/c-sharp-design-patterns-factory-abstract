using Factory_Pattern_First_Look.Business.Models.Shipping;

namespace Factory_Pattern_First_Look.Business.Models.Shipping.Factories
{
    public class ExpressShippingProviderFactory : ShippingProviderFactory
    {
        protected override ShippingProvider CreateShippingProvider(string country)
        {
            return new ExpressShippingProvider();
        }
    }
}