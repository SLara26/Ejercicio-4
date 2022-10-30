using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatosBiblioteca.Accesos;
using DatosBiblioteca.Entidades;



namespace Cristhian
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //VALIDAR CON UN ERRORPROVIDER PARA QUE NO PASE AL SIGUIENTE SIN ANTES LLENAR EL CAMPO
            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                errorProvider1.SetError(txtCorreo, "Ingrese el Id del usuario");
                txtCorreo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtClave.Text))
            {
                errorProvider1.SetError(txtClave, "Ingrese la clave del usuario");
                txtClave.Focus();
                return;
            }


            //CREACION DE UN OBJETO DE TIPO USUARIO
            UsuarioAccesos usuarioAcceso = new UsuarioAccesos();
            Usuario usuario = new Usuario();

            //ASIGNACION DE LOS CAMPOS AL OBJETO USUARIO
            usuario = usuarioAcceso.Login(txtCorreo.Text, txtClave.Text);

            //CONDICION CUANDO EL USUARIO SEA NULO
            if (usuario == null)
            {
                MessageBox.Show("DATOS ERRONEOS");
                LimpiarControles();
                return;
            }
            MessageBox.Show("DATOS CORRECTOS");
            LimpiarControles();


            
            //Form2.Show();//LLAMADA DEL FORMULARIO REGISTRO
           



        }



        private void LimpiarControles()
        {
            txtCorreo.Clear();
            txtClave.Clear();
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();//CERRAR EL FORMULARIO
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtCorreo.Focus();
        }

    }
}
