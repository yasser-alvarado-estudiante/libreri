using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class Usuario
    {
        public static char TOKEN = '¨';

        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string DataParaArchivo
        {
            get
            {
                return usuario + TOKEN + contraseña;
            }
        }

        public Usuario() { }
        public Usuario(string linea) 
        {

            string[] datos = linea.Split(TOKEN);
            usuario = datos[0];
            contraseña = datos[1];
        }
    }
}
