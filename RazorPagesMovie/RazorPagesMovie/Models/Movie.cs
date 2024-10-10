using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models;

public class Movie
{
    
    public int Id { get; set; }

    [Display(Name = "Tên phim")]
    public string? Title { get; set; }


    [DataType(DataType.Date)]
    [Display(Name = "Ngày phát hành")]
    [Required(ErrorMessage = "Vui lòng nhập ngày phát hành")]
    public DateTime ReleaseDate { get; set; }

    [Display(Name ="Thể loại")]
    public string? Genre { get; set; }

    [Display(Name = "Giá")]
    [Column(TypeName = "decimal(18, 3)")]
    public decimal Price { get; set; }

    public string Rating { get; set; } = string.Empty;
}
