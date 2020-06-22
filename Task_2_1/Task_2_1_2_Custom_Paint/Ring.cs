using System;

namespace Task_2_1_2_Custom_Paint
{
    internal class Ring : Circle
    {
        // Fields
        protected double innerRadius;

        // Constructor
        public Ring(string n, int x, int y, int z, double r, double ir) : base(n, x, y, z, r)
        {
            if (ir < 0)
            {
                throw new Exception("Inner radius is less than zero!");
            } 
            else
            {
                innerRadius = ir;
            }
        }

        // Properties
        private double Length => 2 * Math.PI * radius + 2 * Math.PI * innerRadius;

        private double Area => Math.PI * radius * radius - Math.PI * innerRadius * innerRadius;

        // Methods
        public override double GetArea() => Area;

        public override double GetLength() => Length;
    }
}
