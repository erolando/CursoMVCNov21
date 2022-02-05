using System.ComponentModel.DataAnnotations;

namespace HomeDepot.DomainLayer.RQ
{
    public class RQProduct
    {
        [Required]
        public string CodigoBarras { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int IdCategoriaProducto { get; set; }

        public byte[] Imagen { get; set; }
    }
}
