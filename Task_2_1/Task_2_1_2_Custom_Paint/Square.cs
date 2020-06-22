using System;

namespace Task_2_1_2_Custom_Paint
{
    internal class Square : Polygon
    {
        protected double len1;

        public Square(string n, double a) : base(n)
        {
            if (a <= 0)
            {
                throw new Exception("The length of one of the sides is less than or equal to zero!");
            } 
            else
            {
                len1 = a;
            }            
        }

        public double Perimeter => len1 * 4;

        public override double GetArea()
        {
            return len1 * len1;
        }

    }
}
