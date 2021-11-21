using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Presentacion
{
    class ListaProductos
    {
        List<Producto> productos = new List<Producto>();
        public void agregarProducto(Producto productoNuevo)
        {
            productos.Add(productoNuevo);
        }
        public void eliminarProducto(int index)
        {
            productos.RemoveAt(index);
        }
        public List<Producto> getLista()
        {
            return productos;
        }
        public string guardarEnArchivo()
        {
            string error = "";
            try
            {

                StreamWriter sw = new StreamWriter("Productos.txt");

                foreach (Producto aux in productos)
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
        public string cargarDesdeArchivo()
        {
            string error = "";
            try
            {

                productos = new List<Producto>();

                StreamReader sr = new StreamReader("Productos.txt");
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    productos.Add(new Producto(linea));
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
