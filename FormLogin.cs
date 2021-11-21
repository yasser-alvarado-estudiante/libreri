using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Presentacion
{
    public partial class FormLogin : Form
    {
        ListaUsuario lista = new ListaUsuario();

        public FormLogin()
        {
            InitializeComponent();
            string error = lista.cargarDesdeArchivo();            
            if (error != "")
            {
                MessageBox.Show(error);
            }

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
               

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        
        private void btnLogin_Click(object sender, EventArgs e)
        {

            String usuario = txtUser.Text;
            String contraseña = txtPass.Text;
            Usuario consultar = new Usuario();
            consultar.usuario = usuario;
            consultar.contraseña = contraseña;         


            if ((txtUser.Text != "USUARIO") && (txtPass.Text != "CONTRASEÑA"))
            {
                if (lista.existeUsuario(consultar))
                {
                    this.Hide();
                    FormWelcome welcome =new FormWelcome();
                    welcome.ShowDialog();

                    FormPrincipal formularioPrincipal = new FormPrincipal();
                    formularioPrincipal.Show();
                    formularioPrincipal.FormClosed += LogOut;
                    this.Hide();
                }
                else
                {
                    msgError("Usuario o contraseña incorrectos.  \n     Inténtalo de nuevo");
                    txtPass.Text = "CONTRASEÑA";
                    txtUser.Focus();
                }
            }
        }
        private void msgError(string msg)
        {
            lblErrorMessage.Text = "     " + msg;
            lblErrorMessage.Visible = true;
        }
        private void LogOut(object sender, FormClosedEventArgs e)
        {
            txtPass.Text = "CONTRASEÑA";
            txtPass.UseSystemPasswordChar = false;
            txtUser.Text = "USUARIO";
            lblErrorMessage.Visible = false;
            this.Show();
            //txtUser.Focus();
        }
    }
}
