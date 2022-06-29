using System.Collections.ObjectModel;

namespace NP.Demos.AdvancedDataGridDemo
{
    public class DemoProducts : ObservableCollection<Product>
    {
        private void AddProduct(string? name, string? description, string? manufacturer, double? cost)
        {
            this.Add(new Product(name, description, manufacturer, cost));
        }

        public DemoProducts()
        {
            AddProduct("Batmobile", "Nice and comfortable tank that can jump between rooftops", "Wayne Enterprises", 10000000);
            AddProduct("Instant Tunnel", "Allows a cartoon character to escape", "ACME Corp", 20000);
            AddProduct("Brains for Scarecrow", "Provides any bright scarecrow with intellectual confidence", "OZ Production", 50);
            AddProduct("UniDock", "Multiplatform Window Docking Package for Avalonia", "Nick Polyak Enterprises", 0);
        }
    }
}
