using System.ComponentModel.DataAnnotations;

namespace Crito.Models.Entities
{
    public class GetNewsEntity
    {
        [Key]
        public string Email { get; set; } = null!;

    }
}
