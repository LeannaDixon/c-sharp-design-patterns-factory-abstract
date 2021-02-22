using Factory_Pattern_First_Look.Business.Models.Commerce;

namespace Factory_Pattern_First_Look.Business.Models.Shipping.Factories
{
    public class ExpressShippingProvider : ShippingProvider
    {
        public override string GenerateShippingLabelFor(Order order)
        {
            return "EXPRESS";
        }
    }
}