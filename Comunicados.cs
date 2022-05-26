using Proyecto2.EmailServicios;
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
    public partial class Comunicados : Form
    {
        usuaris administrador;
        List<usuaris> _usuaris = new List<usuaris>();
        grups _grup = new grups();
        public Comunicados()
        {
            InitializeComponent();
        }
        public Comunicados(usuaris admin)
        {
            InitializeComponent();
            administrador = admin;
            
        }

        private void Comunicados_Load(object sender, EventArgs e)
        {
            bindingSourceRequestBot.DataSource = BotOrm.SelectRequestsPendientes(true);
            bindingSourceGrupos.DataSource = GruposOrm.Select();
            _grup = (grups)comboBoxGrups.SelectedItem;
            _usuaris = UsuarisOrm.SelectedUsersPorGrupo(_grup.grups_has_alumnes.ToList());
            Rellenar();
            bindingSourceMissatges.DataSource = MissatgesOrm.Select();
            bindingSourceRequestBot.DataSource = BotOrm.SelectRequestsPendientes(true);
        }

        private void buttonEnviarEmail_Click(object sender, EventArgs e)
        {
            
                SystemSuportMail envio = new SystemSuportMail();
                envio.enviarComunicadosAClientes(textBoxAsunto.Text, textBoxBody.Text, _usuaris);
                MessageBox.Show("Mensaje enviado", "Comunicados", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DateTime hoy = DateTime.Today;
            missatges _mis = new missatges();
            _mis.asumpte = textBoxAsunto.Text;
            _mis.cos = textBoxBody.Text;
            _mis.id_usuari = administrador.id;
            _mis.id_grup = _grup.id;
            _mis.data = hoy;
            String missatge = "";
            missatge = MissatgesOrm.Insert(_mis);
            if (missatge != "")
            {
                MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Mail guardado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            bindingSourceMissatges.DataSource = MissatgesOrm.Select();
            ResetMsm();
        }

        private void buttonEliminarMensaje_Click(object sender, EventArgs e)
        {
            //textBoxDestinatario.ResetText();
            //textBoxAsunto.ResetText();
            //textBoxBody.ResetText();
            //comboBoxGrups.SelectedIndex = 0;
            ResetMsm();
            MessageBox.Show("Mensaje eliminado", "Comunicados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBoxGrups_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            _usuaris = null;
            _grup = (grups)comboBoxGrups.SelectedItem;
            if (_grup != null)
            {
                List<grups_has_alumnes> _Has_Alumnes = _grup.grups_has_alumnes.ToList();
                _usuaris = UsuarisOrm.SelectedUsersPorGrupo(_Has_Alumnes);
                Rellenar();
            }
            
            
            
        }
        private void Rellenar() {
            String usuariosNombre = "";
            if (_usuaris.Count != 0)
            {
                foreach (var usuario in _usuaris)
                {
                    usuariosNombre += usuario.nom + ", ";
                }
                textBoxDestinatario.Text = usuariosNombre;
            }
            else
            {
                textBoxDestinatario.Text = usuariosNombre;
            }
        }
        private void dataGridViewKpis_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                missatges _missatge = (missatges)dataGridViewMSM.Rows[e.RowIndex].DataBoundItem;
                grups _grup = GruposOrm.SelectID(_missatge.id_grup);
                e.Value = _grup.nom.ToString();
            }
        }

        private void dataGridViewMSM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ResetMsm();
            missatges _missatges = (missatges)dataGridViewMSM.CurrentRow.DataBoundItem;
            AboutMsm(_missatges);
        }

        private void AboutMsm(missatges _missatges) {
            textBoxAsunto.Text = _missatges.asumpte.ToString();
            textBoxBody.Text = _missatges.cos.ToString();
        }
        private void ResetMsm()
        {
            textBoxAsunto.Text = "ASUNTO DEL COMUNICADO";
            textBoxBody.Text = "CUERPO DEL COMUNICADO";
        }

        //private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    botchat _botchat = (botchat)comboBox3.SelectedItem;
        //    if (_botchat != null)
        //    {
        //        AboutRequest(_botchat);
        //    }
        //}


        private void AboutRequest(botchat _botchat)
        {
            
        }

        private void textBoxAsunto_Click(object sender, EventArgs e)
        {
            textBoxAsunto.ResetText();
        }

        private void textBoxBody_Click(object sender, EventArgs e)
        {
            textBoxBody.ResetText();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelComunicado_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewMSM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewReporte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            botchat _bot = (botchat)dataGridViewReporte.CurrentRow.DataBoundItem;
            AboutMsm(_bot);
        }
        private void ResetRequest()
        {
            textBoxNumRequest.Text = "";
            textBoxCodigo.Text = "";
            textBoxIdUser.Text = "";
            textBoxNomUser.Text = "";
            textBoxMensaje.Text = "";
        }
        private void AboutMsm(botchat _bot)
        {
            String requestBody;
            textBoxNumRequest.Text = _bot.id.ToString();
            textBoxCodigo.Text = _bot.request.ToString();
            textBoxIdUser.Text = _bot.id_usuari.ToString();
            textBoxNomUser.Text = _bot.usuaris.nom.ToString();
            requestBody = obtenerBody(_bot.request);
            textBoxMensaje.Text = requestBody +"\n"+Environment.NewLine + _bot.mensaje.ToString();
        }

        private string obtenerBody(int v)
        {
            String code = v.ToString();
            char[] ch = new char[code.Length];
            String nueva = "";

            switch (v) {
                case 10:
                    nueva = "Consultas de perfil - No puedo cambiar mi contraseña";
                    break;
                case 11:
                    nueva = "Errores de la App - Hay algún dato erroneo";
                    break;
                case 100:
                    nueva = "Errores de la App - Otro";
                    break;
                case 20:
                    nueva = "Errores de la App - No puedo insertar valoraciones";
                    break;
                case 21:
                    nueva = "Errores de la App - La skill no tiene kpis";
                    break;
                case 101:
                    nueva = "Errores de la App - Otro";
                    break;
                case 30:
                    nueva = "No puedo ver mis graficos";
                break;
                case 102:
                    nueva = "Errores de la App - Otro";
                    break;
                default:
                    nueva = "Código no reconocible, contacte con el usuario";
                    break;
            }


            return nueva;
        }

        private void buttonSaveRequest_Click(object sender, EventArgs e)
        {
            if (checkBoxActive.Checked == true)
            {
                botchat _bot = (botchat)dataGridViewReporte.CurrentRow.DataBoundItem;
                _bot.actiu = false;
                BotOrm.Update(_bot);
                ResetRequest();
                bindingSourceRequestBot.DataSource = BotOrm.SelectRequestsPendientes(true);
                MessageBox.Show("Request del usuario Archivada", "Comunicados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
