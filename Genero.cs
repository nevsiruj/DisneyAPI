using System.ComponentModel.DataAnnotations;

namespace DisneyAPI
{
    public class Genero
    {
        public int GeneroId { get; set; }

        [StringLength(20)]
        public string Nombre { get; set; } = string.Empty; 

    }
}
