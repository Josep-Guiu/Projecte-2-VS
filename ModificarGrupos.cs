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
    public partial class ModificarGrupos : Form
    {
        usuaris administrador;
        List<llistes_skills> _listas = new List<llistes_skills>();
        List<skills> _skills = new List<skills>();
        List<kpis> _kpis = new List<kpis>();
        public ModificarGrupos()
        {
            InitializeComponent();
            Selects();
        }
        public ModificarGrupos(usuaris admin)
        {
            InitializeComponent();
            administrador = admin;
            
        }

        private void ModificarGrupos_Load(object sender, EventArgs e)
        {
            Selects();
        }
        private void Selects() {
            int anio = DateTime.Now.Year;
            List<grups_has_alumnes> x = GrupHasWhatOrm.SelectGrups(anio);
            bindingSourceGrupo.DataSource = GruposOrm.SelectGruposConAlumnos(x);
            bindingSourceUsuarios.DataSource = GrupHasWhatOrm.SelectGrupsUsers((grups)dataGridViewGrupos.CurrentRow.DataBoundItem);
            bindingSourceListas.DataSource = GrupsHasLlistesSkills.SelectGrupsLlistes((grups)dataGridViewGrupos.CurrentRow.DataBoundItem);
            bindingSourceSkills.DataSource = SkillOrm.SelectConListas((llistes_skills)dataGridViewListas.CurrentRow.DataBoundItem);
            bindingSourceKPIS.DataSource = KpiOrm.SelectConSkill((skills)dataGridViewSkills.CurrentRow.DataBoundItem);
            bindingSourceCurso.DataSource = CursosOrm.SelectCursos();
            bindingSourceListasActivas.DataSource = ListasOrm.Select(true);
        }


        private void dataGridViewGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            grups _grupo = (grups)dataGridViewGrupos.CurrentRow.DataBoundItem;
            bindingSourceUsuarios.DataSource = GrupHasWhatOrm.SelectGrupsUsers(_grupo);
            _listas = GrupsHasLlistesSkills.SelectGrupsLlistes(_grupo);
            if (_listas.Count != 0)
            {
               // SeleccionCombo();
                bindingSourceListas.DataSource = GrupsHasLlistesSkills.SelectGrupsLlistes(_grupo);
            }
            else {
                bindingSourceListas.DataSource = null;
                bindingSourceSkills.DataSource = null;
                bindingSourceKPIS.DataSource = null;
            }
            if (bindingSourceListas.DataSource != null)
            {
                _skills = SkillOrm.SelectConListas((llistes_skills)dataGridViewListas.CurrentRow.DataBoundItem);
                if (_skills.Count != 0)
                {
                    bindingSourceSkills.DataSource = SkillOrm.SelectConListas((llistes_skills)dataGridViewListas.CurrentRow.DataBoundItem);
                }
                _kpis = KpiOrm.SelectConSkill((skills)dataGridViewSkills.CurrentRow.DataBoundItem);
                if (_kpis.Count != 0)
                {
                    bindingSourceKPIS.DataSource = KpiOrm.SelectConSkill((skills)dataGridViewSkills.CurrentRow.DataBoundItem);
                }
            }
        }
        private void dataGridViewListas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionCombo();
            bindingSourceSkills.DataSource = SkillOrm.SelectConListas((llistes_skills)dataGridViewListas.CurrentRow.DataBoundItem);
            bindingSourceKPIS.DataSource = KpiOrm.SelectConSkill((skills)dataGridViewSkills.CurrentRow.DataBoundItem);
        }
        private void SeleccionCombo() {
            llistes_skills _listaTabla = (llistes_skills)dataGridViewListas.CurrentRow.DataBoundItem;
            comboBoxListasActivas.Text = _listaTabla.nom;
        }
        private void buttonAñadirListaAGrupo_Click(object sender, EventArgs e)
        {
            String missatge = "";
            grups_has_llistes_skills _llistaGrup = RecuperarDeCombo();

            if (GrupsHasLlistesSkills.SelectControlRepeticion(_llistaGrup))
            {
                missatge = GrupsHasLlistesSkills.Insert(_llistaGrup);
                if (missatge != "")
                {
                    MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("La lista seleccionada se ha añadido al grupo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Selects();
            }
            else {
                MessageBox.Show("La lista seleccionada ya está en el grupo seleccionado. Lista NO añadida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonBOrrarListaAGrupo_Click(object sender, EventArgs e)
        {
            String missatge = "";
            grups_has_llistes_skills _llistaGrup = RecuperarDeCombo();
            missatge = GrupsHasLlistesSkills.Delete(_llistaGrup);
            if (missatge != "")
            {
                MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("La lista seleccionada se ha borrado del grupo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Selects();
        }
        private grups_has_llistes_skills RecuperarDeCombo() {
            cursos _curso = (cursos)comboBoxCurso.SelectedItem;
            llistes_skills _llista = (llistes_skills)comboBoxListasActivas.SelectedItem;
            grups _grup = (grups)dataGridViewGrupos.CurrentRow.DataBoundItem;

            grups_has_llistes_skills _llistaGrup = new grups_has_llistes_skills();
            _llistaGrup.curs_id = _curso.id;
            _llistaGrup.grups_id = _grup.id;
            _llistaGrup.llistes_skills_id = _llista.id;
            return _llistaGrup;
        }

       
    }
}
