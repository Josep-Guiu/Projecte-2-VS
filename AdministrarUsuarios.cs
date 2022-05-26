using Proyecto2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto2.Models;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;

namespace Proyecto2
{
    public partial class AdministrarUsuarios : Form
    {
        usuaris administrador;
        BindingList<int> anios = new BindingList<int>();

        string usuari = "dam_02@abp-politecnics.com";
        string contrasenya = "Informatica2022";
        String pasoDeFoto;
        public AdministrarUsuarios()
        {
            InitializeComponent();
            CargarAnios(anios);
        }
        public AdministrarUsuarios(usuaris admin)
        {
            InitializeComponent();
            CargarAnios(anios);
            administrador = admin;
        }


        private void checkBoxActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxActivo.Checked)
            {
                checkBoxActivo.ForeColor = Color.FromArgb(50, 205, 50);
            }
            else
            {
                checkBoxActivo.ForeColor = Color.FromArgb(186, 0, 0);
            }
        }

        private void CargarAnios(BindingList<int> anio)
        {
            //DateTime hoy = new DateTime();
            int maxAnio = 65;
            for (int i = 18; i < maxAnio; i++)
            {
                anio.Add(DateTime.Now.Year - i);
            }
            comboBoxAnyNaixa.DataSource = anio;
        }

        private void buttonAfegirUser_Click(object sender, EventArgs e)
        {
            String missatge = "";
            String missatge2 = "";
            usuaris _usuaris = new usuaris();

            _usuaris.nom = textBoxUsuarioNombre.Text + " " + textBoxUsuarioApellido1.Text + " " + textBoxUsuarioApellido2.Text; ;
            _usuaris.contrasenia = Codificar512(textBoxContra.Text);
            _usuaris.telefono = textBoxUsuarioTelefono.Text;
            _usuaris.correu = textBoxUsuarioCorreo.Text;
            _usuaris.dni = textBoxUsuarioDNI.Text;
            _usuaris.direccion = textBoxUsuarioDireccion.Text + ", " + textBoxUsuarioPostal.Text + ", " + textBoxUsuarioCiudad.Text;
            _usuaris.any_naixement = (int)comboBoxAnyNaixa.SelectedItem;
            _usuaris.actiu = IsActiu();
            rols _rol = (rols)comboBoxTiposUsuarios.SelectedItem;
            _usuaris.rols_id = _rol.id;
            //-----------------------------------Añadimos la formación en caso que se quiera hacerlo----------------------------------------//
            if (jgSwitchButtonActivarFormacion.Checked)
            {
                formacion _formacion = (formacion)comboBoxFormacion.SelectedItem;
                _usuaris.id_formacio = _formacion.id;
            }

            if (ControlDeDatos())
            {
                imatge_usuari _imatge = new imatge_usuari();
                missatge2 = UsuarisOrm.Insert(_usuaris);
                if (missatge2 != "")
                {
                    MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    MessageBox.Show("Usuario " + _usuaris.rols.nom + " Insertado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //-----------------------------------Añadimos el usuario al grupo en caso que el admin quiera hacerlo----------------------------------------//
                if (jgSwitchButtonActivarCurso.Checked)
                {
                    cursos _curso = (cursos)comboBoxCurso.SelectedItem;
                    grups _grupo = (grups)comboBoxGrupo.SelectedItem;

                    //grups_has_alumnes nuevoAlumno = new grups_has_alumnes();
                    //nuevoAlumno.curs_id = _curso.id;
                    //nuevoAlumno.grups_id = _grupo.id;
                    //nuevoAlumno.usuaris_id = _usuaris.id;
                    if (_usuaris.rols_id == 4)
                    {
                        grups_has_alumnes nuevoAlumno = new grups_has_alumnes();
                        nuevoAlumno.curs_id = _curso.id;
                        nuevoAlumno.grups_id = _grupo.id;
                        nuevoAlumno.usuaris_id = _usuaris.id;
                        GrupHasWhatOrm.InsertAlumnoAGrupo(nuevoAlumno);
                    }
                    else
                    {
                        grups_has_docents nuevoProfe = new grups_has_docents();
                        nuevoProfe.curs_id = _curso.id;
                        nuevoProfe.grups_id = _grupo.id;
                        nuevoProfe.usuaris_id = _usuaris.id;
                        GrupHasWhatOrm.InsertProfeAGrupo(nuevoProfe);
                    }

                }

                if (pasoDeFoto != null)
                {
                    _imatge.id_usuari = _usuaris.id;
                    _imatge.imatge_nom = /*pasoDeFoto*/_usuaris.dni + ".jpg";
                    GuardarFoto();
                    GuardarFotoFTP(textBoxUsuarioDNI.Text);
                    missatge = ImagenOrm.Insert(_imatge);
                    if (missatge != "")
                    {
                        MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else {
                        MessageBox.Show("Foto guardada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }



                Reset();
            }
            else
            {
                MessageBox.Show("No se ha insertado el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool IsActiu()
        {
            bool a;
            if (checkBoxActivo.Checked)
            {
                a = true;
            }
            else
            {
                a = false;
            }
            return a;
        }

        private void AdministrarUsuarios_Load(object sender, EventArgs e)
        {
            bindingSourceCursos.DataSource = CursosOrm.SelectCursos(true);
            bindingSourceTipoUsers.DataSource = RolsOrm.SelectRols();

            rols _rol = (rols)comboBoxTiposUsuarios.SelectedItem;
            CasoDeTipoUser(_rol);
            cursos _cursos = (cursos)comboBoxCurso.SelectedItem;
            bindingSourceGups.DataSource = GruposOrm.SelectActivosYPoranio(_cursos);

            //List<grups_has_alumnes> x = GrupHasWhatOrm.SelectGrups(DateTime.Now.Year);
            //bindingSourceGups.DataSource = GruposOrm.SelectGruposConAlumnos(x);
            bindingSourceFormacion.DataSource = FormacionOrm.SelectFormaciones();
            //cursos _cursos = (cursos)comboBoxCurso.SelectedItem;
        }
        private void comboBoxCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    -------------Comentar en clase---------------
            //cursos _curso = (cursos)comboBoxCurso.SelectedItem;
            //List<grups_has_alumnes> x = new List<grups_has_alumnes>();
            //x = GrupHasWhatOrm.SelectGrups(_curso.curs_inici);
            //if (x.Count != 0)
            //{
            //    bindingSourceGups.DataSource = GruposOrm.SelectGruposConAlumnos(x);
            //}
        }
        private bool ControlDeDatos()
        {
            bool control = true;

            if (String.IsNullOrEmpty(textBoxUsuarioNombre.Text) || String.IsNullOrEmpty(textBoxUsuarioApellido1.Text) || String.IsNullOrEmpty(textBoxUsuarioApellido2.Text)
                || String.IsNullOrEmpty(textBoxUsuarioTelefono.Text))
            {
                MessageBox.Show("Rellena los campos personales para añadir el usuario (nombre, apellidos, teléfono)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                control = false;
            }
            else if (control)
            {
                control = ComprobarTelefono(textBoxUsuarioTelefono.Text);
            }
            if (String.IsNullOrEmpty(textBoxUsuarioCorreo.Text) && control)
            {
                MessageBox.Show("Falta el correo electronico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                control = false;
            }
            else if (control)
            {
                control = ComprobarCorreo(textBoxUsuarioCorreo.Text);
            }
            if (String.IsNullOrEmpty(textBoxUsuarioDNI.Text) && control)
            {
                MessageBox.Show("Falta el D.N.I", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                control = false;
            }
            else if(control)
            {
                control = ComprobarDni(textBoxUsuarioDNI.Text);
            }
            if (String.IsNullOrEmpty(textBoxUsuarioDireccion.Text) || String.IsNullOrEmpty(textBoxUsuarioPostal.Text) || String.IsNullOrEmpty(textBoxUsuarioCiudad.Text) && control)
            {
                MessageBox.Show("Faltan los campos relacionados con la dirección", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                control = false;
            }
            else if (control)
            {
                control = ComprobarCodigoPostal(textBoxUsuarioPostal.Text);
            }
            return control;
        }

        private void Reset()
        {
            textBoxUsuarioNombre.ResetText();
            textBoxUsuarioApellido1.ResetText();
            textBoxUsuarioApellido2.ResetText();
            textBoxUsuarioTelefono.ResetText();
            textBoxUsuarioCorreo.ResetText();
            textBoxUsuarioDNI.ResetText();
            textBoxUsuarioDireccion.ResetText();
            textBoxUsuarioPostal.ResetText();
            textBoxUsuarioCiudad.ResetText();
            jgCircularPicturesBoxImagenUsuario.Image = null;
        }

        private String Codificar512(String contra)
        {
            string myPassword = contra;
            int mySalt = 12;
            string contraCodificada = BCrypt.Net.BCrypt.HashPassword(myPassword, mySalt);


            return contraCodificada;
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

        private bool ComprobarCodigoPostal(String cP)
        {
            bool isCorrecto = true;
            if (cP.Length != 5)
            {
                isCorrecto = false;
                MessageBox.Show("La longitud del código postal no corresponde al formato válido", "Error Comprobación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isCorrecto;
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


        private void jgCircularPicturesBoxImagenUsuario_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscaFoto = new OpenFileDialog();
            buscaFoto.InitialDirectory = "C:\\";
            buscaFoto.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*jpg;*.jpeg|PNG (*.png)|*.png|GIF (*.gif)|*.gif";
            if (buscaFoto.ShowDialog() == DialogResult.OK)
            {
                jgCircularPicturesBoxImagenUsuario.ImageLocation = buscaFoto.FileName;
                pasoDeFoto = buscaFoto.FileName;
            }
            else
            {
                MessageBox.Show("No has seleccionado una imagen", "Error Comprobación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarFoto() {
            string path = "../../../ImagenesUsuario/" + textBoxUsuarioDNI.Text + ".jpg";
            bool result = File.Exists(path);
            if (result == true)
            {
                File.Delete("../../../ImagenesUsuario/" + textBoxUsuarioDNI.Text + ".jpg");
                System.IO.File.Copy(pasoDeFoto, "../../../ImagenesUsuario/" + textBoxUsuarioDNI.Text + ".jpg");
            }
            else
            {
                if (pasoDeFoto != null) {
                    System.IO.File.Copy(pasoDeFoto, "../../../ImagenesUsuario/" + textBoxUsuarioDNI.Text + ".jpg");
                }
                
            }
            

        }
        private void GuardarFotoFTP(String fileName) {
            //bool isIn = false;
            //var request = (FtpWebRequest)WebRequest.Create("ftp://ftp.onwindows-es.setupdns.net/imagenesusuario/" + fileName);
            //request.Credentials = new NetworkCredential(usuari, contrasenya);
            //request.Method = WebRequestMethods.Ftp.GetFileSize;

            //try
            //{
            //    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            //    isIn = true;
            //    File.Delete("ftp://ftp.onwindows-es.setupdns.net/imagenesusuario/" + textBoxUsuarioDNI.Text + ".jpg");
            //    System.IO.File.Copy(pasoDeFoto, "ftp://ftp.onwindows-es.setupdns.net/imagenesusuario/" + textBoxUsuarioDNI.Text + ".jpg");
            //}
            //catch (WebException ex)
            //{
            //    FtpWebResponse response = (FtpWebResponse)ex.Response;
            //    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
            //        isIn = false;
            //    System.IO.File.Copy(pasoDeFoto, "ftp://ftp.onwindows-es.setupdns.net/imagenesusuario/" + textBoxUsuarioDNI.Text + ".jpg");
            //}
            //return isIn;

            try
            {
                string fileNam = Path.GetFileName(fileName);
                
                string path = "ftp://dam_02%40abp-politecnics.com@ftp.onwindows-es.setupdns.net/imagenesusuario/" + fileName;

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);
                request.Credentials = new NetworkCredential(usuari, contrasenya); // get the credentials

                request.Method = WebRequestMethods.Ftp.UploadFile;  // get the WebRequestMethod for uploading
                // required for data transfer
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = false;

                //WebProxy webProxy = new WebProxy("192.168.10.4", 3128);
                //request.Proxy = webProxy;

                WebProxy webProxy = new WebProxy("http://192.168.10.4:3128/", true);
                request.Proxy = webProxy;

                FileStream fileStream = File.OpenRead(pasoDeFoto);
                Stream requestStream = request.GetRequestStream();

                fileStream.CopyTo(requestStream);
                requestStream.Close();



                FtpWebResponse response = (FtpWebResponse)request.GetResponse();  // get the response request

                MessageBox.Show(response.StatusDescription);
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void CasoDeTipoUser(rols _rol)
        {
            if (_rol != null)
            {
                if (_rol.id == 1)
                {
                    comboBoxFormacion.Enabled = false;
                    jgSwitchButtonActivarFormacion.Enabled = false;
                    jgSwitchButtonActivarFormacion.Checked = false;
                    comboBoxCurso.Enabled = false;
                    jgSwitchButtonActivarCurso.Enabled = false;
                    jgSwitchButtonActivarCurso.Checked = false;
                    comboBoxCurso.Enabled = false;
                    comboBoxGrupo.Enabled = false;
                }
                else
                {
                    comboBoxFormacion.Enabled = true;
                    jgSwitchButtonActivarFormacion.Enabled = true;
                    comboBoxCurso.Enabled = true;
                    jgSwitchButtonActivarCurso.Enabled = true;
                    comboBoxCurso.Enabled = true;
                    comboBoxGrupo.Enabled = true;
                }
            }

        }

        private void comboBoxTiposUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            rols _rol = (rols)comboBoxTiposUsuarios.SelectedItem;
            CasoDeTipoUser(_rol);
        }

        //private byte[] ConvertirImagen()
        //{
        //    System.IO.MemoryStream ms = new System.IO.MemoryStream();
        //    jgCircularPicturesBoxImagenUsuario.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    return ms.GetBuffer();
        //}

        //private MemoryStream DeByteAImag(imatge_usuari _imatge)
        //{
        //    byte[] img = (byte[])_imatge.imatge;
        //    MemoryStream ms = new MemoryStream(img);
        //    return ms;
        //}


    }
}
