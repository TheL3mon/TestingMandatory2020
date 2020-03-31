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
        public void RemovePhoneLines_shouldRemoveOnePhoneline_And_UpdatePrice()
        {
            // Arrange
            string[] plist = new string[] { "No phones." };
            Purchase phoneLine_7 = new Purchase(false, 7, plist, 1050);
            Purchase phoneLine_1 = new Purchase(false, 1, plist, 150);
            Purchase phoneLine_8 = new Purchase(false, 8, plist, 1200);

            // Act
           int expectedPrice_900 = phoneLine_7.removePhoneLines();

            int expectedPrice_0 = phoneLine_1.removePhoneLines();

            int expectedPrice_1050 = phoneLine_8.removePhoneLines();

            // Assert
            Assert.AreEqual(900, expectedPrice_900);
        
            Assert.AreEqual(0, expectedPrice_0);
            
            Assert.AreEqual(1050, expectedPrice_1050);


        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemovePhoneLines_ExpectFailure()
        {
            //Arrange
            string[] plist = new string[] { "No phones." };
            Purchase phoneLine_0 = new Purchase(false, 0, plist, 0);

            try
            {
                phoneLine_0.removePhoneLines();
            }
            catch
            {
                throw new ArgumentOutOfRangeException();
            }

        }

        // selectPhone -> Christian
        [TestMethod]
        public void SelectPhone_shouldAddSelectedPhoneToPhoneList_And_UpdatePrice()
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
