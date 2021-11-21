using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Presentacion
{
    class ListaEgreso
    {
        List<PagarProductos> pago = new List<PagarProductos>();
        public void agregarPago(PagarProductos pagoNuevo)
        {
            pago.Add(pagoNuevo);
        }

        public void eliminarPago(int posicion)
        {
            pago.RemoveAt(posicion);
        }

        public List<PagarProductos> getLista()
        {
            return pago;
        }

        public int cantidadPagos()
        {
            return pago.Count;
        }

        public string guardarEnArchivoPagos()
        {
            string error = "";
            try
            {

                StreamWriter sw = new StreamWriter("Egresos.txt");

                foreach (PagarProductos aux in pago)
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

        public string cargarDesdeArchivoPagos()
        {
            string error = "";
            try
            {

                pago = new List<PagarProductos>();

                StreamReader sr = new StreamReader("Egresos.txt");
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    pago.Add(new PagarProductos(linea));
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
