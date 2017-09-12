using System;
using System.Collections.Generic;

namespace SimpleGeometry
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            List<Shape> shapeList = new List<Shape>();
            // Fill in some Circle and Rectangle objects

            foreach (Shape s in shapeList)
            {
                Console.WriteLine($"A {s.ShapeName} with area {s.Area:F2}");
            }

            double totalArea = Shape.FindTotalArea(shapeList);
            Console.WriteLine($"The total area of the shapes is {totalArea:F2}");

            // The LAST line of code should be ABOVE this line
        }
    }
}