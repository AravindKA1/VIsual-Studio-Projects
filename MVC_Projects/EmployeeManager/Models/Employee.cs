using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManager.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Required(ErrorMessage = "Employee ID is required")]
        [Column("EmployeeID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }


        [Required(ErrorMessage = "First Name id is required")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage = ("First Name must be less than 20 characters"))]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last Name id is required")]
        [Column("LastName")]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = ("Last Name must be less than 20 character"))]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Title is required")]
        [Column("Title")]
        [StringLength(30, ErrorMessage = "Title musst be less than 30 characters")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Birth date is required")]
        [Column("BirthDate")]
        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }


        [Required(ErrorMessage = "Hire date is required")]
        [Column("HireDate")]
        [Display(Name = "Date of Hiring")]
        public DateTime HireDate { get; set; }


        [Required(ErrorMessage = "Country is required")]
        [Column("Country")]
        [StringLength(20, ErrorMessage = "Country Name must be 20 characters long")]
        public string Country { get; set; }

        [Column("Notes")]
        [StringLength(500, ErrorMessage = "Notes must be less than 500 characters")]
        public string Notes { get; set; }


    }
}

