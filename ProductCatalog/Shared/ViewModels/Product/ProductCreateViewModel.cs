namespace Shared.ViewModels.Product
{
    public class ProductCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Duration (in days)")]
        public int DurationInDays { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        [Display(Name = "Product Image")]
        public IFormFile Image { get; set; }
    }
}
