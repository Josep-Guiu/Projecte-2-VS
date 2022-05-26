using Proyecto2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2
{
    public partial class Login : Form
    {
        String correoElectronico;
        String password;
        String insertPass;
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            panelErroresLogin.Visible = false;
            correoElectronico = textBoxCredencial1.Text;
            password = UsuarioBd.SelectUsers(correoElectronico);
            insertPass = textBoxCredencial2.Text;
            if (password.Equals("NO EXISTE"))
            {
                pictureBoxError1.Visible = true;
                pictureBoxError2.Visible = true;
                panelError3.Visible = true;
                String error = "Error, usuario inexistente";
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                panelErroresLogin.Visible = true;
                labelError.Text = error;
                textBoxCredencial2.ResetText();
            }
            else if (acceso(insertPass, password))
            {
                if (UsuarisOrm.SelectLoginUser(correoElectronico) != 1)
                {
                    MessageBox.Show("Este usuario no tiene permiso para acceder a esta aplicación, use la app móbil", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    usuaris usuariTrapaso = UsuarisOrm.SelectedUser(correoElectronico);
                    reseteoErrores();
                    textBoxCredencial2.ResetText();
                    open(usuariTrapaso);
                    //this.Close();
                    
                    this.Hide();
                }
            }
        }

        private bool acceso(String insertPass, String password)
        {
            //bool isSame = BCrypt.Net.BCrypt.EnhancedVerify(insertPass, password, BCrypt.Net.HashType.SHA512);
            bool isSame = BCrypt.Net.BCrypt.Verify(insertPass, password.ToString());

            if (!isSame)
            {
                String error = "Error, contraseña o usuario incorrectos";
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                panelErroresLogin.Visible = true;
                labelError.Text = error;
                textBoxCredencial2.ResetText();
            }
            return isSame;
        }

        private void open(usuaris usuariTrapaso)
        {
            Menu a = new Menu(usuariTrapaso);
            a.Show();
            a.FormClosed += LogOut; //-----Sobre carga----//
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void pictureBoxCierre_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void checkBoxVisiblePass_CheckedChanged(object sender, EventArgs e)
        {
            char a = new char();
            if (!checkBoxVisiblePass.Checked)
            {
                textBoxCredencial2.PasswordChar = a;
            }
            else {
                textBoxCredencial2.PasswordChar = '-';
            }
        }

        private void textBoxCredencial1_MouseClick(object sender, MouseEventArgs e)
        {
            reseteoErrores();
        }

        private void textBoxCredencial2_MouseClick(object sender, MouseEventArgs e)
        {
            reseteoErrores();
        }

        private void reseteoErrores() {
            pictureBoxError1.Visible = false;
            pictureBoxError2.Visible = false;
            panelError3.Visible = false;
            panelErroresLogin.Visible = false;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabelContra_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("¿Quieres recuperar tu contraseña?", "Recuperación de Contraseña", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (pregunta == DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(textBoxCredencial1.Text))
                {
                    UsuarisOrm.RecuperarPassword(textBoxCredencial1.Text);
                    MessageBox.Show("Le hemos enviado su contraseña a su correo", "Recuperación de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Inserta el correo electronico", "Recuperación de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void LogOut(object sender, FormClosedEventArgs e) {
            textBoxCredencial1.Text = "User email";
            textBoxCredencial2.Text = "InsertaTuContraseña";
            this.Show();
        }
    }
}
