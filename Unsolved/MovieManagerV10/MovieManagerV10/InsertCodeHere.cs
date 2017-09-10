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

            Console.WriteLine($"{firstMovie.Title}, by {firstMovie.Director}, watched it {firstMovie.NoOfViews} time(s)");
            Console.WriteLine($"{secondMovie.Title}, by {secondMovie.Director}, watched it {secondMovie.NoOfViews} time(s)");

            firstMovie.Watch();
            firstMovie.Watch();
            secondMovie.Watch();

            Console.WriteLine($"{firstMovie.Title}, by {firstMovie.Director}, watched it {firstMovie.NoOfViews} time(s)");
            Console.WriteLine($"{secondMovie.Title}, by {secondMovie.Director}, watched it {secondMovie.NoOfViews} time(s)");

            // The LAST line of code should be ABOVE this line
        }
    }
}