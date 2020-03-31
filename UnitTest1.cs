using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        // includingExcludingInternetConnection -> Patrik
        // CASE1 : Set false from false => Price does not change + InternetConnection is false
        // CASE2 : Set true from false => Price increases by 200 + InternetConnection is true
        // CASE3 : Set false from true => Price decreases by 200 + InternetConnection is false
        // CASE4 : Set true from false => Price does not change +  InternetConnection is ture

        [TestMethod]
        public void includingExcludingInternetConnection_shouldChangeInternetConnectionAndPrice()
        {

                                                    //ARRANGE
            //-----------------------------------------------------------------------------------------------------------------

            //CASE1
            Purchase pToSetToFalseFromFalse = new Purchase(false, 6, new string[] { "iPhone 99", "Samsung Galaxy 99" }, 0);
            //CASE2
            Purchase pToSetToTrueFromFalse = new Purchase(false, 6, new string[] { "iPhone 99", "Samsung Galaxy 99" }, 0);
            //CASE3 
            Purchase pToSetToFalseFromTrue = new Purchase(true, 6, new string[] { "iPhone 99", "Samsung Galaxy 99" }, 200);
            //CASE4
            Purchase pToSetToTrueFromTrue = new Purchase(true, 6, new string[] { "iPhone 99", "Samsung Galaxy 99" }, 200);

                                                    //ACT
            //-----------------------------------------------------------------------------------------------------------------

            //CASE1
            int pToSetToFalseFromFalsePriceBeforeExecuting = pToSetToFalseFromFalse.Price;
            pToSetToFalseFromFalse.includingExcludingInternetConnection(false);
            //CASE2
            int pToSetToTrueFromFalsePriceBeforeExecuting = pToSetToTrueFromFalse.Price;
            pToSetToTrueFromFalse.includingExcludingInternetConnection(true);
            //CASE3 
            int pToSetToFalseFromTruePriceBeforeExecuting = pToSetToFalseFromTrue.Price;
            pToSetToFalseFromTrue.includingExcludingInternetConnection(false);

            int pToSetToTrueFromTrueBeforeExecuting = pToSetToTrueFromTrue.Price;
            pToSetToTrueFromTrue.includingExcludingInternetConnection(true);

                                                    //ASSERT
            //-----------------------------------------------------------------------------------------------------------------
            
            //CASE1
            Assert.AreEqual(false, pToSetToFalseFromFalse.InternetConnection);
            Assert.AreEqual(pToSetToFalseFromFalsePriceBeforeExecuting, pToSetToFalseFromFalse.Price);
            //CASE2
            Assert.AreEqual(true, pToSetToTrueFromFalse.InternetConnection);
            Assert.AreEqual(pToSetToTrueFromFalsePriceBeforeExecuting + 200, pToSetToTrueFromFalse.Price);
            //CASE3 
            Assert.AreEqual(false, pToSetToFalseFromTrue.InternetConnection);
            Assert.AreEqual(pToSetToFalseFromTruePriceBeforeExecuting - 200, pToSetToFalseFromTrue.Price);
            //CASE4
            Assert.AreEqual(true, pToSetToTrueFromTrue.InternetConnection);
            Assert.AreEqual(pToSetToTrueFromTrueBeforeExecuting, pToSetToTrueFromTrue.Price);
        }

        // addPhoneLines -> Patrik
        //CAse1 : Add phoneLines to less than 8 => phoneLines increased by 1
        //CAse2 : Add phoneLines to more or equal to 8 => ArgumentOutOfRangeException
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void addPhoneLines_shouldIncreasePhoneLines()
        {
                                                //ARRANGE
            //-----------------------------------------------------------------------------------------------------------------
            
            //CASE1
            Purchase pToAddPhoneLines = new Purchase(false, 0, new string[] { "iPhone 99", "Samsung Galaxy 99" }, 0);
            //CASE2
            Purchase pToAddPhoneLinesOver8 = new Purchase(false, 8, new string[] { "iPhone 99", "Samsung Galaxy 99" }, 0);

                                                //ACT
            //-----------------------------------------------------------------------------------------------------------------
           
            //CASE1
            int pToAddPhoneLinesBefore = pToAddPhoneLines.PhoneLines;
            pToAddPhoneLines.addPhoneLines();
            //CASE2
            pToAddPhoneLinesOver8.addPhoneLines();

                                                //ASSERT
            //-----------------------------------------------------------------------------------------------------------------
           
            //CASE1
            Assert.AreEqual(pToAddPhoneLinesBefore + 1, pToAddPhoneLines.PhoneLines);
            //CASE2
            // ArgumentOutOfRangeException expected by the method
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
