using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Student
    {
        [Key]
        [RegularExpression(@"^[0-9]{10}$")]
        public string MSV { get; set; }
        
        [RegularExpression(@"^[a-zA-ZÀ-ỹ\s]+$")]  
        [Display(Name = "Họ và tên")]
        [StringLength(50, MinimumLength = 3 ,ErrorMessage = "Họ và tên không được dài quá 50 ký tự")]
        public string Name { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        public DateOnly Birthday { get; set; }

        public string Class { get; set; } // Thêm thuộc

        
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng định dạng")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z]*$")]
        [Display(Name = "Giới tính")]
        public string Gender { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(100, ErrorMessage = "Địa chỉ không được dài quá 100 ký tự")]
        public string Address { get; set; }
    }
}
