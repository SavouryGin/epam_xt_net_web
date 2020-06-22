using System;

namespace Task_2_1_2_Custom_Paint
{
    class Rectangle : Square
    {
        protected double len2;

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

        public new double Perimeter => len1 * 2 + len2 * 2;

        public override double GetArea()
        {
            return len1 * len2;
        }
    }

}
