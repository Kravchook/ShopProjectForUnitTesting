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
                new Product {ProductID = 1, Name = "Lays", Price = 20},
                new Product {ProductID = 2, Name = "Pringles", Price = 40}
            };

            Discount_1 discount1 = new Discount_1();
            ValueCalculator calculator = new ValueCalculator();

            ShoppingCart cart = new ShoppingCart(discount1, calculator) { Products = products };

            var actualResult = cart.CalculateTotal();
            var expectedResult = (decimal)59.4;

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
                new Product {ProductID = 1, Name = "Lays", Price = 20},
                new Product {ProductID = 2, Name = "Pringles", Price = 40}
            };

            Discount_5 discount5 = new Discount_5();
            ValueCalculator calculator = new ValueCalculator();

            ShoppingCart cart = new ShoppingCart(discount5, calculator) { Products = products };

            var actualResult = cart.CalculateTotal();
            var expectedResult = (decimal)57;

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
                new Product {ProductID = 1, Name = "Lays", Price = 20},
                new Product {ProductID = 2, Name = "Pringles", Price = 40}
            };

            ValueCalculator calculator = new ValueCalculator();
            var actualResult = calculator.ValueCalc(products);
            var expectedResult = (decimal)60;

            Assert.That(actualResult, Is.EqualTo(expectedResult), "Calculated total amount is not correct!");
        }

        /// <summary>
        /// Verifies the amount with 1% off discount 
        /// </summary>
        [Test]
        [Category("Discount")]
        public void VerifyDiscount_1()
        {
            Product[] products =
            {
                new Product {ProductID = 1, Name = "Lays", Price = 20},
                new Product {ProductID = 2, Name = "Pringles", Price = 40}
            };

            Discount_1 discount1 = new Discount_1();

            var actualResult1 = discount1.PercentageValue(products[0].Price);
            var expectedResult1 = (decimal)19.8;

            var actualResult2 = discount1.PercentageValue(products[1].Price);
            var expectedResult2 = (decimal)39.6;

            Assert.Multiple(() =>
            {
                Assert.That(actualResult1, Is.EqualTo(expectedResult1), $"Calculated amount with 1% off discount for product {products[0].Name} is not correct!");
                Assert.That(actualResult2, Is.EqualTo(expectedResult2), $"Calculated amount with 1% off discount for product {products[1].Name} is not correct!");
            });
        }

        /// <summary>
        /// Verifies the amount with 5% off discount 
        /// </summary>
        [Test]
        [Category("Discount")]
        public void VerifyDiscount_5()
        {
            Product[] products =
            {
                new Product {ProductID = 1, Name = "Lays", Price = 20},
                new Product {ProductID = 2, Name = "Pringles", Price = 40}
            };

            Discount_5 discount5 = new Discount_5();

            var actualResult1 = discount5.PercentageValue(products[0].Price);
            var expectedResult1 = (decimal)19;

            var actualResult2 = discount5.PercentageValue(products[1].Price);
            var expectedResult2 = (decimal)38;

            Assert.Multiple(() =>
            {
                Assert.That(actualResult1, Is.EqualTo(expectedResult1), $"Calculated amount with 5% off discount for product {products[0].Name} is not correct!");
                Assert.That(actualResult2, Is.EqualTo(expectedResult2), $"Calculated amount with 5% off discount for product {products[1].Name} is not correct!");
            });
        }

        /// <summary>
        /// Verifies products are equal 
        /// </summary>
        [Test]
        [Category("Product")]
        public void VerifyProductsAreEqual_EqualsMethod()
        {
            Product[] products =
            {
                new Product {ProductID = 1, Name = "Lays", Price = 20},
                new Product {ProductID = 2, Name = "Pringles", Price = 40}
            };

            Assert.Multiple(() =>
            {
                Assert.IsTrue(products[0].Equals(products[0]), $"Product {products[0].Name} is not equal to product {products[0].Name}!");
                Assert.IsTrue(products[1].Equals(products[1]), $"Product {products[1].Name} is not equal to product {products[1].Name}!");
            });
        }

        /// <summary>
        /// Verifies products are not equal 
        /// </summary>
        [Test]
        [Category("Product")]
        public void VerifyProductsNotEqual_EqualsMethod()
        {
            Product[] products =
            {
                new Product {ProductID = 1, Name = "Lays", Price = 20},
                new Product {ProductID = 2, Name = "Pringles", Price = 40}
            };

            Assert.IsFalse(products[0].Equals(products[1]), $"Product {products[0].Name} is equal to product {products[1].Name}!");
        }

        /// <summary>
        /// Verifies products are equal 
        /// </summary>
        [Test]
        [Category("Product")]
        public void VerifyProductsAreEqual_ByOperator()
        {
            Product[] products =
            {
                new Product {ProductID = 1, Name = "Lays", Price = 20},
                new Product {ProductID = 2, Name = "Pringles", Price = 40}
            };

            // NOTE: Current implementation of operator '==' does not allow to verify it
            // Test run will be aborted because of recursive loop
            Assert.Multiple(() =>
            {
                Assert.IsTrue(products[0] == products[0], $"Product {products[0].Name} is not equal to product {products[0].Name}!");
                Assert.IsTrue(products[1] == products[1], $"Product {products[1].Name} is not equal to product {products[1].Name}!");
            });
        }

        /// <summary>
        /// Verifies products are not equal 
        /// </summary>
        [Test]
        [Category("Product")]
        public void VerifyProductsNotEqual_ByOperator()
        {
            Product[] products =
            {
                new Product {ProductID = 1, Name = "Lays", Price = 20},
                new Product {ProductID = 2, Name = "Pringles", Price = 40}
            };

            // NOTE: Current implementation of operator '==' does not allow to verify it
            // Test run will be aborted because of recursive loop
            Assert.IsTrue(products[0] != products[1], $"Product {products[0].Name} is equal to product {products[1].Name}!");
        }

        /// <summary>
        /// Verifies ToString() method of the Product class
        /// </summary>
        [Test]
        [Category("Product")]
        public void VerifyProducts_ToStringMethod()
        {
            Product[] products =
            {
                new Product {ProductID = 1, Name = "Lays", Price = 20},
                new Product {ProductID = 2, Name = "Pringles", Price = 40}
            };

            var expectedResult1 = "Product ID: 1, Name: Lays, Price: 20";
            var expectedResult2 = "Product ID: 2, Name: Pringles, Price: 40";

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedResult1, products[0].ToString());
                Assert.AreEqual(expectedResult2, products[1].ToString());
            });
        }
    }
}