using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Presentacion
{
    class ListaPedidos
    {
        List<Pedido> pedidos = new List<Pedido>();
        public void agregarPedido(Pedido pedidoNuevo)
        {
            pedidos.Add(pedidoNuevo);
        }
        public void eliminarPedido(int index)
        {
            pedidos.RemoveAt(index);
        }
        public List<Pedido> getLista()
        {
            return pedidos;
        }
        public string guardarEnArchivoPedidos()
        {
            string error = "";
            try
            {

                StreamWriter sw = new StreamWriter("Pedidos.txt");

                foreach (Pedido aux in pedidos)
                {
                    sw.WriteLine(aux.DataParaArchivo);
                }

                sw.Close();
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return error;

        }
        public string cargarDesdeArchivoPedidos()
        {
            string error = "";
            try
            {

                pedidos = new List<Pedido>();

                StreamReader sr = new StreamReader("Pedidos.txt");
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    pedidos.Add(new Pedido(linea));
                    //Leer linea
                }
                sr.Close();
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return error;

        }
    }
}
