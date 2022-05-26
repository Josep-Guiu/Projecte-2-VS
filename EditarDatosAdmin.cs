using Proyecto2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2
{
    public partial class EditarDatosAdmin : Form
    {
        usuaris admin = null;
        String pasoDeFoto;
        public EditarDatosAdmin()
        {
            InitializeComponent();
        }
        public EditarDatosAdmin(usuaris administrador)
        {
            InitializeComponent();
            admin = administrador;
        }

        private void EditarDatosAdmin_Load(object sender, EventArgs e)
        {
            CargarAdmin();
            CargarImagen();
        }

        private void CargarAdmin() {
            textBoxNombreAdmin.Text = admin.nom.ToUpper();
            textBoxCorreoAdmin.Text = admin.correu.ToUpper();
            textBoxNuevoNombre.Text = admin.nom;
            textBoxNuevoCorreo.Text = admin.correu;
            textBoxNuevaPass.Text = admin.contrasenia;
            textBoxNuevoAnio.Text = admin.any_naixement.ToString();
            textBoxNuevoTlfn.Text = admin.telefono;
            textBoxNuevoDni.Text = admin.dni;
            textBoxNuevaDirec.Text = admin.direccion;
            checkBoxActivo.Checked = admin.actiu;
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            String missatge = "";
            DialogResult modificar = MessageBox.Show("Seguro que quieres modificar tus datos?", "Modificar Datos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (modificar == DialogResult.OK)
            {
            admin.nom = textBoxNombreAdmin.Text;
            admin.correu = textBoxCorreoAdmin.Text;
            admin.nom = textBoxNuevoNombre.Text;
            admin.correu = textBoxNuevoCorreo.Text;
                if (checkBoxModificarContraseña.Checked)
                {
                    textBoxNuevaPass.Enabled = true;
                    admin.contrasenia = Encriptar(textBoxNuevaPass.Text);
                }
            if (String.IsNullOrEmpty(textBoxNuevoAnio.Text))
            {
                admin.any_naixement = null;
            }
            else {
                admin.any_naixement = int.Parse(textBoxNuevoAnio.Text);
            }
            admin.telefono = textBoxNuevoTlfn.Text;
            admin.dni = textBoxNuevoDni.Text;
            admin.direccion = textBoxNuevaDirec.Text;
            admin.actiu = checkBoxActivo.Checked;
                if (ControlErrores())
                {
                    missatge = UsuarisOrm.Update();
                    if (missatge != "")
                    {
                        MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    CargarAdmin();
                }
            }
            
        }

        private String Encriptar(String pass) {
            string myPassword = pass;
            int mySalt = 12;
            string contraCodificada = BCrypt.Net.BCrypt.HashPassword(myPassword, mySalt);


            return contraCodificada;
        }

        private void CargarImagen() {
            imatge_usuari _imatge = ImagenOrm.CargarImatgeUsuari(admin);
            if (_imatge != null)
            {
                //jgCircularPicturesBoxAdminImage.Image = Image.FromStream(DeByteAImag(_imatge));
                jgCircularPicturesBoxAdminImage.Image = Image.FromFile("../../../ImagenesUsuario/" + _imatge.imatge_nom);
            }
            else
            {
                jgCircularPicturesBoxAdminImage.Image = null;
            }
        }
        //private MemoryStream DeByteAImag(imatge_usuari _imatge)
        //{
        //    byte[] img = (byte[])_imatge.imatge;
        //    MemoryStream ms = new MemoryStream(img);
        //    return ms;
        //}

        private void checkBoxModificarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxModificarContraseña.Checked)
            {
                textBoxNuevaPass.Enabled = true;
                textBoxNuevaPass.Text = "";
            }
            else
            {
                textBoxNuevaPass.Enabled = false;
                textBoxNuevaPass.Text = admin.contrasenia;
            }
        }

        private bool ControlErrores() {
            bool control = true;
            if (String.IsNullOrEmpty(textBoxNuevoNombre.Text))
            {
                control = false;
                MessageBox.Show("El campo Nombre* no tiene datos", "Error de Modificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (String.IsNullOrEmpty(textBoxNuevoCorreo.Text))
            {
                control = false;
                MessageBox.Show("El campo Correo* no tiene datos", "Error de Modificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return control;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            String missatge = "";
            usuaris _usuaris = admin;
            imatge_usuari _imatge = ImagenOrm.CargarImatgeUsuari(_usuaris);
            if (_imatge == null)
            {
                _imatge = new imatge_usuari();
                _imatge.id_usuari = _usuaris.id;
                _imatge.imatge_nom = textBoxNuevoDni.Text + ".jpg";
                missatge = ImagenOrm.Insert(_imatge);
                if (missatge != "")
                {
                    MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                GuardarFoto();
            }else
            {
                _imatge.id_usuari = _usuaris.id;
                _imatge.imatge_nom = textBoxNuevoDni.Text + ".jpg";
                missatge = ImagenOrm.UpdateImatgeUsuari();
                if (missatge != "")
                {
                    MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                GuardarFoto();
                MessageBox.Show("Su imagen se ha actualizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _imatge = ImagenOrm.CargarImatgeUsuari(_usuaris);
                if (_imatge != null)
                {
                    jgCircularPicturesBoxAdminImage.Image = Image.FromFile("../../../ImagenesUsuario/" + _imatge.imatge_nom);
                }
                else
                {
                    jgCircularPicturesBoxAdminImage.Image = null;
                    jgCircularPicturesBoxAdminImage.Image = Image.FromFile("../../../ImagenesUsuario/" + _imatge.imatge_nom);
                }
            }
        }
        private void GuardarFoto()
        {
            string path = "../../../ImagenesUsuario/" + textBoxNuevoDni.Text + ".jpg";
            bool result = File.Exists(path);
            if (result == true)
            {
                File.Delete("../../../ImagenesUsuario/" + textBoxNuevoDni.Text + ".jpg");
                System.IO.File.Copy(pasoDeFoto, "../../../ImagenesUsuario/" + textBoxNuevoDni.Text + ".jpg");
            }
            else
            {
                System.IO.File.Copy(pasoDeFoto, "../../../ImagenesUsuario/" + textBoxNuevoDni.Text + ".jpg");
            }


        }

        private void jgCircularPicturesBoxAdminImage_Click(object sender, EventArgs e)
        {

            jgCircularPicturesBoxAdminImage.Image = null;
            OpenFileDialog buscaFoto = new OpenFileDialog(); 
                buscaFoto.InitialDirectory = "C:\\";
                buscaFoto.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*jpg;*.jpeg|PNG (*.png)|*.png|GIF (*.gif)|*.gif";
                if (buscaFoto.ShowDialog() == DialogResult.OK)
                {
                    jgCircularPicturesBoxAdminImage.ImageLocation = buscaFoto.FileName;
                    pasoDeFoto = buscaFoto.FileName;
                }
                else
                {
                    MessageBox.Show("No has seleccionado una imagen", "Error Comprobación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }
    }
}
