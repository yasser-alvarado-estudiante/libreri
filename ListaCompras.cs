using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Presentacion
{
    class ListaCompras
    {
        List<Compra> compras = new List<Compra>();
        public void agregarCompra(Compra compraNuevo)
        {
            compras.Add(compraNuevo);
        }
        public void eliminarCompra(int index)
        {
            compras.RemoveAt(index);
        }
        public List<Compra> getLista()
        {
            return compras;
        }
        public string guardarEnArchivoCompras()
        {
            string error = "";
            try
            {

                StreamWriter sw = new StreamWriter("Compras.txt");

                foreach (Compra aux in compras)
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
        public string cargarDesdeArchivoCompras()
        {
            string error = "";
            try
            {

                compras = new List<Compra>();

                StreamReader sr = new StreamReader("Compras.txt");
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    compras.Add(new Compra(linea));
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
