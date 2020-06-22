using System;

namespace Task_2_1_2_Custom_Paint
{
    class Triangle : Polygon
    {
        protected double lenA;
        protected double lenB;
        protected double lenC;

        public Triangle(string n, double a, double b, double c) : base(n)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new Exception("The length of one of the sides is less than or equal to zero!");
            }
            else if (a + b > c && a + c > b && b + c > a)
            {
                lenA = a;
                lenB = b;
                lenC = c;
            }
            else
            {
                throw new Exception("The triangle does not exist!");
            }
        }

        public double Perimeter => (lenA + lenB + lenC);

        public override double GetArea()
        {
            double p = Perimeter / 2;
            return Math.Sqrt(p * (p - lenA) * (p - lenB) * (p - lenC));
        }
    }
}
