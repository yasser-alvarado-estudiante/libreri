using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class Pedido
    {
        private static char DIVISOR_TEXTO = '¨';        
        
        public string nombre { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }
        public double montoTotal { get; set; }
        public string DataParaArchivo
        {
            get
            {
                return nombre + DIVISOR_TEXTO
                     + precio + DIVISOR_TEXTO
                     + cantidad.ToString()+DIVISOR_TEXTO
                     + montoTotal;
            }
        }

        public Pedido() { }
        public Pedido(string linea)
        {
            string[] datos = linea.Split(DIVISOR_TEXTO);
            nombre = datos[0];
            precio = double.Parse(datos[1]);
            cantidad = int.Parse(datos[2]);
            montoTotal = double.Parse(datos[3]);
        }        
    }
}
