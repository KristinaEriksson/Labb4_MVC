using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb4_MVC.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Book id")]
        public int BookID { get; set; } = 0;

        [Required]
        [StringLength(50)]
        public string Title { get; set; } = default!;

        [Required]
        [StringLength(100)]
        public string Author { get; set; } = default!;

        [StringLength(50)]
        public string Series { get; set; } = default!;

        public DateTime Publised { get; set; }

        public string BookDisplay => $"{Title} - {Author}";

        public virtual ICollection<BookList>? BookLists { get; set; } // Navigation
    }
}
