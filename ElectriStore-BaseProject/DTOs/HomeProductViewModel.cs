namespace ElectriStore_BaseProject.DTOs
{
    public class HomeProductViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = "/images/default-product.png";
        public decimal SalePrice { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Rating { get; set; }
        public string InstallmentTag { get; set; } = "Góp 0%";
        public string Specifications { get; set; } = string.Empty;
        public string GiftInfo { get; set; } = string.Empty;
        public string SalesCount { get; set; } = "10k";
    }
}
