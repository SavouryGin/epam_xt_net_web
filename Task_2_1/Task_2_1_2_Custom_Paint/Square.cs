using System;

namespace Task_2_1_2_Custom_Paint
{
    internal class Square : Polygon
    {
        // Fields
        protected double len1;

        // Constructor
        public Square(string n, double a) : base(n)
        {
            if (a <= 0)
            {
                throw new Exception("The length of one side is less than or equal to zero!");
            } 
            else
            {
                len1 = a;
            }            
        }

        // Properties
        private double Perimeter => len1 * 4;

        private double Area => len1 * len1;

        // Methods
        public override double GetArea() => Area;

        public override double GetLength() => Perimeter;

    }
}
