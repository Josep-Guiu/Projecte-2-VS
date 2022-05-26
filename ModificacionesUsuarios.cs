using Proyecto2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2
{

    
    public partial class ModificacionesUsuarios : Form
    {
        usuaris administrador;
        String pasoDeFoto;
        public ModificacionesUsuarios()
        {
            InitializeComponent();
        }

        public ModificacionesUsuarios(usuaris superAdmin)
        {
            InitializeComponent();
            administrador = superAdmin;
        }
        private void checkBoxActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxActivo.Checked)
            {
                checkBoxActivo.ForeColor = Color.FromArgb(50, 205, 50);
            }
            else {
                checkBoxActivo.ForeColor = Color.FromArgb(186, 0, 0);
            }
        }

        private void selectTotal()
        {
            bindingSourceUsuarios.DataSource = UsuarisOrm.SelectPorId();
            bindingSourceRols.DataSource = RolsOrm.SelectRols();
        }

        private void ModificacionesUsuarios_Load(object sender, EventArgs e)
        {
            selectTotal();
            comboBoxRoles.SelectedIndex = 3;
            cursos _curs = CursosOrm.SelectCursosAct(true);
            textBoxCursoActivo.Text = _curs.curs_inici + "  -  " + _curs.curs_fi;
        }

        private void dataGridViewCursos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                Reset();
                usuaris _usuari = (usuaris)dataGridViewUsuaris.CurrentRow.DataBoundItem;
                textBoxNombre.Text = _usuari.nom.ToString();
                textBoxCorreo.Text = _usuari.correu.ToString();
                textBoxContra.Text = _usuari.contrasenia.ToString();
                comboBoxRoles.Text = _usuari.rols.nom;
            if (_usuari.any_naixement != null)
            {
                textBoxNacimiento.Text = _usuari.any_naixement.ToString();
            }
            else {
                textBoxNacimiento.Text = "";
            }
            if (_usuari.telefono != null)
            {
                textBoxTlfn.Text = _usuari.telefono.ToString();
            }
            else
            {
                textBoxTlfn.Text = "";
            }
            if (_usuari.dni != null)
            {
                textBoxDni.Text = _usuari.dni.ToString();
            }
            else
            {
                textBoxDni.Text = "";
            }
            if (_usuari.direccion != null)
            {
                textBoxDireccion.Text = _usuari.direccion.ToString(); 
            }
            else
            {
                textBoxDireccion.Text = "";
            }
                checkBoxActivo.Checked = _usuari.actiu;
            
            imatge_usuari _imatge = ImagenOrm.CargarImatgeUsuari(_usuari);
            if (_imatge != null)
            {
                //jgCircularPicturesBoxImagenUser.Image = Image.FromStream(DeByteAImag(_imatge));
                jgCircularPicturesBoxImagenUser.Image = Image.FromFile("../../../ImagenesUsuario/" + /*_imatge.imatge_nom*/_usuari.dni + ".jpg");
            }
            else {
                jgCircularPicturesBoxImagenUser.Image = null;
            }
            
        }

        private void Reset() {
            textBoxNombre.ResetText();
            textBoxCorreo.ResetText();
            textBoxContra.ResetText();
            textBoxNacimiento.ResetText();
            textBoxTlfn.ResetText();
            textBoxDni.ResetText();
            textBoxDireccion.ResetText();
            checkBoxActivo.Checked = true;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            String missatge = "";
            usuaris _usuaris = (usuaris)dataGridViewUsuaris.CurrentRow.DataBoundItem;
            DialogResult dR = MessageBox.Show("¿Quieres borrar a este usuario?", "Eliminar usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dR == DialogResult.OK)
            {
                missatge = UsuarisOrm.Delete((usuaris)dataGridViewUsuaris.SelectedRows[0].DataBoundItem);
                if (missatge != "")
                {
                    MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                selectTotal();
                Reset();
            }
            else
            {
                MessageBox.Show("Usuario NO borrado", "Eliminar usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewUsuaris_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            String missatge = "";
            if (dataGridViewUsuaris.SelectedRows.Count > 0)
            {
                DialogResult dR = MessageBox.Show("¿Quieres borrar este usuario?", "Eliminar usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dR == DialogResult.OK)
                {
                    missatge = UsuarisOrm.Delete((usuaris)dataGridViewUsuaris.SelectedRows[0].DataBoundItem);
                    if (missatge != "")
                    {
                        MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    selectTotal();
                    Reset();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            String missatge = "";
            String missatge2 = "";
            imatge_usuari _imatge = new imatge_usuari();
            usuaris _usuaris = (usuaris)dataGridViewUsuaris.CurrentRow.DataBoundItem;
            DialogResult dR = MessageBox.Show("¿Quieres modificar a este usuario?", "Modificar usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dR == DialogResult.OK)
            {
                _usuaris.nom = textBoxNombre.Text;
                _usuaris.correu = textBoxCorreo.Text;
                _usuaris.contrasenia = textBoxContra.Text;
                _usuaris.any_naixement = int.Parse(textBoxNacimiento.Text);
                _usuaris.telefono = textBoxTlfn.Text;
                _usuaris.dni = textBoxDni.Text;
                _usuaris.direccion = textBoxDireccion.Text;
                _usuaris.actiu = checkBoxActivo.Checked;
                rols _rols = (rols)comboBoxRoles.SelectedItem;
                _usuaris.rols_id = _rols.id;

                if (ControlDeDatos())
                {
                    missatge2 = UsuarisOrm.Update();
                    if (missatge2 != "")
                    {
                        MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Reset();
                    selectTotal();
                    RecargaLista(_rols.id);
                }
                //usuaris _usuaris1 = (usuaris)dataGridViewUsuaris.CurrentRow.DataBoundItem;
                //if (jgCircularPicturesBoxImagenUser != null && !ImagenOrm.IsInUsuari(_usuaris))
                //{
                    
                //    _imatge.id_usuari = _usuaris1.id;
                //    _imatge.imatge_nom = pasoDeFoto;
                //    missatge = ImagenOrm.Insert(_imatge);
                //    if (missatge != "")
                //    {
                //        MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
                //else {
                //    _imatge.id_usuari = _usuaris1.id;
                //    _imatge.imatge_nom = pasoDeFoto;
                //    missatge = ImagenOrm.UpdateImatgeUsuari();
                //    if (missatge != "")
                //    {
                //        MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}

            }
            else
            {
                MessageBox.Show("Usuario NO modificado", "Modificar usuario", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private bool ControlDeDatos()
        {
            bool control = true;

            if (String.IsNullOrEmpty(textBoxNombre.Text))
            {
                MessageBox.Show("Rellena el campo del nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                control = false;
            }
            if (String.IsNullOrEmpty(textBoxCorreo.Text))
            {
                MessageBox.Show("Rellena el campo del correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                control = false;
            }
            else {
                control = ComprobarCorreo(textBoxCorreo.Text);
            }
            if (String.IsNullOrEmpty(textBoxNacimiento.Text))
            {
                MessageBox.Show("Rellena el campo del año", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                control = false;
            }
            if (String.IsNullOrEmpty(textBoxTlfn.Text))
            {
                MessageBox.Show("Rellena el campo del año", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                control = false;
            }
            else {
                control = ComprobarTelefono(textBoxTlfn.Text);
            }
            if (String.IsNullOrEmpty(textBoxDni.Text))
            {
                MessageBox.Show("Rellena el campo del dni", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                control = false;
            }
            else
            {
                control = ComprobarDni(textBoxDni.Text);
            }
            if (String.IsNullOrEmpty(textBoxDireccion.Text))
            {
                MessageBox.Show("Rellena el campo de la dirección", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                control = false;
            }
            return control;
        }


        private bool ComprobarCorreo(String email)
        {
            bool isCorrecto = true;
            String expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    isCorrecto = true;
                }
                else
                {
                    isCorrecto = false;
                    MessageBox.Show("El formato del correo no corresponde al formato válido", "Error Comprobación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                isCorrecto = false;
            }
            return isCorrecto;
        }

        private bool ComprobarTelefono(String telf)
        {
            bool isCorrecto = true;
            if (telf.Length != 9)
            {
                isCorrecto = false;
                MessageBox.Show("La longitud del nº del teléfono no corresponde al formato válido", "Error Comprobación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isCorrecto;
        }

        private bool ComprobarDni(String dni)
        {
            bool isCorrecto = true;
            if (dni.Length != 9)
            {
                isCorrecto = false;
                MessageBox.Show("La longitud del nº del DNI no corresponde al formato válido", "Error Comprobación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isCorrecto;
        }

        private void radioButtonVerAdministradores_CheckedChanged(object sender, EventArgs e)
        {
            bindingSourceUsuarios.DataSource = UsuarisOrm.SelectPorRoles();
        }

        private void radioButtonActivoTodos_CheckedChanged(object sender, EventArgs e)
        {
            bindingSourceUsuarios.DataSource = UsuarisOrm.Select();
        }

        private void radioButtonActivoFalse_CheckedChanged(object sender, EventArgs e)
        {
            bindingSourceUsuarios.DataSource = UsuarisOrm.Select(false);
        }

        private void radioButtonActivoTrue_CheckedChanged(object sender, EventArgs e)
        {
            bindingSourceUsuarios.DataSource = UsuarisOrm.Select(true);
        }

        private void RecargaLista(int rolId) {
            bindingSourceUsuarios.DataSource = UsuarisOrm.SelectPorRoles(rolId);
        }

        private void jgCircularPicturesBoxImagenUser_Click(object sender, EventArgs e)
        {

            jgCircularPicturesBoxImagenUser.Image = null;
            OpenFileDialog buscaFoto = new OpenFileDialog();
            buscaFoto.InitialDirectory = "C:\\";
            buscaFoto.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*jpg;*.jpeg|PNG (*.png)|*.png|GIF (*.gif)|*.gif";
            if (buscaFoto.ShowDialog() == DialogResult.OK)
            {
                jgCircularPicturesBoxImagenUser.ImageLocation = buscaFoto.FileName;
                pasoDeFoto = buscaFoto.FileName;
            }
            else
            {
                MessageBox.Show("No has seleccionado una imagen", "Error Comprobación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //--------------------------------- PARA CONVERTIR LA IMAGEN DESEADA A BYTES Y PODER SUBIRLO O DESCARGARLO A OTRO SISTEMA, NO LO USAMOS
        //PORQUE SIGNIFICA QUE ESA ARRAY SE GUARDA Y NO ES CONVENIENTE PORQUE HACE QUE NUESTRA BD NO PUEDA PROCESAR LOS SCRIPTS GENERADOS------

        //private byte[] ConvertirImagen() {
        //    System.IO.MemoryStream ms = new System.IO.MemoryStream();
        //    jgCircularPicturesBoxImagenUser.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    return ms.GetBuffer();
        //}

        //private MemoryStream DeByteAImag(imatge_usuari _imatge) {
        //    byte[] img = (byte[])_imatge.imatge;
        //    MemoryStream ms = new MemoryStream(img);
        //    return ms;
        //}

        private void buttonSave_Click(object sender, EventArgs e)
        {
            String missatge = "";
            usuaris _usuaris = (usuaris)dataGridViewUsuaris.CurrentRow.DataBoundItem;
            //imatge_usuari _imatge = new imatge_usuari();
            imatge_usuari _imatge = ImagenOrm.CargarImatgeUsuari(_usuaris);
            if (_imatge == null)
            {
                _imatge = new imatge_usuari();
                _imatge.id_usuari = _usuaris.id;
                _imatge.imatge_nom = textBoxDni.Text + ".jpg";
                missatge = ImagenOrm.Insert(_imatge);
                if (missatge != "")
                {
                    MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                GuardarFoto();
            }

            //if (!ImagenOrm.IsInUsuari(_usuaris))
            //{

            //    _imatge.id_usuari = _usuaris.id;
            //    _imatge.imatge_nom = textBoxDni.Text + ".jpg";
            //    ImagenOrm.Insert(_imatge);
            //    GuardarFoto();
            //}
            else
            {
                //ImagenOrm.MatarFoto(_usuaris);
                _imatge.id_usuari = _usuaris.id;
                _imatge.imatge_nom = textBoxDni.Text+".jpg";
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
                    jgCircularPicturesBoxImagenUser.Image = Image.FromFile("../../../ImagenesUsuario/" + _imatge.imatge_nom);
                }
                else
                {
                    jgCircularPicturesBoxImagenUser.Image = null;
                    jgCircularPicturesBoxImagenUser.Image = Image.FromFile("../../../ImagenesUsuario/" + _imatge.imatge_nom);
                }
            }
            //_imatge.id_usuari = _usuaris.id;
            //_imatge.imatge_nom = pasoDeFoto;
            //ImagenOrm.Insert(_imatge);
        }


        private void GuardarFoto()
        {
            string path = "../../../ImagenesUsuario/" + textBoxDni.Text + ".jpg";
            bool result = File.Exists(path);
            if (result == true)
            {
                File.Delete("../../../ImagenesUsuario/" + textBoxDni.Text + ".jpg");
                System.IO.File.Copy(pasoDeFoto, "../../../ImagenesUsuario/" + textBoxDni.Text + ".jpg");
            }
            else
            {
                System.IO.File.Copy(pasoDeFoto, "../../../ImagenesUsuario/" + textBoxDni.Text + ".jpg");
            }


        }

        private void radioButtonVerProfes_CheckedChanged(object sender, EventArgs e)
        {
            bindingSourceUsuarios.DataSource = UsuarisOrm.SelectPorRoles(3);
        }

        private void radioButtonVerSuper_CheckedChanged(object sender, EventArgs e)
        {
            bindingSourceUsuarios.DataSource = UsuarisOrm.SelectPorRoles(2);
        }

        private void radioButtonVerAlumnos_CheckedChanged(object sender, EventArgs e)
        {
            bindingSourceUsuarios.DataSource = UsuarisOrm.SelectPorRoles(4);
        }
    }
}
