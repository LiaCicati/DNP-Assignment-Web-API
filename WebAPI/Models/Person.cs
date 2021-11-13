using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name Field is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Field is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Hair color Field is Required")]
        public string HairColor { get; set; }

        [Required(ErrorMessage = "Eye color Field is Required")]
        public string EyeColor { get; set; }

        [Required, Range(18, 120)] public int Age { get; set; }
        [Required, Range(1, 250)] public float Weight { get; set; }
        [Required, Range(30, 250)] public int Height { get; set; }

        [Required(ErrorMessage = "Sex Field is Required")]
        public string Sex { get; set; }
    }
}