using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicModels.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public DateTime Fecha_Pedido { get; set; }
        public int Unidades { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}