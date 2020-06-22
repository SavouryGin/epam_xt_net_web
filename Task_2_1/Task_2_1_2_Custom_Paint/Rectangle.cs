using System;

namespace Task_2_1_2_Custom_Paint
{
    class Rectangle : Square
    {
        // Fields
        protected double len2;

        // Constructor
        public Rectangle(string n, double a, double b) : base(n, a)
        {
            if (b <= 0)
            {
                throw new Exception("The length of one of the sides is less than or equal to zero!");
            }
            else
            {
                len2 = b;
            }
        }

        // Properties
        private double Perimeter => len1 * 2 + len2 * 2;

        private double Area => len1 * len2;

        // Methods
        public override double GetArea() => Area;      

        public override double GetLength() => Perimeter;
    }

}
