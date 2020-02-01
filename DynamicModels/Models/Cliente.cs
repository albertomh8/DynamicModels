using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicModels.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Contacto { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}