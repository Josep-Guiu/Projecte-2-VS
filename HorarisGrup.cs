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
    public partial class HorarisGrup : Form
    {
        List<String> diesSetmana = new List<String> { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes"};
        dias _diasModifica = null;
        horari horariModifica = null;
        usuaris _administrador;
        grups_has_horaris _grup_has_horarisss = new grups_has_horaris();
        horari x;
        public HorarisGrup()
        {
            InitializeComponent();
        }
        public HorarisGrup(usuaris administrador)
        {
            InitializeComponent();
            _administrador = administrador;
        }
        public HorarisGrup(usuaris administrador, horari _horari)
        {
            InitializeComponent();
            _administrador = administrador;
            x = _horari;
        }
        private void HorarisGrup_Load(object sender, EventArgs e)
        {
            
            CargarDatosDeDias();
            bindingSourceHorarios.DataSource = HorarisOrm.RecibirTodosHorarios();
            bindingSourceGrupos.DataSource = GruposOrm.Select();

            CargarDatosDeHoraris();
            CargarTareasDeSemana();


            bindingSourceDiasSemana.DataSource = diesSetmana;
            if (x!= null)
            {
                comboBoxHorarioGrupo.Text = x.nom;
            }
        }

        private void CargarTareasDeSemana()
        {
            horari _horari = (horari)comboBoxHorarioGrupo.SelectedItem;
            grups _grups = HorarisOrm.grupDeHorari(_horari);
            if (_horari != null)
            {
                bindingSourceDia1.DataSource = GrupsHasHorariosORM.ReturnDiasDeGrupo(_grups.id, _horari.id, diesSetmana[0]);
                bindingSourceDia2.DataSource = GrupsHasHorariosORM.ReturnDiasDeGrupo(_grups.id, _horari.id, diesSetmana[1]);
                bindingSourceDia3.DataSource = GrupsHasHorariosORM.ReturnDiasDeGrupo(_grups.id, _horari.id, diesSetmana[2]);
                bindingSourceDia4.DataSource = GrupsHasHorariosORM.ReturnDiasDeGrupo(_grups.id, _horari.id, diesSetmana[3]);
                bindingSourceDia5.DataSource = GrupsHasHorariosORM.ReturnDiasDeGrupo(_grups.id, _horari.id, diesSetmana[4]);
            }
            
        }

       

        private void buttonGuardarActividad_Click(object sender, EventArgs e)
        {
            String missatge = "";
            dias _dias = new dias();
            if (!jgSwitchButtonModificar.Checked)
            {


                if (ControlDatos())
                {
                    _dias.dia = (String)comboBoxDiasSemanales.SelectedItem;
                    _dias.inici = textBoxInicio.Text.ToString();
                    _dias.fi = textBoxFi.Text.ToString();
                    _dias.tasca = textBoxFeina.Text.ToString();

                    missatge = DiasOrm.Insert(_dias);
                    if (missatge != "")
                    {
                        MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else {
                        MessageBox.Show("Día creado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    CargarDatosDeDias();
                    ResetDias();
                }
                else
                {
                    MessageBox.Show("Tienes que insertar todos los campos para crear un item de horario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                if (ControlDatos())
                {
                    _diasModifica.dia = (String)comboBoxDiasSemanales.SelectedItem;
                    _diasModifica.inici = textBoxInicio.Text.ToString();
                    _diasModifica.fi = textBoxFi.Text.ToString();
                    _diasModifica.tasca = textBoxFeina.Text.ToString();

                    missatge = DiasOrm.Update();
                    if (missatge != "")
                    {
                        MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else {
                        MessageBox.Show("Día modificado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    CargarDatosDeDias();
                    ResetDias();
                }
                else
                {
                    MessageBox.Show("Tienes que insertar todos los campos para actualizar un item de horario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            CargarTareasDeSemana();
            labelFeinaInsertar.Text = _diasModifica.tasca;
            _diasModifica = null;
            jgSwitchButtonModificar.Checked = false;
        }

        private bool ControlDatos() {
            bool control = true;
            if (textBoxInicio.Text.Equals("") || textBoxFi.Text.Equals("") || textBoxFeina.Text.Equals(""))
            {
                control = false;
            }
            return control;
        }

        private void ResetDias()
        {

            comboBoxDiasSemanales.Text = diesSetmana.FirstOrDefault().ToString();
            textBoxInicio.ResetText();
            textBoxFi.ResetText();
            textBoxFeina.ResetText();

        }

        private void CargarDatosDeDias() {

            bindingSourceDias.DataSource = DiasOrm.RecibirTodosDias();

        }
        private void CargarDatosDeHoraris() {

            horari _horari = (horari)comboBoxHorarioGrupo.SelectedItem;
            if (x!=null)
            {
                _horari = x;
            }
            horariModifica = _horari;
            grups _grups = HorarisOrm.grupDeHorari(_horari);
            labelGrupoDelHorario.Text = _grups.nom;
            textBoxNombreHorario.Text = horariModifica.nom.ToString();
            labelHoraari.Text = _horari.nom;
            comboBoxGrups.Text = _grups.nom;
        }

        private void buttonGuardarHorario_Click(object sender, EventArgs e)
        {
            horari a = new horari();
            String missatge = "";
            if (!jgSwitchButtonModificar.Checked)
            {
                if (!textBoxNombreHorario.Text.Equals(""))
                {
                    a.nom = textBoxNombreHorario.Text.ToString();
                    missatge = HorarisOrm.Insert(a);
                    if (missatge != "")
                    {
                        MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else {
                        MessageBox.Show("Nuevo horario añadido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            else {
                a = (horari)comboBoxHorarioGrupo.SelectedItem;
                if (!textBoxNombreHorario.Text.Equals(""))
                {
                    a.nom = textBoxNombreHorario.Text.ToString();
                    missatge = HorarisOrm.Update();
                    if (missatge != "")
                    {
                        MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else {
                        MessageBox.Show("Horario eliminado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            bindingSourceHorarios.DataSource = HorarisOrm.RecibirTodosHorarios();
            jgSwitchButtonModificar.Checked = false;
        }

        private void comboBoxHorarioGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            horari _horari = (horari)comboBoxHorarioGrupo.SelectedItem;
            grups _grups = HorarisOrm.grupDeHorari(_horari);

            if (_horari != null)
            {
                labelHoraari.Text = _horari.nom;
            }
            comboBoxGrups.Text = _grups.nom;
            CargarTareasDeSemana();
            if (_horari != null)
            {
                textBoxNombreHorario.Text = _horari.nom;
            }
            
        }

        private void buttonInsertarRelacion_Click(object sender, EventArgs e)
        {
            String missatge = "";
            horari _horari = (horari)comboBoxHorarioGrupo.SelectedItem;
            grups _grups = HorarisOrm.grupDeHorari(_horari);
            //if (_grups.id == 0)
            //{
                _grups = (grups)comboBoxGrups.SelectedItem;
            //}
            dias _dias = (dias)dataGridViewDias.CurrentRow.DataBoundItem;
            grups_has_horaris _grups_Has_Horaris = new grups_has_horaris();
            _grups_Has_Horaris.id_horari = _horari.id;
            _grups_Has_Horaris.id_grups = _grups.id;
            _grups_Has_Horaris.id_dias = _dias.id;
            missatge = GrupsHasHorariosORM.Insert(_grups_Has_Horaris);
            if (missatge != "")
            {
                MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                MessageBox.Show("Relación establecida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            CargarTareasDeSemana();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewDias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _diasModifica = (dias)dataGridViewDias.CurrentRow.DataBoundItem;
            dias _dias = (dias)dataGridViewDias.CurrentRow.DataBoundItem;
            comboBoxDiasSemanales.Text = _dias.dia;
            textBoxInicio.Text = _dias.inici;
            textBoxFi.Text = _dias.fi;
            textBoxFeina.Text = _dias.tasca;
            labelFeinaInsertar.Text = _dias.tasca;
        }

        private void buttonDiaElimina_Click(object sender, EventArgs e)
        {
            String missatge = "";
            dias _dias = (dias)dataGridViewDias.CurrentRow.DataBoundItem;
            DialogResult dR = MessageBox.Show("¿Quieres borrar esta Tarea?", "Eliminar tarea", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dR == DialogResult.OK)
            {
                missatge = DiasOrm.Delete(_dias);
                if (missatge != "")
                {
                    MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    MessageBox.Show("Tarea Borrada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CargarDatosDeDias();
            }
            else
            {
                MessageBox.Show("Tarea NO borrada", "Eliminar lista", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ResetDias();
        }

        private void buttonHorario_Click(object sender, EventArgs e)
        {
            String missatge = "";
            horari _horari = (horari)comboBoxHorarioGrupo.SelectedItem;
            DialogResult dR = MessageBox.Show("¿Quieres borrar este Horario?", "Eliminar horario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dR == DialogResult.OK)
            {
                missatge = HorarisOrm.Delete(_horari);
                if (missatge != "")
                {
                    MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                CargarDatosDeDias();
                bindingSourceHorarios.DataSource = HorarisOrm.RecibirTodosHorarios();
            }
            else
            {
                MessageBox.Show("Horario NO borrado", "Eliminar horario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonEliminarRelacion_Click(object sender, EventArgs e)
        {
            String missatge = "";
            missatge = GrupsHasHorariosORM.Delete(_grup_has_horarisss);
            if (missatge != "")
            {
                MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                MessageBox.Show("Relación eliminada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            _grup_has_horarisss = null;
            CargarTareasDeSemana();
        }

        private void dataGridViewUsuaris_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dias _diass = (dias)dataGridView0.CurrentRow.DataBoundItem;
            SetGrupsHas(_diass);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dias _diass = (dias)dataGridView1.CurrentRow.DataBoundItem;
            SetGrupsHas(_diass);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dias _diass = (dias)dataGridView2.CurrentRow.DataBoundItem;
            SetGrupsHas(_diass);
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dias _diass = (dias)dataGridView3.CurrentRow.DataBoundItem;
            SetGrupsHas(_diass);
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dias _diass = (dias)dataGridView4.CurrentRow.DataBoundItem;
            SetGrupsHas(_diass);
        }

        private void SetGrupsHas(dias _diass) {

            horari _horaris = (horari)comboBoxHorarioGrupo.SelectedItem;
            grups _grups = (grups)comboBoxGrups.SelectedItem;
            _grup_has_horarisss = GrupsHasHorariosORM.ReturnDiaDeGrupo(_grups.id, _horaris.id, _diass.id);

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxGrups_SelectedIndexChanged(object sender, EventArgs e)
        {
            grups _grups = (grups)comboBoxGrups.SelectedItem;
            if (_grups!=null)
            {
                labelGrupoDelHorario.Text = _grups.nom;
            }
            
        }
    }
}
