using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class PagarProductos
    {
        private static char DIVISOR_TEXTO = '-';

        public string nombreEmpresa { get; set; }
        public string tipoProducto { get; set; }
        public int cantidad { get; set; }
        public double monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string DataParaArchivo
        {
            get
            {
                return nombreEmpresa + DIVISOR_TEXTO
                    + tipoProducto + DIVISOR_TEXTO
                    + cantidad.ToString() + DIVISOR_TEXTO
                    + monto + DIVISOR_TEXTO
                    + FechaPago.ToString();
            }
        }
        public PagarProductos() { }
        public PagarProductos(string linea)
        {
            string[] datos = linea.Split(DIVISOR_TEXTO);
            nombreEmpresa = datos[0];
            tipoProducto = datos[1];
            cantidad = int.Parse(datos[2]);
            monto = double.Parse(datos[3]);
            FechaPago = DateTime.Parse(datos[4]);
        }
    }
}
