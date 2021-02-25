﻿using Factory_Pattern_First_Look.Business.Models.Commerce;
using Factory_Pattern_First_Look.Business.Models.Shipping;
using Factory_Pattern_First_Look.Business.Models.Shipping.Factories;
using System;

namespace Factory_Pattern_First_Look.Business
{
    public class ShoppingCart
    {
        private readonly Order order;
        private readonly IPurchaseProviderFactory purchaseProviderFactory;

        public ShoppingCart(Order order, IPurchaseProviderFactory purchaseProviderFactory)
        {
            this.order = order;
            this.purchaseProviderFactory = purchaseProviderFactory;
        }

        public string Finalize()    
        {
            // Get shipping provider
            var shippingProvider = purchaseProviderFactory.CreateShippingProvider(order);

            // Get invoice
            var invoice = purchaseProviderFactory.CreateInvoice(order);

            // Get summary
            var summary = purchaseProviderFactory.CreateSummary(order);
            summary.Send();     

            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }
}
