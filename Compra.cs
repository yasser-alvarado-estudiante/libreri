using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class Compra
    {
        private static char DIVISOR_TEXTO = '¨';
                
        public string categoria { get; set; }
        public string descripcion { get; set; }
        public string marca { get; set; }
        public double precio { get; set; }        
        public int unidades { get; set; }
        public string DataParaArchivo
        {
            get
            {
                return categoria + DIVISOR_TEXTO
                     + descripcion + DIVISOR_TEXTO
                     + marca + DIVISOR_TEXTO
                     + precio + DIVISOR_TEXTO
                     + unidades.ToString();
            }
        }

        public Compra() { }
        public Compra(string linea)
        {
            string[] datos = linea.Split(DIVISOR_TEXTO);
            categoria = datos[0];
            descripcion = datos[1];
            marca = datos[2];
            precio = double.Parse(datos[3]);
            unidades = int.Parse(datos[4]);
        }
    }
}
