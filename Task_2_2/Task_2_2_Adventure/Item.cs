namespace Task_2_2_Adventure
{
    class Item
    {
        public string name;
        private bool useable;
        private bool needsItem;
        private string description;

        public Item(string _name, bool canUse, string _description)
        {
            name = _name;
            useable = canUse;
            description = _description;
        }

        public string Name
        {
            get { return name; }
        }

        public bool Useable
        {
            get { return useable; }
        }

        public string Description
        {
            get { return description; }
        }
    }
}
