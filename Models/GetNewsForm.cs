using System.ComponentModel.DataAnnotations;

namespace Crito.Models
{
    public class GetNewsForm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

    }
}
