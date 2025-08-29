using System;
using System.ComponentModel.DataAnnotations;

namespace BookLibraryAPI.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public int Year { get; set; }

        public string? Description { get; set; }
    }

}
