using System.ComponentModel.DataAnnotations;

namespace api.Resources
{
    public class SaveClienteResource
    {
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]        
        public string Logotipo { get; set; }        
    }
}
