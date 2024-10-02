namespace FormsApp.Models
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public List<Category> Categories { get; set; } = new List<Category>();
        
        public string? SelectedCategory { get; set; }
    }
}
