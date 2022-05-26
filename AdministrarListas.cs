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
    public partial class AdministrarListas : Form
    {
        usuaris administrador;
        public AdministrarListas()
        {
            InitializeComponent();
        }
        public AdministrarListas(usuaris admin)
        {
            InitializeComponent();
            caso1();
            administrador = admin;
        }
        private void AdministrarListas_Load(object sender, EventArgs e)
        {
            SelectTotal();
            SelectsParaSkills();
            caso1();
            caso2();
        }
        private void checkBoxActivo_CheckedChanged(object sender, EventArgs e)
        {
            caso1();
            caso2();
        }

        private void caso1() {
            if (checkBoxListaActivo.Checked)
            {
                checkBoxListaActivo.ForeColor = Color.FromArgb(50, 205, 50);
            }
            else
            {
                checkBoxListaActivo.ForeColor = Color.FromArgb(186, 0, 0);
            }
        }
        private void SelectTotal() {
            bindingSourceListas.DataSource = ListasOrm.Select();
        }

        private void buttonInsertar_Click(object sender, EventArgs e)
        {
            String missatge = "";
            llistes_skills _lista = new llistes_skills();
            _lista.nom = textBoxNombreLista.Text;
            _lista.actiu = checkBoxListaActivo.Checked;
            missatge = ListasOrm.Insert(_lista);
            if (missatge != "")
            {
                MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Reset();
        }
        private void Reset() {
            textBoxNombreLista.ResetText();
            checkBoxListaActivo.Checked = true;
            SelectTotal();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            String missatge = "";
            llistes_skills _lista = (llistes_skills)dataGridViewListas.CurrentRow.DataBoundItem;
            DialogResult dR = MessageBox.Show("¿Quieres borrar esta lista?", "Eliminar lista", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dR == DialogResult.OK)
            {
                missatge = ListasOrm.Delete(_lista);
                if (missatge != "")
                {
                    MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Reset();
            }
            else
            {
                MessageBox.Show("Lista NO borrada", "Eliminar lista", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewListas_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            String missatge = "";
            if (dataGridViewListas.SelectedRows.Count > 0)
            {
                DialogResult dR = MessageBox.Show("¿Quieres borrar esta lista?", "Eliminar lista", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dR == DialogResult.OK)
                {
                    missatge = ListasOrm.Delete((llistes_skills)dataGridViewListas.SelectedRows[0].DataBoundItem);
                    if (missatge != "")
                    {
                        MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            llistes_skills _listra = (llistes_skills)dataGridViewListas.CurrentRow.DataBoundItem;
            DialogResult dR = MessageBox.Show("¿Quieres modificar esta lista?", "Modificar lista", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dR == DialogResult.OK)
            {
                _listra.nom = textBoxNombreLista.Text;
                _listra.actiu = checkBoxListaActivo.Checked;
                missatge = ListasOrm.Update();
                if (missatge != "")
                {
                    MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Reset();
            }
            else
            {
                MessageBox.Show("Lista NO modificado", "Modificar lista", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void dataGridViewListas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            llistes_skills _listas = (llistes_skills)dataGridViewListas.CurrentRow.DataBoundItem;
            textBoxNombreLista.Text = _listas.nom.ToString();
            checkBoxListaActivo.Checked = _listas.actiu;
            comboBoxLlistes.Text = _listas.nom;
        }
        //---------------------------------------------------Parte de las skills-----------------------------------------------------------------//

        private void checkBoxActivo_CheckedChanged_2(object sender, EventArgs e)
        {
            caso2();
        }
        private void caso2()
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
        private void SelectsParaSkills()
        {
            bindingSourceListasActivas.DataSource = ListasOrm.Select(true);
            bindingSourceSkill.DataSource = SkillOrm.Select();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            String missatge = "";
            skills _skill = new skills();
            _skill.nom = textBoxNombre.Text;

            String aBuscar = comboBoxLlistes.Text;
            //llistes_skills _skill1 = ListasOrm.SelectID(aBuscar);

            //_skill.llistes_skills_id = _skill1.id;
            //int id = ListasOrm.SelectID(aBuscar);
            llistes_skills llista = (llistes_skills)comboBoxLlistes.SelectedItem;
            //_skill.llistes_skills_id = llista.id;
            _skill.llistes_skills = llista;

            _skill.actiu = checkBoxActivo.Checked;
            if (_skill.llistes_skills_id < 0)
            {
                _skill.llistes_skills_id = 0;
            }

            missatge = SkillOrm.Insert(_skill);
            if (missatge != "")
            {
                MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Reset2();
        }
        private void Reset2()
        {
            textBoxNombre.ResetText();
            checkBoxActivo.Checked = true;
            SelectsParaSkills();
        }

        private void buttonSegundoEliminar_Click(object sender, EventArgs e)
        {
            String missatge = "";
            skills _skill = (skills)dataGridViewSkills.CurrentRow.DataBoundItem;
            DialogResult dR = MessageBox.Show("¿Quieres borrar esta skill?", "Eliminar skill", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dR == DialogResult.OK)
            {
                missatge = SkillOrm.Delete(_skill);
                if (missatge != "")
                {
                    MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Reset();
            }
            else
            {
                MessageBox.Show("Lista NO borrada", "Eliminar lista", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewSkills_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            String missatge = "";
            if (dataGridViewSkills.SelectedRows.Count > 0)
            {
                DialogResult dR = MessageBox.Show("¿Quieres borrar esta skill?", "Eliminar skill", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dR == DialogResult.OK)
                {
                    missatge = SkillOrm.Delete((skills)dataGridViewSkills.SelectedRows[0].DataBoundItem);
                    if (missatge != "")
                    {
                        MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Reset();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void buttonSegundoModificar_Click(object sender, EventArgs e)
        {
            String missatge = "";
            skills _skill = (skills)dataGridViewSkills.CurrentRow.DataBoundItem;
            DialogResult dR = MessageBox.Show("¿Quieres modificar esta skill?", "Modificar skill", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dR == DialogResult.OK)
            {
                _skill.nom = textBoxNombre.Text;
                _skill.actiu = checkBoxActivo.Checked;
                missatge = SkillOrm.Update();
                if (missatge != "")
                {
                    MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Reset();
            }
            else
            {
                MessageBox.Show("Skill NO modificado", "Modificar skill", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void dataGridViewSkills_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            skills _skill = (skills)dataGridViewSkills.CurrentRow.DataBoundItem;
            textBoxNombre.Text = _skill.nom.ToString();
            checkBoxActivo.Checked = _skill.actiu;
        }

        private void dataGridViewSkills_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                skills _skill= (skills)dataGridViewSkills.Rows[e.RowIndex].DataBoundItem;
                e.Value = _skill.llistes_skills.nom;
                
            }
            if (e.ColumnIndex == 4)
            {
                skills _skill = (skills)dataGridViewSkills.Rows[e.RowIndex].DataBoundItem;
                List<kpis> _kpis = _skill.kpis.ToList();
                String nombres = "";
                int max = _kpis.Count;
                foreach (kpis item in _kpis)
                {
                    if (max != 1)
                    {
                        nombres += item.nom.ToUpper() + ", ";
                    }
                    else
                    {
                        nombres += item.nom.ToUpper();
                    }
                    max--;
                }
                e.Value = nombres;
            }
        }

        private void dataGridViewListas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            if (e.ColumnIndex == 3)
            {

            }
            if (e.ColumnIndex == 4)
            {
                llistes_skills _llista = (llistes_skills)dataGridViewListas.Rows[e.RowIndex].DataBoundItem;
                List<skills> _skills = _llista.skills.ToList();
                String nombres = "";
                int max = _skills.Count;
                foreach (skills item in _skills)
                {
                    if (max != 1)
                    {
                        nombres += item.nom.ToUpper() + ", ";
                    }
                    else
                    {
                        nombres += item.nom.ToUpper();
                    }
                    max--;  
                }
                e.Value = nombres;
            }
        }
    }
}
