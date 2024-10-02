using System.ComponentModel.DataAnnotations;
namespace FormsApp.Models
{
    public class Product
    {
        [Display(Name="Urun Id")]
        public int ProductId { get; set; } 

        [Required]
        [Display(Name="Urun Adı")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(0, 100000)]
        [Display(Name="Urun Fiyatı")]
        public decimal? Price { get; set; }
        
        
        [Display(Name="Urun Resmi")]
        public string Image { get; set; } = string.Empty;

        public bool IsActive { get; set; }
 
        [Required]
        [Display(Name="Kategori")]
        public int? CategoryId { get; set; }
    }
}
