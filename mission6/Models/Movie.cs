using System.ComponentModel.DataAnnotations;

namespace mission6.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public string Category { get; set; }

        public string Title { get; set; }

        public string Year {  get; set; }

        public string Director { get; set; }

        public string Rating { get; set; }

        public bool Edited
        { get; set; }

        public string? LentTo {  get; set; } //? allows value to be null

        public string? Notes { get; set; } //? allows value to be null
    }
}
