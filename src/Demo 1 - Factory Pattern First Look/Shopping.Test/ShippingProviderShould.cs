using AutoFixture;
using Factory_Pattern_First_Look.Business;
using Factory_Pattern_First_Look.Business.Models.Commerce;
using Factory_Pattern_First_Look.Business.Models.Shipping;
using Factory_Pattern_First_Look.Business.Models.Shipping.Factories;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;

namespace Shopping.Test
{
    public class ShippingProviderShould
    {
        private Mock<ShoppingCart> ShoppingCart { get; set; }
        private Mock<Order> Order { get; set; }

        [SetUp]
        public void Setup()
        {
            Order = new Mock<Order>();
            ShoppingCart = new Mock<ShoppingCart>(Order);
            
        }

        [Test]
        [TestCase("Australia", "AUS-")]
        public void CreatesTheExpectedShippingLabel(string specificCountry, string expectedCountryCode)
        {
            var fixture = new Fixture();

            fixture.Customize<Address>(address =>
            address.With(a => a.Country, specificCountry));
            var newOrder = fixture.Create<Order>();
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

            var shoppingCart = new ShoppingCart(newOrder, new StandardShippingProviderFactory());
            var shippingLabel = shoppingCart.Finalize();

            shippingLabel.Should().Contain(expectedCountryCode);

        }
    }

    
}