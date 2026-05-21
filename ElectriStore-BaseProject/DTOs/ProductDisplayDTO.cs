using ElectriStore_BaseProject.Models;

namespace ElectriStore_BaseProject.DTOs
{
    public class ProductDisplayDTO
    {
        // get all infor of product which admin want to show
        public ProductDisplayDTO(string name, string brand, string category, decimal salePrice, int stock, string madeIn, decimal rating ,string description, bool isActive)
        {
            this.Name = name;
            this.Brand = brand;
            this.Category = category;
            this.SalePrice = salePrice;
            this.StockQuantity = stock;
            this.MadeIn = madeIn;
            this.Rating = rating;
            this.Description = description;
            this.IsActive = isActive;
        }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public decimal SalePrice { get; set; }
        public int StockQuantity { get; set; }
        public string MadeIn { get; set; }
        public decimal Rating { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
