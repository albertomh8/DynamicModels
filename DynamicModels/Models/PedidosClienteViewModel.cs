using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicModels.Models
{
    public class PedidosClienteViewModel
    {
        public List<Cliente> Clientes { get; set; }
        public List<Pedido> Pedidos { get; set; }
    }
}