using System;

namespace Task_2_1_2_Custom_Paint
{
    class Triangle : Polygon
    {
        // Fields
        protected double lenA;
        protected double lenB;
        protected double lenC;

        // Constructor
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
                throw new Exception("A triangle with such sides does not exist!");
            }
        }

        // Properties
        private double Perimeter => (lenA + lenB + lenC);

        private double HalfP => Perimeter / 2;

        private double Area => Math.Sqrt(HalfP * (HalfP - lenA) * (HalfP - lenB) * (HalfP - lenC));

        // Methods
        public override double GetArea() => Area;

        public override double GetLength() => Perimeter;
    }
}
