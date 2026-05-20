namespace ElectriStore_BaseProject.DTOs
{
    public class ProductDisplayDTO
    {
        public ProductDisplayDTO(string name, decimal salePrice, int stock)
        {
            this.Name = name;
            this.SalePrice = salePrice;
            this.StockQuantity = stock;
        }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public int StockQuantity { get; set; }
    }
}
