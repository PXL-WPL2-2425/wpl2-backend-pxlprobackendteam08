using System.ComponentModel.DataAnnotations;

namespace WebApiTeam08.DTOs
{
    public class TaskRequest
    {
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(255)]
        public required string CompanyName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Incorrect email.")]
        public required string Email { get; set; }

        [Required]
        [RegularExpression(@"^(\+?[0-9\s\-]+)$", ErrorMessage = "Incorrect phone number.")]
        public required string Phone { get; set; }

        [Required]
        [StringLength(255)]
        public required string Address { get; set; }

        [Required]
        [RegularExpression(@"^(ALG|BIN|BUI)$", ErrorMessage = "The type of service must be: ALG, BIN or BUI.")]
        public required string ServiceType { get; set; }

        [Required]
        [StringLength(100)]
        public required string ServiceName { get; set; }

        [Required]
        [StringLength(255, ErrorMessage ="Max 255 characters.")]
        public required string Description { get; set; }
    }
}
