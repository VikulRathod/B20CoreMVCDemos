using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ValidationsDemo.Common;

namespace ValidationsDemo.Models
{
    public class StudentModel
    {
        public int RollNumber { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        //[MinLength(2)]
        //[MaxLength(50)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name should be 2 to 50 characters long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter mobile number")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        // [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})$", ErrorMessage = "Please enter valid email")]
        // [EmailAddress(ErrorMessage = "Please enter valid email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter age")]
        [Range(1, 150, ErrorMessage = "Please enter valid age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage ="Please enter strong password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Please enter password again")]
        [Compare("Password", ErrorMessage = "Password and Confirm Pasword should be same")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter admission date")]
        [DisplayName("Admission Date")]
        [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DateValidation(ErrorMessage = "Admission date should be less than todays date")]
        public DateTime? AdmissionDate { get; set; }
    }
}
