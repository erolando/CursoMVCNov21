using System;

namespace HomeDepot.DataLayer.Entities
{
    public class ModelProduct
    {
        public int IdProducto { get; set; }

        public string CodigoBarras { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int IdCategoriaProducto { get; set; }

        public bool EsActivo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public byte[] Imagen { get; set; }
    }
}
