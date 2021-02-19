using AutoFixture;
using Factory_Pattern_First_Look.Business;
using Factory_Pattern_First_Look.Business.Models.Commerce;
using FluentAssertions;
using Moq;
using NUnit.Framework;

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
        [TestCase("Australia")]
        public void CreatesTheExpectedShippingLabel(string country)
        {
            var fixture = new Fixture();
            var sender = fixture
                .Build<Address>()
                .With(x => x.Country, country)
                .Create();

            var recipient = fixture
                .Build<Address>()
                .With(x => x.Country, country)
                .Create();

            var Order = fixture.Build<Order>()
                .With(x => x.Sender, sender)
                .With(x=>x.Recipient, recipient)
                //Do(x => x.Sender = sender)
                .Create();

            var shoppingCart = new ShoppingCart(Order);
            var shippingLabel = shoppingCart.Finalize();

            shippingLabel.Should().Contain("AUS-");
           
            
        }
    }
}