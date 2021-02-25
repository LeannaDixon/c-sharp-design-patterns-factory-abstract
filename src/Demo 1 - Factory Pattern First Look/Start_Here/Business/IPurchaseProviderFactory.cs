using Factory_Pattern_First_Look.Business.Models.Commerce;
using Factory_Pattern_First_Look.Business.Models.Commerce.Invoice;
using Factory_Pattern_First_Look.Business.Models.Commerce.Summary;
using Factory_Pattern_First_Look.Business.Models.Shipping;
using Factory_Pattern_First_Look.Business.Models.Shipping.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Pattern_First_Look.Business
{
    public interface IPurchaseProviderFactory
    {
        IInvoice CreateInvoice(Order order);
        ISummary CreateSummary(Order order);
        ShippingProvider CreateShippingProvider(Order order);
    }

    public class AustrailiaPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            return new GTSInvoice();
        }

        public ShippingProvider CreateShippingProvider(Order order)
        {
            var shippingProviderFactory = new StandardShippingProviderFactory();
            return shippingProviderFactory.GetShippingProvider(order.Sender.Country);
        }

        public ISummary CreateSummary(Order order)
        {
            return new CVSSummary();
        }
    }
    public class SwedenPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            return new VATInvoice();
        }

        public ShippingProvider CreateShippingProvider(Order order)
        {
            var standardShippingProvider = new StandardShippingProviderFactory();
            var expressShippingProvider = new ExpressShippingProviderFactory();
            if (order.Sender.Country == order.Recipient.Country)
            {
                return expressShippingProvider.GetShippingProvider(order.Sender.Country);
            }
            return standardShippingProvider.GetShippingProvider(order.Sender.Country);
        }

        public ISummary CreateSummary(Order order)
        {
            return new CVSSummary();
        }
    }
}
