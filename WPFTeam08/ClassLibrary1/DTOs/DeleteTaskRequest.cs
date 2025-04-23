using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.DTOs
{
    public class DeleteTaskRequest
    {
        [Required(ErrorMessage = "ServiceID is verplicht voor verwijdering!")]
        public int ServiceID { get; set; }
    }
}
