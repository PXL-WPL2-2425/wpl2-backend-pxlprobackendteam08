using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.DTOs
{
    public class UpdateTaskRequest
    {
        [Required(ErrorMessage = "ServiceID is verplicht voor updaten!")]
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "ServiceName is verplicht voor updaten!")]
        [StringLength(100, ErrorMessage = "Max 100 letters!")]
        public string ServiceName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is verplicht voor updaten!")]
        [StringLength(255, ErrorMessage = "Max 255 letters!")]
        public string Description { get; set; } = string.Empty;
    }
}
