using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyClient.Models
{
    [Table("Person")]
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("PersonID")]
        [Key]
        [Display(Name = "Person Id")]
        [Required(ErrorMessage = "Person ID is mandatory")]
        public int PersonID { get; set; }



        [Column("FirstName")]
        [Display(Name ="First Name")]
        [Required(ErrorMessage = "First Name is mandatory")]
        [StringLength(20, ErrorMessage = "First Name should be less than 20 characters")]

        public string FirstName { get; set; }



        [Column("LastName")]
        [Display(Name ="Last Name")]
        [Required(ErrorMessage = "Last Name is mandatory")]
        [StringLength(20, ErrorMessage = "Last Name should be less than 20 characters")]
        public string LastName { get; set; }


        [Column("Discriminator")]
        [Required(ErrorMessage = "Discriminator is mandatory")]
        [StringLength(20, ErrorMessage = "Discriminator should be less than 20 characters")]

        public string Discriminator { get; set; }

    }
}
