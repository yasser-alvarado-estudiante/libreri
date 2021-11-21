using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Presentacion
{
    class ListaUsuario
    {
        List<Usuario> usuarios = new List<Usuario>();
        public void agregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);

        }
        public void eliminarUsuario(int index)
        {
            usuarios.RemoveAt(index);
        }

        public bool existeUsuario(Usuario usuarioComprobar)
        {
            foreach (Usuario aux in usuarios)
            {
                if (aux.usuario == usuarioComprobar.usuario)
                {
                    if (aux.contraseña == usuarioComprobar.contraseña)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public List<Usuario> getLista()
        {
            return usuarios;
        }
        public string guardarEnArchivo()
        {
            string error = "";
            try
            {
                StreamWriter sw = new StreamWriter("Usuario.txt");

                foreach (Usuario aux in usuarios)
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
                usuarios = new List<Usuario>();

                StreamReader sr = new StreamReader("Usuario.txt");
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    usuarios.Add(new Usuario(linea));
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
