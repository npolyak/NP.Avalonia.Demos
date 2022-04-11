namespace NP.Demos.AdvancedDataGridDemo
{
    public class Product
    {
        public string? Name { get; }

        public string? Description { get; }

        public string? Manufacturer { get; }

        public double? Cost { get; }


        public Product(string? name, string? description, string? manufacturer, double? cost)
        {
            Name = name;
            Description = description;  
            Manufacturer = manufacturer;
            Cost = cost;
        }
    }
}
