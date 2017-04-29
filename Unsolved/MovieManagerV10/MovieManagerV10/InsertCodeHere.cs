using System;

namespace MovieManagerV10
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            Movie firstMovie = new Movie("Alien", "Ridley Scott", 112);
            Movie secondMovie = new Movie("Inception", "Christopher Nolan", 162);

            Console.WriteLine("{0}, by {1}, watched it {2} time(s)", firstMovie.Title, firstMovie.Director, firstMovie.NoOfViews);
            Console.WriteLine("{0}, by {1}, watched it {2} time(s)", secondMovie.Title, secondMovie.Director, secondMovie.NoOfViews);

            firstMovie.Watch();
            firstMovie.Watch();
            secondMovie.Watch();

            Console.WriteLine("{0}, by {1}, watched it {2} time(s)", firstMovie.Title, firstMovie.Director, firstMovie.NoOfViews);
            Console.WriteLine("{0}, by {1}, watched it {2} time(s)", secondMovie.Title, secondMovie.Director, secondMovie.NoOfViews);

            // The LAST line of code should be ABOVE this line
        }
    }
}