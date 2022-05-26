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
    public partial class AdministrarKPIS : Form
    {
        usuaris administrador;
        public AdministrarKPIS()
        {
            InitializeComponent();
            
        }
        public AdministrarKPIS(usuaris admin)
        {
            InitializeComponent();
            administrador = admin;
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

        private void AdministrarKPIS_Load(object sender, EventArgs e)
        {
            caso1();
            Selects();
        }

        private void Selects() {
            bindingSourceKPIS.DataSource = KpiOrm.Select();
            bindingSourceSkill.DataSource = SkillOrm.Select();
        }

        private void buttonInsertar_Click(object sender, EventArgs e)
        {
            String missatge = "";
            kpis _kpi = new kpis();
            _kpi.nom = textBoxNombreKpi.Text;
            _kpi.actiu = checkBoxActivo.Checked;
            skills _skill2 = (skills)comboBoxSkills.SelectedItem;
            _kpi.skills_id = _skill2.id;

            missatge=KpiOrm.Insert(_kpi);
            if (missatge != "")
            {
                MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Reset();
        }

        private void Reset() {
            textBoxNombreKpi.ResetText();
            checkBoxActivo.Checked = true;
            Selects();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            String missatge="";
            kpis _kpis = (kpis)dataGridViewKpis.CurrentRow.DataBoundItem;
            DialogResult dR = MessageBox.Show("¿Quieres borrar esta kpi?", "Eliminar kpi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dR == DialogResult.OK)
            {
                missatge = KpiOrm.Delete(_kpis);
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

        private void dataGridViewKpis_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            String missatge = "";
            if (dataGridViewKpis.SelectedRows.Count > 0)
            {
                DialogResult dR = MessageBox.Show("¿Quieres borrar esta kpi?", "Eliminar kpi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dR == DialogResult.OK)
                {
                    missatge = KpiOrm.Delete((kpis)dataGridViewKpis.SelectedRows[0].DataBoundItem);
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
            kpis _kpi = (kpis)dataGridViewKpis.CurrentRow.DataBoundItem;
            DialogResult dR = MessageBox.Show("¿Quieres modificar esta kpi?", "Modificar kpi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dR == DialogResult.OK)
            {
                _kpi.nom = textBoxNombreKpi.Text;
                _kpi.actiu = checkBoxActivo.Checked;
                missatge = KpiOrm.Update();
                if (missatge != "")
                {
                    MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Reset();
            }
            else
            {
                MessageBox.Show("Kpi NO modificado", "Modificar Kpi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewKpis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            kpis _kpi = (kpis)dataGridViewKpis.CurrentRow.DataBoundItem;
            textBoxNombreKpi.Text = _kpi.nom.ToString();
            checkBoxActivo.Checked = _kpi.actiu;
        }

        private void dataGridViewKpis_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                kpis _kpi = (kpis)dataGridViewKpis.Rows[e.RowIndex].DataBoundItem;
                e.Value = _kpi.skills.nom;
            }
        }
    }
}
