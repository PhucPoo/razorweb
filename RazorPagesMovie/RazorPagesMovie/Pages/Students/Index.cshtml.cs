using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genders { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? StudentGender { get; set; }

        public async Task OnGetAsync()
        {
            // Truy vấn danh sách sinh viên
            var studentQuery = from s in _context.Student select s;

            // Lọc theo tên hoặc mã sinh viên nếu SearchString không rỗng
            if (!string.IsNullOrEmpty(SearchString))
            {
                studentQuery = studentQuery
                    .Where(s => s.Name.Contains(SearchString) || s.MSV.Contains(SearchString));
            }

            // Lọc theo giới tính nếu StudentGender không rỗng
            if (!string.IsNullOrEmpty(StudentGender))
            {
                studentQuery = studentQuery
                    .Where(s => s.Gender == StudentGender);
            }

            // Truy vấn danh sách các giới tính để tạo SelectList
            IQueryable<string> genderQuery = from s in _context.Student
                                             orderby s.Gender
                                             select s.Gender;

            // Tạo SelectList chứa các giá trị giới tính
            Genders = new SelectList(await genderQuery.Distinct().ToListAsync());

            // Gán danh sách sinh viên sau khi đã lọc vào thuộc tính Student
            Student = await studentQuery.ToListAsync();
        }

    }
}
