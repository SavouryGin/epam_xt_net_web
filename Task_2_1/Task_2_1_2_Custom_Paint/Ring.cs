using System;

namespace Task_2_1_2_Custom_Paint
{
    internal class Ring : Circle
    {
        protected double innerRadius;

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

        public double LenCircles => 2 * Math.PI * radius + 2 * Math.PI * innerRadius;

        public override double GetArea()
        {
            double outerArea = Math.PI * radius * radius;
            double innerArea = Math.PI * innerRadius * innerRadius;
            return outerArea - innerArea;
        }
    }
}
