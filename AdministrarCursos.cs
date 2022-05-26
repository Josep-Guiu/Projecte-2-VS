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
    public partial class AdministrarCursos : Form
    {
        usuaris administrador;
        public AdministrarCursos()
        {
            InitializeComponent();
            Caso1();
        }

        public AdministrarCursos(usuaris admin)
        {
            InitializeComponent();
            Caso1();
            administrador = admin;
        }

        private void checkBoxActivo_CheckedChanged(object sender, EventArgs e)
        {
            Caso1();
        }

        private void buttonGuardaCurs_Click(object sender, EventArgs e)
        {
            cursos _curs = new cursos();
            bool control = true;
            String missatge = "";
            if (String.IsNullOrEmpty(textBoxIniciCurs.Text)  || String.IsNullOrEmpty(textBoxFiCurs.Text))
            {
                control = false;
                MessageBox.Show("Se han de rellenar las fechas del curso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (control)
            {
                _curs.curs_inici = Int32.Parse(textBoxIniciCurs.Text);
                _curs.curs_fi = Int32.Parse(textBoxFiCurs.Text);
                _curs.actiu = checkBoxActivo.Checked;
                missatge = CursosOrm.Insert(_curs);
                if (missatge != "")
                {
                    MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Curso añadido correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                bindingSourceCursos.DataSource = null;
                selectTotal();
                Reset();
            }
            else
            {
                MessageBox.Show("Curso no añadido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Caso1() {
            if (checkBoxActivo.Checked)
            {
                checkBoxActivo.ForeColor = Color.FromArgb(50, 205, 50);
            }
            else
            {
                checkBoxActivo.ForeColor = Color.FromArgb(186, 0, 0);
            }
        }

        private void AdministrarCursos_Load(object sender, EventArgs e)
        {
            selectTotal();
        }

        private void radioButtonActivoTodos_CheckedChanged(object sender, EventArgs e)
        {
            selectTotal();
        }

        private void radioButtonActivoTrue_CheckedChanged(object sender, EventArgs e)
        {
            selectParcial(true);
        }

        private void radioButtonActivoFalse_CheckedChanged(object sender, EventArgs e)
        {
            selectParcial(false);
        }

        private void selectTotal() {
            bindingSourceCursos.DataSource = CursosOrm.SelectCursos();
            //radioButtonActivoTodos.Checked = true;
        }
        private void selectParcial(bool act)
        {
            bindingSourceCursos.DataSource = CursosOrm.SelectCursos(act);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3) {
                cursos _curso = (cursos)dataGridViewCursos.Rows[e.RowIndex].DataBoundItem;
                //if (_curso.actiu == true)
                //{
                //    e.Value = "Actiu";
                //}
                //else {
                //    e.Value = "No Actiu";
                //}
            }
        }

        private void dataGridViewCursos_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            String missatge = "";
            if (dataGridViewCursos.SelectedRows.Count > 0)
            {
                DialogResult dR = MessageBox.Show("¿Quieres borrar este curso?", "Eliminar curso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dR == DialogResult.OK)
                {
                    missatge = CursosOrm.Delete((cursos)dataGridViewCursos.SelectedRows[0].DataBoundItem);
                    if (missatge != "")
                    {
                        MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    selectTotal();
                }
                else { 
                    e.Cancel = true;
                }
            }
        }

        private void buttonEliminarCurso_Click(object sender, EventArgs e)
        {
            String missatge = "";
            cursos _curso = (cursos)dataGridViewCursos.CurrentRow.DataBoundItem;
            DialogResult dR = MessageBox.Show("¿Quieres borrar este curso?", "Eliminar curso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dR == DialogResult.OK)
            {
                missatge = CursosOrm.Delete((cursos)dataGridViewCursos.SelectedRows[0].DataBoundItem);
                if (missatge != "")
                {
                    MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                selectTotal();
            }
            else
            {
                MessageBox.Show("Curso NO borrado", "Eliminar curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Reset() {
            textBoxIniciCurs.ResetText();
            textBoxFiCurs.ResetText();
            checkBoxActivo.Checked = true;
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            String missatge = "";
            cursos _curso = (cursos)dataGridViewCursos.CurrentRow.DataBoundItem;
            DialogResult dR = MessageBox.Show("¿Quieres modificar este curso?", "Modificar curso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dR == DialogResult.OK)
            {
                _curso.curs_inici = int.Parse(textBoxIniciCurs.Text);
                _curso.curs_fi = int.Parse(textBoxFiCurs.Text);
                _curso.actiu = checkBoxActivo.Checked;
                missatge = CursosOrm.Update(_curso);
                if (missatge != "")
                {
                    MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Reset();
                selectTotal();
            }
            else
            {
                MessageBox.Show("Curso NO modificado", "Modificar curso", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void dataGridViewCursos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Reset();
            cursos _curso = (cursos)dataGridViewCursos.CurrentRow.DataBoundItem;
            textBoxIniciCurs.Text = _curso.curs_inici.ToString();
            textBoxFiCurs.Text = _curso.curs_fi.ToString();
            checkBoxActivo.Checked = _curso.actiu;
        }
    }
}
