using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlazorWasmApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide valid first name.")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required, Display(Name = "last name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 0)]
        public string Address { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
