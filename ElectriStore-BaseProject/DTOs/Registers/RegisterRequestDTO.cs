using System.ComponentModel.DataAnnotations;

namespace ElectriStore_BaseProject.DTOs.Registers
{
    public class RegisterRequestDTO
    {
        [Required(ErrorMessage = "Tên không được để trống!")]
        [Display(Name = "Full Name")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Email Không được để trống!")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng!")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        [Phone(ErrorMessage ="Số điện thoại không hợp lệ!")]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password không được để trống!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Xắc nhận mật khẩu không được để trống!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
