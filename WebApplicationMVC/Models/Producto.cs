using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Stock es obligatorio!")]
        public int Stock{ get; set; }
        [Required(ErrorMessage = "Precio es obligatorio!")]
        public int Precio{ get; set; }
        [Required]
        public string? UrlImagen { get; set; }
        [Required]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
