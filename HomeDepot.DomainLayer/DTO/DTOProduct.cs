using System.ComponentModel;

namespace HomeDepot.DomainLayer.DTO
{
    public class DTOProduct
    {
        [DisplayName(displayName:"ID")]
        public int IdProducto { get; set; }

        public string CodigoBarras { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int IdCategoriaProducto { get; set; }

        public byte[] Imagen { get; set; }
    }
}
