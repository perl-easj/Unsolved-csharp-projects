using System;

namespace WebShopV06
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            double netPriceBook = 30;
            double netPriceDVD = 50;
            double netPriceGame = 100;

            int noOfBooksInOrder = 0;
            int noOfDVDsInOrder = 0;
            int noOfGamesInOrder = 0;

            // SO#1
            bool receiveSpecialOffer1 = false;

            // SO#2
            bool receiveSpecialOffer2 = false;

            // SO#3
            bool receiveSpecialOffer3 = false;

            // SO#4
            bool receiveSpecialOffer4 = false;

            Console.WriteLine("You ordered {0} books, {1} DVDs and {2} games", noOfBooksInOrder, noOfDVDsInOrder, noOfGamesInOrder);
            Console.WriteLine("You qualify for special offer #1 : {0}", receiveSpecialOffer1);
            Console.WriteLine("You qualify for special offer #2 : {0}", receiveSpecialOffer2);
            Console.WriteLine("You qualify for special offer #3 : {0}", receiveSpecialOffer3);
            Console.WriteLine("You qualify for special offer #4 : {0}", receiveSpecialOffer4);

            // The LAST line of code should be ABOVE this line
        }
    }
}