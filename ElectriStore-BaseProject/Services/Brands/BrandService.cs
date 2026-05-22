using ElectriStore_BaseProject.Models;
using ElectriStore_BaseProject.Repositories.Brands;
using ElectriStore_BaseProject.DTOs.Brands;

namespace ElectriStore_BaseProject.Services.Brands
{
    public class BrandService : IBrandService
    {
        IBrandRepository brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public async Task<IEnumerable<Models.Brand>> GetAllBrandsAsync()
        {
            var brands = await brandRepository.GetAllBrandsAsync();
            return brands;
        }

        public async Task<Brand?> GetBrandByIdAsync(int id)
        {
            var brand = await brandRepository.GetBrandByIdAsync(id);
            return brand;
        }

        public async Task<Brand?> GetBrandByNameAsync(string name)
        {
            var brand = await brandRepository.GetBrandByNameAsync(name);
            return brand;
        }

        public async Task<BrandResultDTO> CreateBrandAsync(Brand brand)
        {
            var existingBrand = await brandRepository.GetBrandByNameAsync(brand.BrandName);
            
            if (existingBrand != null)
            {
                return new BrandResultDTO
                {
                    IsSuccess = false,
                    Message = "Thương hiệu đã tồn tại."
                };
            }
            else
            {
                if (await brandRepository.CreateNewBrand(brand))
                {
                    return new BrandResultDTO
                    {
                        IsSuccess = true,
                        Message = "Tạo mới thương hiệu thành công!"
                    };
                }
                else
                {
                    return new BrandResultDTO
                    {
                        IsSuccess = false,
                        Message = "Tạo mới thất bại!"
                    };
                }
            }
        }

        public async Task<BrandResultDTO> EditBrandAsync(Brand brand)
        {
            var existingBrand = await brandRepository.GetBrandByIdAsync(brand.Id);
            if (existingBrand == null)
            {
                return new BrandResultDTO
                {
                    IsSuccess = false,
                    Message = "Không tìm thấy thương hiệu cần chỉnh sửa."
                };
            }

            var brandWithSameName = await brandRepository.GetBrandByNameAsync(brand.BrandName);
            if (brandWithSameName != null && brandWithSameName.Id != brand.Id)
            {
                return new BrandResultDTO
                {
                    IsSuccess = false,
                    Message = "Tên thương hiệu này đã được sử dụng bởi một thương hiệu khác."
                };
            }

            if (await brandRepository.EditBrand(brand))
            {
                return new BrandResultDTO
                {
                    IsSuccess = true,
                    Message = "Cập nhật thương hiệu thành công."
                };
            }

            return new BrandResultDTO
            {
                IsSuccess = false,
                Message = "Gặp lỗi trong quá trình cập nhật thương hiệu."
            };
        }

        public async Task<BrandResultDTO> DeleteBrandAsync(int id)
        {
            var brand = await brandRepository.GetBrandByIdAsync(id);
            if (brand == null)
            {
                return new BrandResultDTO
                {
                    IsSuccess = false,
                    Message = "Không tìm thấy thương hiệu cần xóa."
                };
            }

            if (brand.Products != null && brand.Products.Any())
            {
                return new BrandResultDTO
                {
                    IsSuccess = false,
                    Message = "Không thể xóa thương hiệu này vì đang có sản phẩm liên quan."
                };
            }

            if (await brandRepository.DeleteBrand(id))
            {
                return new BrandResultDTO
                {
                    IsSuccess = true,
                    Message = "Xóa thương hiệu thành công."
                };
            }

            return new BrandResultDTO
            {
                IsSuccess = false,
                Message = "Gặp lỗi trong quá trình xóa thương hiệu."
            };
        }
    }
}
