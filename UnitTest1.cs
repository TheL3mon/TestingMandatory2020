using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        // includingExcludingInternetConnection -> Patrik
        [TestMethod]
        public void TestMethod1()
        {

        }

        // addPhoneLines -> Patrik
        [TestMethod]
        public void TestMethod2()
        {

        }

        // removePhoneLines -> Christian
        [TestMethod]
        public void TestMethod3()
        {

        }

        // selectPhone -> Christian
        [TestMethod]
        public void TestMethod4()
        {

        }

        // unselectPhone -> Daniel
        [TestMethod]
        public void unselectPhone_RemoveExisting()
        {
            // Arrange
            string[] phonesList = new string[] { "iPhone 99", "Samsung Galaxy 99", "Huawei 99" };
            Purchase p = new Purchase(false,0,phonesList,7900);
            int expectedPriceAfterRemoval = 1900;
            int priceWeGot = 0;

            // Act
            priceWeGot = p.unselectPhone("iPhone 99");

            // Assert
            Assert.AreEqual(priceWeGot, expectedPriceAfterRemoval);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void unselectPhone_RemoveInvalidPhone()
        {
            string[] phonesList = new string[] { "iPhone 99", "Samsung Galaxy 99", "Huawei 99" };
            Purchase p = new Purchase(false, 0, phonesList, 7900);

            try
            {
                p.unselectPhone("Sony Xperia 9999999");
            }
            catch (ArgumentException)
            {

                throw new ArgumentException();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void unselectPhone_RemoveNotPurchasedPhone()
        {
            string[] phonesList = new string[] { "iPhone 99", "Samsung Galaxy 99", "Huawei 99" };
            Purchase p = new Purchase(false, 0, phonesList, 7900);

            try
            {
                p.unselectPhone("Sony Xperia 99");
            }
            catch (ArgumentException)
            {

                throw new ArgumentException();
            }
        }

        // checkOut -> Daniel
        [TestMethod]
        public void checkOut_validCheckout()
        {
            // Arrange
            string[] phonesList = new string[] { "iPhone 99", "Samsung Galaxy 99", "Huawei 99" };
            Purchase p = new Purchase(false, 0, phonesList, 7900);
            string expectedMessage = "The total price is: 7900";
            string messageWeGot;

            // Act
            messageWeGot = p.checkOut();

            // Assert
            Assert.AreEqual(messageWeGot, expectedMessage);
        }

        [TestMethod]
        public void checkOut_priceIsZero()
        {
            // Arrange
            string[] phonesList = new string[] { "iPhone 99", "Samsung Galaxy 99", "Huawei 99" };
            Purchase p = new Purchase(false, 0, phonesList, 0);
            string expectedMessage = "Please select at least 1 item before you check out.";
            string messageWeGot;

            // Act
            messageWeGot = p.checkOut();

            // Assert
            Assert.AreEqual(messageWeGot, expectedMessage);
        }
    }
}
