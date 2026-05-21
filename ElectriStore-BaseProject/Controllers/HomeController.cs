using ElectriStore_BaseProject.Models;
using ElectriStore_BaseProject.Services.Products;
using ElectriStore_BaseProject.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ElectriStore_BaseProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(string query)
        {
            var productList = new List<HomeProductViewModel>();

            // 1. Lấy sản phẩm từ database (nếu có) và map vào view model
            try
            {
                var dbProducts = await _productService.GetProductDisplayDTOsAsync();
                if (dbProducts != null)
                {
                    foreach (var p in dbProducts)
                    {
                        productList.Add(new HomeProductViewModel
                        {
                            Name = p.Name ?? "Sản phẩm công nghệ",
                            SalePrice = p.SalePrice,
                            OriginalPrice = p.SalePrice > 0 ? Math.Round(p.SalePrice * 1.18m) : 0,
                            Rating = p.Rating > 0 ? p.Rating : 4.8m,
                            InstallmentTag = "Góp 0%",
                            Specifications = !string.IsNullOrEmpty(p.Description) && p.Description.Length > 25 
                                ? p.Description.Substring(0, 25) + "..." 
                                : (!string.IsNullOrEmpty(p.Brand) ? $"{p.Brand} | {p.Category}" : "Hàng chính hãng"),
                            GiftInfo = "Tặng Voucher 500k + Bảo hành 2 năm",
                            ImageUrl = "https://images.unsplash.com/photo-1546868871-7041f2a55e12?auto=format&fit=crop&q=80&w=400",
                            SalesCount = "10k" // Mặc định là 10k theo yêu cầu người dùng
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi lấy sản phẩm từ DB: {ex.Message}");
            }

            // 2. Thêm 20 sản phẩm Mock cao cấp có ảnh Unsplash tuyệt đẹp và thông số sắc nét
            var mockProducts = new List<HomeProductViewModel>
            {
                new HomeProductViewModel
                {
                    Name = "iPhone 15 Pro Max 256GB Titan tự nhiên",
                    ImageUrl = "https://images.unsplash.com/photo-1695048133142-1a20484d2569?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 29990000,
                    OriginalPrice = 34990000,
                    Rating = 4.9m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "6.7\" | RAM 8GB | Apple A17 Pro",
                    GiftInfo = "Tặng cáp sạc nhanh 25W + ốp lưng cao cấp",
                    SalesCount = "10k"
                },
                new HomeProductViewModel
                {
                    Name = "iPad Pro M4 11-inch Ultra Retina XDR Wifi 256GB",
                    ImageUrl = "https://images.unsplash.com/photo-1544244015-0df4b3ffc6b0?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 28490000,
                    OriginalPrice = 30990000,
                    Rating = 4.9m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "11\" Tandem OLED | Chip M4 | 8GB RAM",
                    GiftInfo = "Giảm 500k khi mua kèm bút Apple Pencil Pro",
                    SalesCount = "10k"
                },
                new HomeProductViewModel
                {
                    Name = "MacBook Air M3 13-inch 8GB RAM / 256GB SSD",
                    ImageUrl = "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 27490000,
                    OriginalPrice = 29990000,
                    Rating = 4.8m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "13.6\" Liquid Retina | M3 | 8 nhân GPU",
                    GiftInfo = "Tặng túi chống sốc cao cấp + Chuột không dây",
                    SalesCount = "10k"
                },
                new HomeProductViewModel
                {
                    Name = "Samsung Galaxy S24 Ultra 256GB AI Phone",
                    ImageUrl = "https://images.unsplash.com/photo-1610945265064-0e34e5519bbf?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 28990000,
                    OriginalPrice = 33990000,
                    Rating = 4.7m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "6.8\" QHD+ | Snap 8 Gen 3 | RAM 12GB",
                    GiftInfo = "Tặng củ sạc siêu nhanh Samsung 45W",
                    SalesCount = "10k"
                },
                new HomeProductViewModel
                {
                    Name = "Tai nghe chụp tai Sony WH-1000XM5 chống ồn đỉnh cao",
                    ImageUrl = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 7990000,
                    OriginalPrice = 9490000,
                    Rating = 4.8m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "Chống ồn ANC | Pin 30h | Hi-Res Audio",
                    GiftInfo = "Tặng hộp đựng tai nghe + cáp AUX mạ vàng",
                    SalesCount = "10k"
                },
                new HomeProductViewModel
                {
                    Name = "Đồng hồ thông minh Apple Watch Ultra 2 GPS + Cellular 49mm",
                    ImageUrl = "https://images.unsplash.com/photo-1434494878577-86c23bcb06b9?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 21490000,
                    OriginalPrice = 22990000,
                    Rating = 4.9m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "Khung Titanium | Pin 36h | Chống nước 100m",
                    GiftInfo = "Tặng dán màn hình cường lực chống trầy xước",
                    SalesCount = "10k"
                },
                new HomeProductViewModel
                {
                    Name = "Laptop Dell XPS 13 Plus 9320 Core i7-1360P / 16GB / 512GB",
                    ImageUrl = "https://images.unsplash.com/photo-1593642632823-8f785ba67e45?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 38990000,
                    OriginalPrice = 44990000,
                    Rating = 4.6m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "13.4\" FHD+ Touch | Iris Xe | Nhẹ 1.2kg",
                    GiftInfo = "Tặng balo Dell Pro + Chuột Dell Bluetooth",
                    SalesCount = "10k"
                },
                new HomeProductViewModel
                {
                    Name = "Tai nghe không dây Apple AirPods Pro 2 MagSafe USB-C",
                    ImageUrl = "https://images.unsplash.com/photo-1588449668365-d15e397f6787?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 5790000,
                    OriginalPrice = 6190000,
                    Rating = 4.9m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "Chip H2 | Chống ồn chủ động | Adaptive Audio",
                    GiftInfo = "Tặng bao silicon bảo vệ hộp sạc thời trang",
                    SalesCount = "10k"
                },
                new HomeProductViewModel
                {
                    Name = "Điện thoại Xiaomi Redmi Note 13 Pro 8GB/256GB",
                    ImageUrl = "https://images.unsplash.com/photo-1598327105666-5b89351aff97?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 6990000,
                    OriginalPrice = 7990000,
                    Rating = 4.5m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "6.67\" AMOLED 120Hz | Cam 200MP | Sạc 67W",
                    GiftInfo = "Tặng voucher mua phụ kiện trị giá 200k",
                    SalesCount = "10k"
                },
                new HomeProductViewModel
                {
                    Name = "Laptop Gaming ASUS ROG Zephyrus G14 Ryzen 9 / RTX 4060",
                    ImageUrl = "https://images.unsplash.com/photo-1603302576837-37561b2e2302?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 42990000,
                    OriginalPrice = 47990000,
                    Rating = 4.8m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "14\" QHD+ 165Hz | 16GB RAM | SSD 1TB",
                    GiftInfo = "Tặng chuột gaming ROG Strix Impact II + Balo ROG",
                    SalesCount = "10k"
                },
                new HomeProductViewModel
                {
                    Name = "Chuột không dây công thái học Logitech MX Master 3S",
                    ImageUrl = "https://images.unsplash.com/photo-1615663245857-ac93bb7c39e7?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 2490000,
                    OriginalPrice = 2990000,
                    Rating = 4.8m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "Cảm biến 8K DPI | Nút cuộn MagSpeed | Yên tĩnh",
                    GiftInfo = "Miễn phí vận chuyển toàn quốc + Đổi trả 1-1",
                    SalesCount = "10k"
                },
                new HomeProductViewModel
                {
                    Name = "Bàn phím cơ không dây Keychron K2 V2 Aluminum Hot-swap",
                    ImageUrl = "https://images.unsplash.com/photo-1587829741301-dc798b83add3?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 2190000,
                    OriginalPrice = 2590000,
                    Rating = 4.7m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "Layout 75% | Gateron Switch | Đèn RGB",
                    GiftInfo = "Tặng bộ keycap nhựa ABS kèm theo và chổi vệ sinh",
                    SalesCount = "10k"
                },
                new HomeProductViewModel
                {
                    Name = "Màn hình đồ họa LG UltraFine 27-inch 4K IPS VESA HDR400",
                    ImageUrl = "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 9990000,
                    OriginalPrice = 11990000,
                    Rating = 4.7m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "27\" UHD 4K | IPS DCI-P3 95% | USB Type-C 96W",
                    GiftInfo = "Tặng dây cáp HDMI 2.1 Ultra High Speed 2m",
                    SalesCount = "10k"
                },
                new HomeProductViewModel
                {
                    Name = "Máy chơi game Nintendo Switch OLED Model White",
                    ImageUrl = "https://images.unsplash.com/photo-1568658176307-e7e675427da7?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 7490000,
                    OriginalPrice = 8490000,
                    Rating = 4.8m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "Màn hình OLED 7-inch | Bộ nhớ trong 64GB",
                    GiftInfo = "Tặng dán kính cường lực bảo vệ màn hình miễn phí",
                    SalesCount = "10k"
                },
                new HomeProductViewModel
                {
                    Name = "Camera hành trình GoPro HERO 12 Black chính hãng",
                    ImageUrl = "https://images.unsplash.com/photo-1565849906661-ca96033c52d6?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 9990000,
                    OriginalPrice = 11490000,
                    Rating = 4.6m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "Quay 5.3K60 | Chống rung HyperSmooth 6.0",
                    GiftInfo = "Tặng thẻ nhớ MicroSD SanDisk Extreme 64GB",
                    SalesCount = "10k"
                },
                new HomeProductViewModel
                {
                    Name = "Máy hút bụi cầm tay không dây Dyson V15 Detect Absolute",
                    ImageUrl = "https://images.unsplash.com/photo-1558317374-067fb5f30001?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 19990000,
                    OriginalPrice = 22990000,
                    Rating = 4.9m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "Lực hút 230AW | Cảm biến bụi laser | Pin 60 phút",
                    GiftInfo = "Tặng kèm giá đỡ đứng sạc Dyson đa năng",
                    SalesCount = "10k"
                },
                new HomeProductViewModel
                {
                    Name = "Máy đọc sách All-new Kindle Paperwhite 5 (11th Gen) 16GB",
                    ImageUrl = "https://images.unsplash.com/photo-1544716278-ca5e3f4abd8c?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 3790000,
                    OriginalPrice = 4290000,
                    Rating = 4.8m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "Màn hình 6.8\" e-ink | Đèn vàng ấm | Chống nước",
                    GiftInfo = "Tặng bao da bảo vệ thông minh tự động tắt mở màn hình",
                    SalesCount = "10k"
                },
                new HomeProductViewModel
                {
                    Name = "Máy chơi game Sony PlayStation 5 Slim Standard Edition",
                    ImageUrl = "https://images.unsplash.com/photo-1606813907291-d86efa9b94db?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 13990000,
                    OriginalPrice = 14990000,
                    Rating = 4.9m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "Bản ổ đĩa Slim | SSD 1TB | Đồ họa Ray Tracing 4K",
                    GiftInfo = "Tặng Đế tản nhiệt đa năng tích hợp dock sạc tay cầm",
                    SalesCount = "10k"
                },
                new HomeProductViewModel
                {
                    Name = "Tai nghe không dây Sennheiser Momentum 4 Wireless",
                    ImageUrl = "https://images.unsplash.com/photo-1546435770-a3e426bf472b?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 7990000,
                    OriginalPrice = 9490000,
                    Rating = 4.7m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "Chất âm Audiophile | Pin cực khủng 60h | ANC thích ứng",
                    GiftInfo = "Miễn phí bảo hành 2 năm chính hãng toàn quốc",
                    SalesCount = "10k"
                },
                new HomeProductViewModel
                {
                    Name = "Flycam siêu nhẹ DJI Mini 4 Pro Fly More Combo RC 2",
                    ImageUrl = "https://images.unsplash.com/photo-1508614589041-895b88991e3e?auto=format&fit=crop&q=80&w=400",
                    SalePrice = 26990000,
                    OriginalPrice = 28990000,
                    Rating = 4.9m,
                    InstallmentTag = "Góp 0%",
                    Specifications = "Nặng dưới 249g | Quay dọc 4K60 HDR | Cảm biến 360 độ",
                    GiftInfo = "Tặng 3 pin bay thông minh + túi đeo chéo DJI",
                    SalesCount = "10k"
                }
            };

            productList.AddRange(mockProducts);

            // cần sửa lại để tìm kiếm trong database
            if (!string.IsNullOrEmpty(query))
            {
                productList = productList
                    .Where(p => p.Name.Contains(query, StringComparison.OrdinalIgnoreCase) 
                             || (p.Specifications != null && p.Specifications.Contains(query, StringComparison.OrdinalIgnoreCase)))
                    .ToList();
                
                ViewData["SearchQuery"] = query;
            }

            return View(productList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

