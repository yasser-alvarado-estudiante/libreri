using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class Producto
    {
        private static char DIVISOR_TEXTO = '¨';

        public int id { get; set; }
        public string categoria { get; set; }
        public string descripcion { get; set; }
        public string marca { get; set; }
        public double precioCompra { get; set; }
        public double precioVenta { get; set; }              
        public int stock { get; set; }
        public string DataParaArchivo
        {
            get
            {
                return id.ToString() + DIVISOR_TEXTO
                     + categoria + DIVISOR_TEXTO
                     + descripcion + DIVISOR_TEXTO
                     + marca + DIVISOR_TEXTO
                     + precioCompra + DIVISOR_TEXTO
                     + precioVenta + DIVISOR_TEXTO
                     + stock.ToString();
            }
        }

        public Producto() { }
        public Producto(string linea)
        {
            string[] datos = linea.Split(DIVISOR_TEXTO);
            id = int.Parse(datos[0]);
            categoria = datos[1];
            descripcion = datos[2];
            marca = datos[3];
            precioCompra = double.Parse(datos[4]);
            precioVenta = double.Parse(datos[5]);                    
            stock = int.Parse(datos[6]);
        }
    }
}
