﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        // includingExcludingInternetConnection
        // CASE1 : Set false from false => Price does not change + InternetConnection is false
        // CASE2 : Set true from false => Price increases by 200 + InternetConnection is true
        // CASE3 : Set false from true => Price decreases by 200 + InternetConnection is false
        // CASE4 : Set true from true => Price does not change +  InternetConnection is ture

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

        // addPhoneLines
        //CAse1 : Add phoneLines to 0  => phoneLines increased by 1 (from 0 to 1)
        //CAse2 : Add phoneLines to 8 => ArgumentOutOfRangeException
        //CAse3 : Add phoneLines to 1  => phoneLines increased by 1 (from 1 to 2)
        //CAse4 : Add phoneLines to 5  => phoneLines increased by 1 (from 5 to 6)
        //CAse5 : Add phoneLines to 7  => phoneLines increased by 1 (from 7 to 8)

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void addPhoneLines_shouldIncreasePhoneLines()
        {
                                                //ARRANGE
            //-----------------------------------------------------------------------------------------------------------------
            
            //CASE1
            Purchase pToAddPhoneLines0 = new Purchase(false, 0, new string[] { "iPhone 99", "Samsung Galaxy 99" }, 0);
            //CASE2
            Purchase pToAddPhoneLinesOver8 = new Purchase(false, 8, new string[] { "iPhone 99", "Samsung Galaxy 99" }, 0);
            //CASE3
            Purchase pToAddPhoneLines1 = new Purchase(false, 1, new string[] { "iPhone 99", "Samsung Galaxy 99" }, 0);
            //CASE4
            Purchase pToAddPhoneLines5 = new Purchase(false, 5, new string[] { "iPhone 99", "Samsung Galaxy 99" }, 0);
            //CASE5
            Purchase pToAddPhoneLines7 = new Purchase(false, 8, new string[] { "iPhone 99", "Samsung Galaxy 99" }, 0);


            //ACT
            //-----------------------------------------------------------------------------------------------------------------

            //CASE1
            int pToAddPhoneLinesBefore0 = pToAddPhoneLines0.PhoneLines;
            pToAddPhoneLines0.addPhoneLines();
            //CASE2
            pToAddPhoneLinesOver8.addPhoneLines();
            //CASE3
            int pToAddPhoneLinesBefore1 = pToAddPhoneLines1.PhoneLines;
            pToAddPhoneLines1.addPhoneLines();
            //CASE4
            int pToAddPhoneLinesBefore5 = pToAddPhoneLines5.PhoneLines;
            pToAddPhoneLines5.addPhoneLines();
            //CASE5
            int pToAddPhoneLinesBefore7 = pToAddPhoneLines7.PhoneLines;
            pToAddPhoneLines7.addPhoneLines();



            //ASSERT
            //-----------------------------------------------------------------------------------------------------------------

            //CASE1
            Assert.AreEqual(pToAddPhoneLinesBefore0 + 1, pToAddPhoneLines0.PhoneLines);
            //CASE2
            // ArgumentOutOfRangeException expected by the method
            //CASE3
            Assert.AreEqual(pToAddPhoneLinesBefore1 + 1, pToAddPhoneLines1.PhoneLines);
            //CASE4
            Assert.AreEqual(pToAddPhoneLinesBefore5 + 1, pToAddPhoneLines5.PhoneLines);
            //CASE5
            Assert.AreEqual(pToAddPhoneLinesBefore7 + 1, pToAddPhoneLines7.PhoneLines);



        }

        // removePhoneLines
        [TestMethod]
        public void removePhoneLines_shouldRemoveOnePhoneline_And_UpdatePrice()
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
        public void removePhoneLines_ExpectFailure()
        {
            //Arrange
            string[] plist = new string[] { "No phones." };
            Purchase phoneLine_0 = new Purchase(false, 0, plist, 0);

            try
            {
                phoneLine_0.removePhoneLines();
            }
            catch(Exception e)
            {
                throw e;
            }

        }

        // selectPhone
        [TestMethod]
        public void selectPhone_shouldAddSelectedPhoneToPhoneList_And_UpdatePrice()
        {
            // Arrange 
            string[] phonesList = new string[] { "Motorola G99", "iPhone 99", "Samsung Galaxy 99", "Sony Xperia 99", "Huawei 99" };
            Purchase p = new Purchase(false, 0,phonesList, 0);

            /* 
             * If you look at the phone price list Motorola cost 800, IPhone 99 cost 6000 etc.
             * This array contains the expected total price after each time we add a phone.
             */
            int[] expectedPrices = new int[] { 800, 6800, 7800, 8700, 9600};
            
            // Act & Assert
                for(int j = 0; j < expectedPrices.Length; j++)
                {
                    int expectedPrice = expectedPrices[j];
                    Assert.AreEqual(p.selectPhone(phonesList[j]), expectedPrice);

                }

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void selectPhone_InputWrongValues_ShouldThrowArgumentException()
        {
            string[] phonesList = new string[] { "Motrola G9", "ione 1000009", "Samsung Galaxy 99", "Sony Xperia 99", "Huawei 99" };
            Purchase p = new Purchase(false, 0, phonesList, 0);
            try
            {
                for (int j = 0; j < phonesList.Length; j++)
                {
                    Console.WriteLine(phonesList[j]);
                    p.selectPhone(phonesList[j]);
                }
            } catch (Exception e)
            {
                throw e;
            }

        }

        // unselectPhone
        [TestMethod]
        public void unselectPhone_RemoveExisting()
        {
            //// Arrange
            //string[] phonesList = new string[] { "iPhone 99", "Samsung Galaxy 99", "Huawei 99" };
            //Purchase p = new Purchase(false,0,phonesList,7900);
            //int expectedPriceAfterRemoval = 1900;
            //int priceWeGot = 0;

            //// Act
            //priceWeGot = p.unselectPhone("iPhone 99");

            //// Assert
            //Assert.AreEqual(priceWeGot, expectedPriceAfterRemoval);

            // Arrange 
            string[] phonesList = new string[] { "Motorola G99", "iPhone 99", "Samsung Galaxy 99", "Sony Xperia 99", "Huawei 99" };
            Purchase p = new Purchase(false, 0, phonesList, 0);

            /* 
             * If you look at the phone price list Motorola cost 800, IPhone 99 cost 6000 etc.
             * This array contains the expected total price after each time we add a phone.
             */
            int[] expectedPrices = new int[] { -800, -6000, -1000, -900, -900 };

            // Act & Assert
            for (int j = 0; j < expectedPrices.Length; j++)
            {
                p.Price = 0;
                int expectedPrice = expectedPrices[j];
                Assert.AreEqual(p.unselectPhone(phonesList[j]), expectedPrice);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void unselectPhone_RemoveInvalidPhone()
        {
            string[] phonesList = new string[] { "iPhone 99", "Samsung Galaxy 99", "Huawei 99" };
            Purchase p = new Purchase(false, 0, phonesList, 7900);

         
                p.unselectPhone("Sony Xperia 9999999");
            
           
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        public void unselectPhone_RemoveNotPurchasedPhone()
        {
            string[] phonesList = new string[] { "iPhone 99", "Samsung Galaxy 99", "Huawei 99" };
            Purchase p = new Purchase(false, 0, phonesList, 7900);

          
                p.unselectPhone("Sony Xperia 99");
          
        }

        // checkOut
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

        [TestMethod]
        public void checkOut_priceIsNegative()
        {
            // Arrange
            string[] phonesList = new string[] { "iPhone 99", "Samsung Galaxy 99", "Huawei 99" };
            Purchase p = new Purchase(false, 0, phonesList, -1);
            string expectedMessage = "Please select at least 1 item before you check out.";
            string messageWeGot;

            // Act
            messageWeGot = p.checkOut();

            // Assert
            Assert.AreEqual(messageWeGot, expectedMessage);
        }
    }
}
