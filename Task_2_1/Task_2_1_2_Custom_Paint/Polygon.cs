namespace Task_2_1_2_Custom_Paint
{
    abstract class Polygon
    {
        // Fields
        public string shape;
        public string id;

        // Constructor
        public Polygon(string polygonName)
        {
            id = polygonName;
            string[] arr = GetType().ToString().Split('.');
            shape = arr[arr.Length - 1];
        }

        // Methods
        public string GetShape() => shape;

        public string GetId() => id;
        
        public abstract double GetArea();

        public abstract double GetLength();
    }
}
