namespace CodeLouisvilleUnitTestProject
{
    public class CargoItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public CargoItem(string name, string desc, int quantity)
        {
            this.Name = name;
            this.Description = desc;
            this.Quantity = quantity;
        }
    }
}
