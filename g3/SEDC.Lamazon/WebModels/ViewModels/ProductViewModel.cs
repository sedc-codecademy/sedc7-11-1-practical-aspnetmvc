using WebModels.Enumerations;

namespace WebModels.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public CategoryViewType Category { get; set; }
        public int OrderId { get; set; }
    }
}