using BasketApp;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BasketTests
{
    [TestFixture]
    public class BasketTests
    {
        private Basket myBasket;
        private Order myOrder;
        private OrderItem ItemA;
        private OrderItem ItemB;
        private OrderItem ItemC;
        private OrderItem ItemD;
        private OrderItem ItemE;

        [SetUp]
        public void Setup()
        {
            ItemA = new OrderItem("A", 1.5m, 1);
            ItemB = new OrderItem("B", 2, 1);
            ItemB.AddDiscount(new Discount(5, 3, true));
            ItemC = new OrderItem("C", 0.75m, 1);
            ItemC.AddDiscount(new Discount(1, 2, false));    
            ItemD = new OrderItem("D", 3, 1);
            ItemD.AddDiscount(new Discount(4.5m, 2, true));
            ItemD.AddDiscount(new Discount(7, 3, true));
            ItemE = new OrderItem("E", 2.4m, 1);
            ItemE.AddDiscount(new Discount(2, 3, false));
        }

        [Test]
        public void TestCase1()
        {
            // Arrange
            var order = new Order();
            ItemA.Quantity = 1;
            order.AddItem(ItemA);
            ItemB.Quantity= 1;
            order.AddItem(ItemB);
            ItemC.Quantity= 1;
            order.AddItem(ItemC);
            ItemD.Quantity = 1;
            order.AddItem(ItemD);
            ItemE.Quantity = 1;
            order.AddItem(ItemE);

            // Act 
            var basket = new Basket(order);
            var acctual = basket.Total;

            // Assert
            Assert.AreEqual(9.65m, acctual);
        }

        [Test]
        public void TestCase2()
        {
            // Arrange
            var order = new Order();
            ItemA.Quantity = 1;
            order.AddItem(ItemA);
            ItemB.Quantity = 1;
            order.AddItem(ItemB);
            ItemB.Quantity = 1;
            order.AddItem(ItemB);
            ItemC.Quantity = 1;
            order.AddItem(ItemC);
            ItemC.Quantity = 1;
            order.AddItem(ItemC);

            // Act 
            var basket = new Basket(order);
            var acctual = basket.Total;

            // Assert
            Assert.AreEqual(6.25, acctual);
        }

        [Test]
        public void TestCase3()
        {
            // Arrange
            var order = new Order();
            ItemB.Quantity = 1;
            order.AddItem(ItemB);
            ItemD.Quantity = 1;
            order.AddItem(ItemD);
            ItemD.Quantity = 1;
            order.AddItem(ItemD);
            ItemB.Quantity = 1;
            order.AddItem(ItemB);
            ItemB.Quantity = 1;
            order.AddItem(ItemB);
            ItemE.Quantity = 1;
            order.AddItem(ItemE);
            ItemE.Quantity = 1;
            order.AddItem(ItemE);

            // Act 
            var basket = new Basket(order);
            var acctual = basket.Total;

            // Assert
            Assert.AreEqual(14.30m, acctual);
        }

        [Test]
        public void TestCase4()
        {
            // Arrange
            var order = new Order();
            ItemD.Quantity = 1;
            order.AddItem(ItemD);
            ItemA.Quantity = 1;
            order.AddItem(ItemA);
            ItemB.Quantity = 1;
            order.AddItem(ItemB);
            ItemB.Quantity = 1;
            order.AddItem(ItemB);
            ItemD.Quantity = 1;
            order.AddItem(ItemD);
            ItemD.Quantity = 1;
            order.AddItem(ItemD);

            // Act 
            var basket = new Basket(order);
            var acctual = basket.Total;

            // Assert
            Assert.AreEqual(12.50m, acctual);
        }

        [Test]
        public void TestCase5()
        {
            // Arrange
            var order = new Order();
            ItemD.Quantity = 1;
            order.AddItem(ItemD);
            ItemC.Quantity = 1;
            order.AddItem(ItemC);
            ItemD.Quantity = 1;
            order.AddItem(ItemD);
            ItemE.Quantity = 1;
            order.AddItem(ItemE);
            ItemE.Quantity = 1;
            order.AddItem(ItemE);
            ItemE.Quantity = 1;
            order.AddItem(ItemE);
            ItemC.Quantity = 1;
            order.AddItem(ItemC);
            ItemC.Quantity = 1;
            order.AddItem(ItemC);
            ItemD.Quantity = 1;
            order.AddItem(ItemD);
            ItemD.Quantity = 1;
            order.AddItem(ItemD);

            // Act 
            var basket = new Basket(order);
            var acctual = basket.Total;

            // Assert
            Assert.AreEqual(13.77m, acctual);
        }
    }
}