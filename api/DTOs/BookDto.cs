using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class BookDto
    {
        public int id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage ="Title Must Min 2 Character")]
        [MaxLength(100, ErrorMessage ="Title Must Max 100 character")]
        public string? title { get; set; }
        [Required]
        [MinLength(4, ErrorMessage ="Title Must Min 4 Character")]
        [MaxLength(50, ErrorMessage ="Title Must Max 50 character")]
        public string? author { get; set; }
        [Required]
        [MinLength(4, ErrorMessage ="Title Must Min 4 Character")]
        [MaxLength(50, ErrorMessage ="Title Must Max 50 character")]
        public string? publisher { get; set; }
        public DateTime publishedDate { get; set; }
        [Required]
        [MinLength(2, ErrorMessage ="Title Must Min 2 Character")]
        [MaxLength(3, ErrorMessage ="Title Must Max 3 character")]
        public string? language { get; set; }
    }
    
    public class PostBookDto
    {
        [Required]
        [MinLength(2, ErrorMessage ="Title Must Min 2 Character")]
        [MaxLength(100, ErrorMessage ="Title Must Max 100 character")]
        public string? title { get; set; }
        [Required]
        [MinLength(4, ErrorMessage ="Title Must Min 4 Character")]
        [MaxLength(50, ErrorMessage ="Title Must Max 50 character")]
        public string? author { get; set; }
        [Required]
        [MinLength(4, ErrorMessage ="Title Must Min 4 Character")]
        [MaxLength(50, ErrorMessage ="Title Must Max 50 character")]
        public string? publisher { get; set; }
        public DateTime publishedDate { get; set; }
        [Required]
        [MinLength(2, ErrorMessage ="Title Must Min 2 Character")]
        [MaxLength(3, ErrorMessage ="Title Must Max 3 character")]
        public string? language { get; set; }
    }
    public class UpdateBookDto
    {
        [Required]
        [MinLength(2, ErrorMessage ="Title Must Min 2 Character")]
        [MaxLength(100, ErrorMessage ="Title Must Max 100 character")]
        public string title { get; set; }
        [Required]
        [MinLength(4, ErrorMessage ="Title Must Min 4 Character")]
        [MaxLength(50, ErrorMessage ="Title Must Max 50 character")]
        public string author { get; set; }
        [Required]
        [MinLength(4, ErrorMessage ="Title Must Min 4 Character")]
        [MaxLength(50, ErrorMessage ="Title Must Max 50 character")]
        public string publisher { get; set; }
        public DateTime publishedDate { get; set; }
        [Required]
        [MinLength(2, ErrorMessage ="Title Must Min 2 Character")]
        [MaxLength(3, ErrorMessage ="Title Must Max 3 character")]
        public string language { get; set; }
    }
    
}