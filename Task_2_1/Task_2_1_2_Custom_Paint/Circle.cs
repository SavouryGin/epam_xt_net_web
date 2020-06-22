using System;

namespace Task_2_1_2_Custom_Paint
{
    internal class Circle : Polygon
    {
        // Fields
        protected double radius;
        protected int x;
        protected int y;
        protected int z;

        // Constructor
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

        // Properties
        private double Length => 2 * Math.PI * radius;

        private double Area => Math.PI * radius * radius;

        // Methods
        public override double GetArea() => Area;

        public override double GetLength() => Length;

    }
}
