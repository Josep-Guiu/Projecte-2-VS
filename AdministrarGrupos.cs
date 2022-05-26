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
    public partial class AdministrarGrupos : Form
    {
        usuaris administrador;
        public AdministrarGrupos()
        {
            InitializeComponent();
            cargarRadios();
        }
        public AdministrarGrupos(usuaris admin)
        {
            InitializeComponent();
            cargarRadios();
            administrador = admin;
        }

        private void radioButtonAlumnado_CheckedChanged_1(object sender, EventArgs e)
        {
            bindingSourceUsers.DataSource = UsuarisOrm.SelectUsers();
            cargarRadios();
        }

        private void radioButtonProfesorado_CheckedChanged_1(object sender, EventArgs e)
        {
            bindingSourceUsers.DataSource = UsuarisOrm.SelectProfes();
            if (radioButtonProfesorado.Checked)
            {
                radioButtonProfesorado.ForeColor = Color.FromArgb(50, 205, 50);
            }
            else
            {
                radioButtonProfesorado.ForeColor = Color.FromArgb(186, 0, 0);
            }
        }

        private void cargarRadios()
        {
            if (radioButtonAlumnado.Checked)
            {
                radioButtonAlumnado.ForeColor = Color.FromArgb(50, 205, 50);
                labelSection.Text = "/Alumnado";
            }
            else
            {
                radioButtonAlumnado.ForeColor = Color.FromArgb(186, 0, 0);
                labelSection.Text = "/Profesorado";
            }
        }

        private void AdministrarGrupos_Load(object sender, EventArgs e)
        {
            bindingSourceCursos.DataSource = CursosOrm.SelectCursos(true);
            SelectDatos();
            //listas
            ListadoListas();


        }

        private void ListadoListas()
        {
            cursos _curs = (cursos)comboBoxCurso.SelectedItem;
            grups _grup = (grups)dataGridViewGrupos.CurrentRow.DataBoundItem;
            if (_curs != null && _grup != null)
            {
                List<grups_has_llistes_skills> llistesPerGrup = GrupsHasLlistesSkills.SeleccionarListasXCursoGrupo(_grup, _curs);
                //if (llistesPerGrup.Count == 0)
                //{
                //    llistesPerGrup = GrupsHasLlistesSkills.SeleccionarTodasListas();
                //}
                List<llistes_skills> llista = new List<llistes_skills>();
                foreach (grups_has_llistes_skills item in llistesPerGrup)
                {
                    llista.Add(ListasOrm.SelectPorGrupo(item));
                }

                bindingSourceListas.DataSource = ListasOrm.QuitarListasQueTieneGrupo(llista);

                bindingSourceListaQueTieneGrupo.DataSource = llista;
            }

        }

        private void SelectDatos()
        {

            bindingSourceGrups.DataSource = GruposOrm.Select();
            if (radioButtonAlumnado.Checked)
            {
                CargarAlumnosQueFaltanEnGrupo();
            }
            else
            {
                CargarProfesQueFaltanEnGrupo();
            }
        }

        private void CargarAlumnosQueFaltanEnGrupo()
        {
            grups grupoData = (grups)dataGridViewGrupos.CurrentRow.DataBoundItem;
            cursos _curs = (cursos)comboBoxCurso.SelectedItem;
            if (_curs != null)
            {
                List<grups_has_alumnes> alumnesDinsGrup = grupoData.grups_has_alumnes.Where(x => x.curs_id == _curs.id && x.grups_id == grupoData.id).ToList();
                if (alumnesDinsGrup.Count == 0)
                {
                    bindingSourceUsers.DataSource = UsuarisOrm.SelectUsers();
                }
                else
                {
                    bindingSourceUsers.DataSource = UsuarisOrm.QuitarUsuariosDeListaTotal(alumnesDinsGrup);
                }
            }

        }
        private void CargarAlumnosQueEstanEnGrupo()
        {
            grups grupoData = (grups)dataGridViewGrupos.CurrentRow.DataBoundItem;
            cursos _curs = (cursos)comboBoxCurso.SelectedItem;
            if (_curs != null)
            {
                List<grups_has_alumnes> alumnesDinsGrup = grupoData.grups_has_alumnes.Where(x => x.curs_id == _curs.id && x.grups_id == grupoData.id).ToList();
                //if (alumnesDinsGrup.Count == 0)
                //{
                //    bindingSourceUsers.DataSource = UsuarisOrm.SelectUsers();
                //}
                //else
                //{
                bindingSourceUsers.DataSource = UsuarisOrm.PonerUsuariosDeListaTotal(alumnesDinsGrup);
                //}
            }

        }
        private void CargarProfesQueFaltanEnGrupo()
        {
            grups grupoData = (grups)dataGridViewGrupos.CurrentRow.DataBoundItem;
            cursos _curs = (cursos)comboBoxCurso.SelectedItem;
            if (_curs != null)
            {
                List<grups_has_docents> profesDinsGrup = grupoData.grups_has_docents.Where(x => x.curs_id == _curs.id && x.grups_id == grupoData.id).ToList();
                if (profesDinsGrup.Count == 0)
                {
                    bindingSourceUsers.DataSource = UsuarisOrm.SelectProfes();
                }
                else
                {
                    bindingSourceUsers.DataSource = UsuarisOrm.QuitarUsuariosDeListaTotal(profesDinsGrup);
                }
            }
        }
        private void CargarProfesQueEstanEnGrupo()
        {
            grups grupoData = (grups)dataGridViewGrupos.CurrentRow.DataBoundItem;
            cursos _curs = (cursos)comboBoxCurso.SelectedItem;
            List<grups_has_docents> profesDinsGrup = grupoData.grups_has_docents.Where(x => x.curs_id == _curs.id && x.grups_id == grupoData.id).ToList();
            //if (profesDinsGrup.Count == 0)
            //{
            //    bindingSourceUsers.DataSource = UsuarisOrm.SelectProfes();
            //}
            //else
            //{
            bindingSourceUsers.DataSource = UsuarisOrm.PonerUsuariosDeListaTotal(profesDinsGrup);
            //}
        }

        private void Reset()
        {
            textBoxNombreGrupo.ResetText();
            SelectDatos();
        }

        private void buttonAñadir_Click_1(object sender, EventArgs e)
        {
            String missatge = "";
            grups _grup = new grups();
            _grup.nom = textBoxNombreGrupo.Text;

            missatge = GruposOrm.Insert(_grup);
            if (missatge != "")
            {
                MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Reset();
        }
        private void buttonEliminaGrupo_Click_1(object sender, EventArgs e)
        {
            String missatge = "";
            grups _grup = (grups)dataGridViewGrupos.CurrentRow.DataBoundItem;
            DialogResult dR = MessageBox.Show("¿Quieres borrar este curso?", "Eliminar curso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dR == DialogResult.OK)
            {
                missatge = GruposOrm.Delete(_grup);
                if (missatge != "")
                {
                    MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Reset();
            }
            else
            {
                MessageBox.Show("Curso NO borrado", "Eliminar curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonModificarGrupos_Click_1(object sender, EventArgs e)
        {
            String missatge = "";
            grups _grup = (grups)dataGridViewGrupos.CurrentRow.DataBoundItem;
            DialogResult dR = MessageBox.Show("¿Quieres modificar el nombre del grupo?", "Modificar grupo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dR == DialogResult.OK)
            {
                _grup.nom = textBoxNombreGrupo.Text;

                if (ControlDeDatos())
                {
                    missatge = UsuarisOrm.Update();
                    if (missatge != "")
                    {
                        MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Reset();
                }

            }
            else
            {
                MessageBox.Show("Grupo NO modificado", "Modificar grupo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private bool ControlDeDatos()
        {
            bool control = true;

            if (String.IsNullOrEmpty(textBoxNombreGrupo.Text))
            {
                MessageBox.Show("Rellena el campo del nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                control = false;
            }
            return control;
        }

        private void dataGridViewGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Reset();
            grups _grup = (grups)dataGridViewGrupos.CurrentRow.DataBoundItem;
            textBoxNombreGrupo.Text = _grup.nom.ToString();
            comboBoxGrupoRelacion.Text = _grup.nom;
            ListadoListas();
        }

        private void dataGridViewGrupos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void buttonInsertarEnGrupo_Click_1(object sender, EventArgs e)
        {
            grups _grup = (grups)dataGridViewGrupos.CurrentRow.DataBoundItem;
            List<usuaris> _users = new List<usuaris>();
            bool isIn;
            bool isInOtherSuper;
            cursos _curs = (cursos)comboBoxCurso.SelectedItem;
            String missatge = "";

            if (radioButtonAlumnado.Checked)
            {
                foreach (DataGridViewRow row in this.dataGridViewUsers.SelectedRows)
                {
                    usuaris usuarioGuardar = (usuaris)row.DataBoundItem;
                    isIn = GrupHasWhatOrm.SelectHayEsteUsuario(usuarioGuardar, _grup, _curs);
                    if (!isIn)
                    {
                        _users.Add(usuarioGuardar);
                    }
                    else
                    {
                        MessageBox.Show("El usuario " + usuarioGuardar.nom + " no se ha añadido, en este grupo ya se ha añadido anteriormente este alumno");
                    }

                }
                GrupHasWhatOrm.InsertAlumnesGrup(_users, _grup, _curs);
                if (missatge != "")
                {
                    MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Quitar despues de poner alumno de datagrid
                QuitarDeDataUsers(_grup);
                bindingSourceUsers.DataSource = QuitarDeDataUsers(_grup);
            }
            else
            {

                foreach (DataGridViewRow row in this.dataGridViewUsers.SelectedRows)
                {
                    usuaris usuarioGuardar = (usuaris)row.DataBoundItem;
                    isIn = GrupHasWhatOrm.SelectHayEsteUsuario(usuarioGuardar, _grup, _curs);
                    isInOtherSuper = GrupHasWhatOrm.SelectHaySuperprofes(usuarioGuardar, _grup, _curs);
                    if (!isIn && isInOtherSuper)
                    {
                        _users.Add(usuarioGuardar);
                    }
                    else
                    {
                        MessageBox.Show("El usuario " + usuarioGuardar.nom + " no se ha añadido, en este grupo ya se ha añadido un profesor con el rol de administrador");
                    }
                }
                GrupHasWhatOrm.InsertProfesGrup(_users, _grup, _curs);
                //Quitar despues de poner alumno de datagrid
                QuitarDeDataUsers(_grup);
                bindingSourceUsers.DataSource = QuitarDeDataUsers(_grup);
            }
        }

        private List<usuaris> QuitarDeDataUsers(grups _grup)
        {
            List<grups_has_alumnes> quitarDataGrid = _grup.grups_has_alumnes.ToList();
            List<usuaris> usuariosRestantes = UsuarisOrm.QuitarUsuariosDeListaTotal(quitarDataGrid);
            return usuariosRestantes;
        }

        private void dataGridViewUsers_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            usuaris _users = (usuaris)dataGridViewUsers.CurrentRow.DataBoundItem;
            comboBoxUser.Text = _users.nom;
        }

        private void comboBoxCurso_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SelectDatos();
            ListadoListas();
        }

        private void buttonLista_Click_1(object sender, EventArgs e)
        {
            grups _grup = (grups)dataGridViewGrupos.CurrentRow.DataBoundItem;
            cursos _curs = (cursos)comboBoxCurso.SelectedItem;
            //llistes_skills llista = (llistes_skills)dataGridViewListasNoEnGrupo.CurrentRow.DataBoundItem;
            List<llistes_skills> llista = new List<llistes_skills>();
            String nombre = "";
            String missatge = "";

            if (_grup != null && _curs != null /*&& llista != null*/)
            {
                foreach (DataGridViewRow row in this.dataGridViewListasNoEnGrupo.SelectedRows)
                {
                    llistes_skills llis = (llistes_skills)row.DataBoundItem;

                    llista.Add(llis);
                }
                foreach (llistes_skills item in llista)
                {
                    grups_has_llistes_skills relacio = new grups_has_llistes_skills();
                    relacio.grups_id = _grup.id;
                    relacio.llistes_skills_id = item.id;
                    relacio.curs_id = _curs.id;

                    missatge = GrupsHasLlistesSkills.Insert(relacio);
                    if (missatge != "")
                    {
                        MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    nombre += "\n- " + item.nom;
                }
                //grups_has_llistes_skills relacio = new grups_has_llistes_skills();
                //relacio.grups_id = _grup.id;
                //relacio.llistes_skills_id = llista.id;
                //relacio.curs_id = _curs.id;

                //GrupsHasLlistesSkills.Insert(relacio);
                MessageBox.Show("Has insertado la/s lista/s" + nombre.ToUpper() + "\n en el grupo --> " + _grup.nom.ToUpper(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListadoListas();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            grups _grup = (grups)dataGridViewGrupos.CurrentRow.DataBoundItem;
            cursos _curs = (cursos)comboBoxCurso.SelectedItem;
            List<llistes_skills> llista = new List<llistes_skills>();
            String nombre = "";
            String missatge = "";
            if (_grup != null && _curs != null)
            {
                foreach (DataGridViewRow row in this.dataGridViewListasEnGrupo.SelectedRows)
                {
                    llistes_skills llis = (llistes_skills)row.DataBoundItem;

                    llista.Add(llis);
                }
                foreach (llistes_skills item in llista)
                {
                    grups_has_llistes_skills relacio = new grups_has_llistes_skills();
                    relacio.grups_id = _grup.id;
                    relacio.llistes_skills_id = item.id;
                    relacio.curs_id = _curs.id;

                    missatge = GrupsHasLlistesSkills.Delete(relacio);
                    if (missatge != "")
                    {
                        MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    nombre += "\n- " + item.nom;
                    missatge = "";
                }
                MessageBox.Show("Has Eliminado la/s lista/s" + nombre.ToUpper() + "\n del grupo --> " + _grup.nom.ToUpper(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListadoListas();
            }
        }

        private void radioButtonActivoNoEstán_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButtonAlumnado.Checked)
            {
                CargarAlumnosQueFaltanEnGrupo();
                buttonQuitaAlumnos.Enabled = false;
            }
            else
            {
                CargarProfesQueFaltanEnGrupo();
                buttonQuitaAlumnos.Enabled = false;
            }
        }

        private void radioButtonEstan_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButtonAlumnado.Checked)
            {
                CargarAlumnosQueEstanEnGrupo();
                buttonQuitaAlumnos.Enabled = true;
            }
            else
            {
                CargarProfesQueEstanEnGrupo();
                buttonQuitaAlumnos.Enabled = true;
            }
        }

        private void radioButtonTodosSkill_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonQuitaAlumnos_Click_1(object sender, EventArgs e)
        {
            grups _grup = (grups)dataGridViewGrupos.CurrentRow.DataBoundItem;
            cursos _curs = (cursos)comboBoxCurso.SelectedItem;
            List<usuaris> _users = new List<usuaris>();
            String nombre = "";
            String missatge = "";
            if (_grup != null && _curs != null)
            {
                foreach (DataGridViewRow row in this.dataGridViewUsers.SelectedRows)
                {
                    usuaris llis = (usuaris)row.DataBoundItem;

                    _users.Add(llis);
                }
                foreach (usuaris item in _users)
                {
                    if (radioButtonAlumnado.Checked)
                    {
                        grups_has_alumnes s = item.grups_has_alumnes.FirstOrDefault();
                        GrupHasWhatOrm.Delete(s);
                        if (missatge != "")
                        {
                            MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        grups_has_docents s = item.grups_has_docents.FirstOrDefault();
                        GrupHasWhatOrm.Delete(s);
                        if (missatge != "")
                        {
                            MessageBox.Show(missatge, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    nombre += "\n- " + item.nom;
                }
                if (radioButtonAlumnado.Checked)
                {
                    MessageBox.Show("Has Eliminado el/los alumno/s" + nombre.ToUpper() + "\n del grupo --> " + _grup.nom.ToUpper(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListadoListas();
                    CargarAlumnosQueEstanEnGrupo();
                }
                else
                {
                    MessageBox.Show("Has Eliminado el/los profesor/es" + nombre.ToUpper() + "\n del grupo --> " + _grup.nom.ToUpper(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListadoListas();
                    CargarProfesQueEstanEnGrupo();
                }

            }
        }

        
    }
}
