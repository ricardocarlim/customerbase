using System.ComponentModel.DataAnnotations;

namespace api.Resources
{
    public class SaveLogradouroResource
    {
        [Required]        
        public int ClienteId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Endereco { get; set; }        
    }
}
