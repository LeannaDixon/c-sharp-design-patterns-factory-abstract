using AutoFixture;
using Factory_Pattern_First_Look.Business;
using Factory_Pattern_First_Look.Business.Models.Commerce;
using Factory_Pattern_First_Look.Business.Models.Shipping.Factories;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;

namespace Shopping.Test
{
    public class ShippingProviderFactoriesShould
    {
        private Mock<ShoppingCart> ShoppingCart { get; set; }
        private Order NewOrder { get; set; }
        public Fixture Fixture { get; set; }

        [SetUp]
        public void Setup()
        {
            Fixture = new Fixture();

            string specificCountry = "Australia";

            Fixture.Customize<Address>(address =>
                            address.With(a => a.Country, specificCountry));
            NewOrder = Fixture.Create<Order>();
            #region Instead of Customising the Address: Long way.
            //var sender = fixture
            //    .Build<Address>()
            //    .With(x => x.Country, country)
            //    .Create();
            //var recipient = fixture
            //    .Build<Address>()
            //    .With(x => x.Country, country)
            //    .Create();
            //var Order = fixture.Build<Order>()
            //    .With(x => x.Sender, sender)
            //    .With(x=>x.Recipient, recipient)
            //    .Create();
            #endregion
        }

        [Test]
        [TestCase("AUS-")]
        public void CreatesTheExpectedStandardShippingLabel(string expectedCountryCode)
        {
            ShoppingCart = new Mock<ShoppingCart>(NewOrder, new StandardShippingProviderFactory());

            var shippingLabel = ShoppingCart.Object.Finalize();

            shippingLabel.Should().Contain(expectedCountryCode);
        }

        [Test]
        public void CreatesTheExpectedExpressShippingLabel()
        {
            ShoppingCart = new Mock<ShoppingCart>(NewOrder, new ExpressShippingProviderFactory());

            var shippingLabel = ShoppingCart.Object.Finalize();
            var expectedExpressLabel = "EXPRESS";

            shippingLabel.Should().Contain(expectedExpressLabel);
        }

    }
}

