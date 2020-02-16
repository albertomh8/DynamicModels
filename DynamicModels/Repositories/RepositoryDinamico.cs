using DynamicModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;

namespace DynamicModels.Repositories
{
    public class RepositoryDinamico
    {
        public List<Cliente> CrearClientes()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente {ClienteId=1,Nombre="MKL",Contacto="David",Direccion="Calle 1", Telefono="54-424-1231"},
                new Cliente {ClienteId=2,Nombre="SFK",Contacto="Felix",Direccion="Calle 2", Telefono="12-645-9757"},
                new Cliente {ClienteId=3,Nombre="PTR",Contacto="Ricardo",Direccion="Calle 3",Telefono="86-468-4683"},
                new Cliente {ClienteId=4,Nombre="LDC",Contacto="Elena",Direccion="Calle 4",Telefono="23-234-0657"}
            };
            clientes[0].Pedidos = new List<Pedido> { new Pedido { PedidoId = 1, Fecha_Pedido = Convert.ToDateTime("12/06/2005"), Unidades = 37, ClienteId = 1 },
                                                     new Pedido { PedidoId = 2, Fecha_Pedido=Convert.ToDateTime("14/07/2005"), Unidades = 56, ClienteId = 1 }};

            clientes[1].Pedidos = new List<Pedido> { new Pedido { PedidoId = 1, Fecha_Pedido = Convert.ToDateTime("12/06/2005"), Unidades = 37, ClienteId = 2 } };

            clientes[2].Pedidos = new List<Pedido> { new Pedido { PedidoId = 1, Fecha_Pedido = Convert.ToDateTime("12/06/2005"), Unidades = 37, ClienteId = 3 },
                                                     new Pedido { PedidoId = 2, Fecha_Pedido=Convert.ToDateTime("14/07/2005"), Unidades = 56, ClienteId = 3 },
                                                     new Pedido { PedidoId = 2, Fecha_Pedido=Convert.ToDateTime("25/08/2006"), Unidades = 56, ClienteId = 3 }};
            return clientes;
        }

        public List<Pedido> CrearPedidos()
        {
            List<Pedido> pedidos = new List<Pedido>
            {
                new Pedido {PedidoId=1,Fecha_Pedido=Convert.ToDateTime("12/06/2005"),Unidades=37, ClienteId = 1},
                new Pedido {PedidoId=2,Fecha_Pedido=Convert.ToDateTime("14/07/2005"),Unidades=56, ClienteId = 2},
                new Pedido {PedidoId=3,Fecha_Pedido=Convert.ToDateTime("14/07/2005"),Unidades=12, ClienteId = 3},
                new Pedido {PedidoId=4,Fecha_Pedido=Convert.ToDateTime("25/08/2006"),Unidades=20, ClienteId = 3},

            };
            return pedidos;
        }

        public IQueryable<object> ColeccionAnonima()
        {
            List<Cliente> clientes = CrearClientes();
            List<Pedido> pedidos = CrearPedidos();

            var datos = from c in clientes
                        join p in pedidos
                        on c.ClienteId equals p.ClienteId
                        select new
                        {
                            c.ClienteId,
                            c.Nombre,
                            p.Fecha_Pedido,
                            p.Unidades
                        };

            return datos.AsQueryable();
        }

        public IDictionary<string, object> ObjetoAnonimo(object item)
        {
            IDictionary<string, object> expandoItem = new ExpandoObject();
            foreach (PropertyDescriptor propiedad in TypeDescriptor.GetProperties(item.GetType()))
            {
                expandoItem.Add(propiedad.Name,
                       propiedad.GetValue(item));
            }
            return expandoItem;
        }

        public List<ExpandoObject> ListaAnonima(IQueryable<object> consulta)
        {
            List<ExpandoObject> datos = new List<ExpandoObject>();

            foreach (var item in consulta)
            {
                IDictionary<string, object> itemExpando = new ExpandoObject();
                foreach (PropertyDescriptor propiedad in TypeDescriptor.GetProperties(item.GetType()))
                {
                    itemExpando.Add(propiedad.Name, propiedad.GetValue(item));
                }
                datos.Add(itemExpando as ExpandoObject);
            }
            return datos;
        }
    }
}