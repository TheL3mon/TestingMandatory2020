using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class Purchase
    {
        private bool internetConnection;
        private int phoneLines;
        private string[] cellPhones;
        private int price;

        public bool InternetConnection { get => internetConnection; set => internetConnection = value; }
        public int PhoneLines { get => phoneLines; set => phoneLines = value; }
        public string[] CellPhones { get => cellPhones; set => cellPhones = value; }
        public int Price { get => price; set => price = value; }

        public Purchase(bool internetConnection, int phoneLines, string[] cellPhones, int price)
        {
            this.internetConnection = internetConnection;
            this.phoneLines = phoneLines;
            this.cellPhones = cellPhones;
            this.price = price;
        }

        // Christian 
        public int includingExcludingInternetConnection(bool internetConnection)
        {
            if (internetConnection)
            {
                /*
                int currentPrice = Price;
                currentPrice += 200;
                */
                if (InternetConnection == false) 
                {
                    Price += 200;
                }

                InternetConnection = true;
                return Price;

            }
            else
            {
                if(InternetConnection == true)
                {
                    Price -= 200;
                }

                InternetConnection = false;
                return Price;

            }
        }


        // Christian
        public int addPhoneLines()
        {
            if (this.phoneLines >= 8)
            {
                throw new ArgumentOutOfRangeException("Maximum allowed phonelines are 8");

            }
            else
            {
                /*
                int currentPhoneLines = this.phoneLines;
                currentPhoneLines += 1;
                return currentPhoneLines;
                */
                PhoneLines += 1;
                return PhoneLines;
            }
        }

        // Daniel
        public int removePhoneLines()
        {
            if (phoneLines >= 1)
            {
                phoneLines = phoneLines - 1;
                price = price - 150;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
            return price;
        }

        // Daniel
        public int selectPhone(string phone)
        {
            switch (phone)
            {
                case "Motorola G99":
                    price = price + 800;
                    break;

                case "iPhone 99":
                    price = price + 6000;
                    break;

                case "Samsung Galaxy 99":
                    price = price + 1000;
                    break;

                case "Sony Xperia 99":
                    price = price + 900;
                    break;

                case "Huawei 99":
                    price = price + 900;
                    break;

                default:
                    throw new ArgumentException();
            }

            return price;
        }

        // Patrik
        public int unselectPhone(string phone)
        {
                int index = Array.IndexOf(CellPhones, phone);
                this.CellPhones = this.CellPhones.Where((val, idx) => idx != index).ToArray();

                switch (phone)
                {
                    case "Motorola G99":                     
                        price = price - 800;
                        break;

                    case "iPhone 99":
                        price = price - 6000;
                        break;

                    case "Samsung Galaxy 99":
                        price = price - 1000;
                        break;

                    case "Sony Xperia 99":
                        price = price - 900;
                        break;

                    case "Huawei 99":
                        price = price - 900;
                        break;

                    default:
                        throw new ArgumentException();
                }

                return price;
        }

        // Patrik
        public string checkOut()
        {
            try
            {
                if (price > 0)
                {
                    return $"The total price is: {price}";
                }
                return "Please select at least 1 item before you check out.";
            }
            catch
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
