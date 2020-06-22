namespace Task_2_1_2_Custom_Paint
{
    abstract class Polygon
    {
        public string shape;
        public string id;

        public Polygon(string polygonName)
        {
            id = polygonName;
            string[] arr = GetType().ToString().Split('.');
            shape = arr[arr.Length - 1];
        }

        public string GetShape()
        {
            return shape;
        }

        public string GetId()
        {
            return id;
        }        

        public abstract double GetArea();
    }
}
