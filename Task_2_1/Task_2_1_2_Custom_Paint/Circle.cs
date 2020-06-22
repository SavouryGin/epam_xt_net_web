using System;

namespace Task_2_1_2_Custom_Paint
{
    internal class Circle : Polygon
    {
        protected double radius;
        protected int x;
        protected int y;
        protected int z;

        public Circle(string n, int x, int y, int z, double r) : base(n)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            
            if (r >= 0)
            {
                radius = r;
            }
            else
            {
                throw new Exception("Radius is less than zero!");
            }
        }

        public double LenCircle => 2 * Math.PI * radius;

        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }              

    }
}
