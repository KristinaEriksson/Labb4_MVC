using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb4_MVC.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Customer id")]
        public int CustomerID { get; set; } = 0;
        [Required]
        [StringLength(50)]
        [DisplayName("First name")]
        public string FirstName { get; set; } = default!;
        [Required]
        [StringLength(50)]
        [DisplayName("Last name")]
        public string LastName { get; set; } = default!;
        public string FullName => $"{FirstName} {LastName}";
        [Required]
        [StringLength(70)]
        public string Address { get; set; } = default!;
        [Required]
        [StringLength(30)]
        public string City { get; set; } = default!;
        [Required]
        [MinLength(9), MaxLength(15)]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; } = default!;

        public virtual ICollection<BookList>? BookLists { get; set; } //Navigation
    }
}
