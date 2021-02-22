using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Pattern_First_Look.Business.Models.Shipping
{
    public static class ShippingProviderFactory
    {
        public static ShippingProvider CreateShippingProvider(string country)
        {
            #region Create Shipping Provider
            ShippingProvider shippingProvider;

            if (country == "Australia")
            {
                #region Australia Post Shipping Provider
                var shippingCostCalculator = new ShippingCostCalculator(
                    internationalShippingFee: 250,
                    extraWeightFee: 500
                )
                {
                    ShippingType = ShippingType.Standard
                };

                var customsHandlingOptions = new CustomsHandlingOptions
                {
                    TaxOptions = TaxOptions.PrePaid
                };

                var insuranceOptions = new InsuranceOptions
                {
                    ProviderHasInsurance = false,
                    ProviderHasExtendedInsurance = false,
                    ProviderRequiresReturnOnDamange = false
                };

                return shippingProvider = new AustraliaPostShippingProvider("CLIENT_ID",
                    "SECRET",
                    shippingCostCalculator,
                    customsHandlingOptions,
                    insuranceOptions);
                #endregion
            }
            else if (country == "Sweden")
            {
                #region Swedish Postal Service Shipping Provider
                var shippingCostCalculator = new ShippingCostCalculator(
                    internationalShippingFee: 50,
                    extraWeightFee: 100
                )
                {
                    ShippingType = ShippingType.Express
                };

                var customsHandlingOptions = new CustomsHandlingOptions
                {
                    TaxOptions = TaxOptions.PayOnArrival
                };

                var insuranceOptions = new InsuranceOptions
                {
                    ProviderHasInsurance = true,
                    ProviderHasExtendedInsurance = false,
                    ProviderRequiresReturnOnDamange = false
                };

                return shippingProvider = new SwedishPostalServiceShippingProvider("API_KEY",
                    shippingCostCalculator,
                    customsHandlingOptions,
                    insuranceOptions);
                #endregion
            }
            else
            {
                throw new NotSupportedException("No shipping provider found for origin country");
            }
            #endregion
        }
    }
}
