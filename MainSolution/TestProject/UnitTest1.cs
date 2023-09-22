using Core;
using Core.Discounts;

namespace TestProject
{
    public class Tests
    {
        /// <summary>
        /// Verifies the total price of all products in the cart with 1% off discount
        /// </summary>
        [Test]
        [Category("Shopping Cart")]
        public void ShoppingCartCalculateTotal_Discount1()
        {
            Product[] products =
            {
                new Product {Name ="Milk", Price = 3, ProductID = 1},
                new Product {Name = "Bread", Price = 5, ProductID = 2},
                new Product {Name = "Eggs", Price = 8, ProductID = 3}
            };

            ShoppingCart cart = new ShoppingCart(new Discount_1(), new ValueCalculator()) { Products = products };

            var actualResult = cart.CalculateTotal();
            var expectedResult = (decimal)15.84;

            Assert.That(actualResult, Is.EqualTo(expectedResult), "Calculated total amount is not correct!");
        }

        /// <summary>
        /// Verifies the total price of all products in the cart with 5% off discount
        /// </summary>
        [Test]
        [Category("Shopping Cart")]
        public void ShoppingCartCalculateTotal_Discount5()
        {
            Product[] products =
            {
                new Product {Name ="Milk", Price = 3, ProductID = 1},
                new Product {Name = "Bread", Price = 5, ProductID = 2},
                new Product {Name = "Eggs", Price = 8, ProductID = 3}
            };

            ShoppingCart cart = new ShoppingCart(new Discount_5(), new ValueCalculator()) { Products = products };

            var actualResult = cart.CalculateTotal();
            var expectedResult = (decimal)15.2;

            Assert.That(actualResult, Is.EqualTo(expectedResult), "Calculated total amount is not correct!");
        }

        /// <summary>
        /// Verifies the total price of all products
        /// </summary>
        [Test]
        [Category("Value Calculator")]
        public void ValueCalculatorCalculateTotal()
        {
            Product[] products =
            {
                new Product {Name ="Milk", Price = 3, ProductID = 1},
                new Product {Name = "Bread", Price = 5, ProductID = 2},
                new Product {Name = "Eggs", Price = 8, ProductID = 3}
            };

            ValueCalculator calculator = new ValueCalculator();
            var actualResult = calculator.ValueCalc(products);
            var expectedResult = (decimal)16;

            Assert.That(actualResult, Is.EqualTo(expectedResult), "Calculated total amount is not correct!");
        }

        /// <summary>
        /// Verifies the amount with 1% off discount 
        /// </summary>
        [Test]
        [Category("Discount")]
        public void VerifyDiscount_1()
        {
            Discount_1 discount1 = new Discount_1();
            var actualResult = discount1.PercentageValue(10);
            var expectedResult = (decimal)9.9;

            Assert.That(actualResult, Is.EqualTo(expectedResult), "Calculated amount with 1% off discount is not correct!");
        }

        /// <summary>
        /// Verifies the amount with 1% off discount 
        /// </summary>
        [Test]
        [Category("Discount")]
        public void VerifyDiscount_5()
        {
            Discount_5 discount5 = new Discount_5();
            var actualResult = discount5.PercentageValue(50);
            var expectedResult = (decimal)47.5;

            Assert.That(actualResult, Is.EqualTo(expectedResult), "Calculated amount with 1% off discount is not correct!");
        }

        /// <summary>
        /// Verifies Products are equal 
        /// </summary>
        [Test]
        [Category("Product")]
        public void VerifyProductsAreEqual()
        {
            Product milk = new Product { Name = "Milk", Price = 3, ProductID = 1 };
            Product milk2 = new Product { Name = "Milk", Price = 3, ProductID = 1 };
            Product milk3 = milk;

            Assert.IsTrue(milk.Equals(milk2), $"Product {milk.Name} is not equal to product {milk2.Name}!");
            Assert.IsTrue(milk.Equals(milk3), $"Product {milk.Name} is not equal to product {milk3.Name}!");

            //// Current implementation of operator '==' does not allow to verify it
            //Assert.IsTrue(milk == milk2, $"Product {milk.Name} is not equal to product {milk2.Name}!");
        }

        /// <summary>
        /// Verifies Products are not equal 
        /// </summary>
        [Test]
        [Category("Product")]
        public void VerifyProductsNotEqual()
        {
            Product milk = new Product { Name = "Milk", Price = 3, ProductID = 1 };
            Product bread = new Product { Name = "Bread", Price = 5, ProductID = 2 };
            Product eggs = new Product { Name = "Eggs", Price = 8, ProductID = 3 };

            Assert.IsFalse(milk.Equals(bread), $"Product {milk.Name} is equal to product {bread.Name}!");
            Assert.IsFalse(bread.Equals(eggs), $"Product {bread.Name} is equal to product {eggs.Name}!");
            Assert.IsFalse(milk.Equals(eggs), $"Product {milk.Name} is equal to product {eggs.Name}!");

            //// Current implementation of operator '!=' does not allow to verify it
            //Assert.IsTrue(milk != bread, $"Product {milk.Name} is not equal to product {bread.Name}!");
        }

        /// <summary>
        /// Verifies ToString() method of the Product class
        /// </summary>
        [Test]
        [Category("Product")]
        public void VerifyProductsToString()
        {
            Product milk = new Product { Name = "Milk", Price = 3, ProductID = 1 };
            Product bread = new Product { Name = "Bread", Price = 5, ProductID = 2 };
            Product eggs = new Product { Name = "Eggs", Price = 8, ProductID = 3 };

            var expectedMilk = "Product ID: 1, Name: Milk, Price: 3";
            var expectedBread = "Product ID: 2, Name: Bread, Price: 5";
            var expectedEggs = "Product ID: 3, Name: Eggs, Price: 8";

            Assert.That(milk.ToString(), Is.EqualTo(expectedMilk));
            Assert.That(bread.ToString(), Is.EqualTo(expectedBread));
            Assert.That(eggs.ToString(), Is.EqualTo(expectedEggs));
        }
    }
}