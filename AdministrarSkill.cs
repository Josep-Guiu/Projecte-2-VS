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
    public partial class AdministrarSkill : Form
    {
        usuaris administrador;
        public AdministrarSkill()
        {
            InitializeComponent();
        }
        public AdministrarSkill(usuaris admin)
        {
            InitializeComponent();
            administrador = admin;
        }
        private void AdministrarSkill_Load(object sender, EventArgs e)
        {
            caso1();
            Selects();
        }
        private void checkBoxActivo_CheckedChanged(object sender, EventArgs e)
        {
            caso1();
        }
        private void caso1()
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
        private void Selects()
        {
            bindingSourceListas.DataSource = ListasOrm.Select(true);
            bindingSourceSkill.DataSource = SkillOrm.Select();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
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

            SkillOrm.Insert(_skill);
            Reset();
        }

        private void Reset() {
            textBoxNombre.ResetText();
            checkBoxActivo.Checked = true;
            Selects();
            }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            skills _skill = (skills)dataGridViewSkills.CurrentRow.DataBoundItem;
            DialogResult dR = MessageBox.Show("¿Quieres borrar esta skill?", "Eliminar skill", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dR == DialogResult.OK)
            {
                SkillOrm.Delete(_skill);
                Reset();
            }
            else
            {
                MessageBox.Show("Lista NO borrada", "Eliminar lista", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewSkills_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataGridViewSkills.SelectedRows.Count > 0)
            {
                DialogResult dR = MessageBox.Show("¿Quieres borrar esta skill?", "Eliminar skill", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dR == DialogResult.OK)
                {
                    SkillOrm.Delete((skills)dataGridViewSkills.SelectedRows[0].DataBoundItem);
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
            skills _skill = (skills)dataGridViewSkills.CurrentRow.DataBoundItem;
            DialogResult dR = MessageBox.Show("¿Quieres modificar esta skill?", "Modificar skill", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dR == DialogResult.OK)
            {
                _skill.nom = textBoxNombre.Text;
                _skill.actiu = checkBoxActivo.Checked;
                SkillOrm.Update();
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

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            //textBoxNombre.Text = List < usuaris > actiuDataGridViewCheckBoxColumn = UsuarisOrm(textBoxNombre.Text);
        }
    }
}
