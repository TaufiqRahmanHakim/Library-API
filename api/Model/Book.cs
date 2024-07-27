using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Book
    {
        public int id { get; set; }
        public string? title { get; set; } = string.Empty;
        public string? author { get; set; }= string.Empty;
        public string? publisher { get; set; }= string.Empty;
        public DateTime publishedDate { get; set; } 
        public string? language { get; set; }= string.Empty;

    }
}