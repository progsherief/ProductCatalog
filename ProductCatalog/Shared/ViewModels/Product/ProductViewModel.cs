namespace Shared.ViewModels.Product
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public int DurationInDays { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public string? CategoryName { get; set; } //
        public Guid CategoryId { get; set; }

        public bool IsAvailableNow
        {
            get
            {
                var now = DateTime.UtcNow;
                return now >= StartDate && now <= StartDate.AddDays(DurationInDays);
            }
        }
    }
}
