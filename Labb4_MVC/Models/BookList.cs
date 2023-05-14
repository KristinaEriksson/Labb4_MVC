using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb4_MVC.Models
{
    public class BookList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookListID { get; set; } = 0;
        [Required]
        [DisplayName("Borrowing date")]
        public DateTime BorrowingDate { get; set; }
        [Required]
        [DisplayName("Returning date")]
        public DateTime ReturningDate { get; set; }

        public bool Returned { get; set; }
        [Required]
        [DisplayName("Returned date")]
        public DateTime  ReturnedAt { get; set; }
        [DisplayName("Late/not returned")]
        public bool IsPastReturningDate { get; set; }

        [ForeignKey("Customers")]
        [DisplayName("Customer")]
        public int FK_CustomerID { get; set; }
        public virtual Customer? Customers { get; set; } 

        [ForeignKey("Books")]
        [DisplayName("Book")]
        public int FK_BookID { get; set; }
        public virtual Book? Books { get; set; } 


    }
}
