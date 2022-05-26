using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Proyecto2.Models;

namespace Proyecto2
{
    public partial class Menu : Form
    {
        usuaris administrador = null;
        String inicio = DateTime.Now.ToString();
        public Menu()
        {
            InitializeComponent();
            ocultarPaneles();
        }

        public Menu(usuaris _usuari)
        {
            InitializeComponent();
            ocultarPaneles();
            administrador = _usuari;
        }

        private void pictureBoxCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pictureBoxMaximizar.Visible = false;
            pictureBoxRestaurar.Visible = true;
        }

        private void pictureBoxRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            pictureBoxRestaurar.Visible = false;
            pictureBoxMaximizar.Visible = true;
        }

        private void pictureBoxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf12, 0);
            /* https://www.youtube.com/watch?v=3ni0V-l3Auw */
        }

        private void buttonAdministrarUsers_Click(object sender, EventArgs e)
        {
            if (panelSubMenu1.Visible == false)
            {
                panelSubMenu1.Visible = true;
            }
            else
            {
                panelSubMenu1.Visible = false;
            }
            if (activeForm != null)
            {
                activeForm.Close();
            }
           
           
        }
        private void buttonAltaUsers_Click(object sender, EventArgs e)
        {

            AdministrarUsuarios frmadminusers = new AdministrarUsuarios();
            OpenChildForm(frmadminusers, buttonAltaUsers);
        }

        private void buttonModificarUsers_Click(object sender, EventArgs e)
        {
            if (administrador !=null)
            {
                ModificacionesUsuarios frmadminusers = new ModificacionesUsuarios(administrador);
                OpenChildForm(frmadminusers, buttonModificarUsers);
            }
            else
            {
                ModificacionesUsuarios frmadminusers = new ModificacionesUsuarios();
                OpenChildForm(frmadminusers, buttonModificarUsers);
            }
            
        }

        private void showMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void buttonAdministrarServices_Click(object sender, EventArgs e)
        {
            showMenu(panelSubMenu2);
        }

        private void buttonCurso_Click(object sender, EventArgs e)
        {
            if (panelSubMenu3.Visible == false)
            {
                panelSubMenu3.Visible = true;
            }
            else
            {
                panelSubMenu3.Visible = false;
            }

            AdministrarCursos frmadminusers = new AdministrarCursos();
            OpenChildForm(frmadminusers, buttonCurso);
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ocultarPaneles() {
            panelSubMenu1.Visible = false;
            panelSubMenu2.Visible = false;
            panelSubMenu3.Visible = false;
        }

        private void timerReloj_Tick(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.ToString("HH:mm:ss");
            labelFecha.Text = DateTime.Now.ToShortDateString();
        }

        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        private void OpenChildForm(Form childform, object btnSender)
        {

            if (activeForm != null)
            {
                activeForm.Close();
            }

            ActivateButton(btnSender);
            activeForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            this.panelInicio.Controls.Add(childform);
            this.panelInicio.Tag = childform;
            childform.BringToFront();
            childform.Show();


        }



        private void ActivateButton(object btnsender)
        {
            if (btnsender != null)
            {
                if (currentButton != (Button)btnsender)
                {
                    currentButton = (Button)btnsender;

                }
            }
        }

        private void buttonGrupo_Click(object sender, EventArgs e)
        {
            AdministrarGrupos frmadminusers = new AdministrarGrupos(administrador);
            OpenChildForm(frmadminusers, buttonGrupo);
            CargarEtiquetas();
        }

        private void buttonKPI_Click(object sender, EventArgs e)
        {
            AdministrarKPIS frmadminusers = new AdministrarKPIS(administrador);
            OpenChildForm(frmadminusers, buttonKPI);
            CargarEtiquetas();
        }

        private void buttonListas_Click(object sender, EventArgs e)
        {
            AdministrarListas frmadminusers = new AdministrarListas(administrador);
            OpenChildForm(frmadminusers, buttonKPI);
            CargarEtiquetas();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            labelUsuario.Text = administrador.nom;
            labelData.Text = inicio;
            CargarEtiquetas();
            CargarCursos();
            CargarGrupos();
            CargarHorarios();
            cursos _curs = (cursos)comboBoxCursos.SelectedItem;
            CargarGrafica1(_curs);
            grups _grup = (grups)comboBoxGrupos.SelectedItem;
            CargarGrafica2(_grup);
            CargarGrafica3(_grup);
        }

        private void CargarEtiquetas() {
            int usuariosTotales = UsuarisOrm.ContarUsuarios("all");
            labelUsuariosTotales.Text = "Número: " + usuariosTotales;
            int admins = UsuarisOrm.ContarUsuarios("admins");
            labelTotalAdmins.Text = "Número: " + admins;
            int profes = UsuarisOrm.ContarUsuarios("profes");
            labelTotalProfesores.Text = "Número: " + profes;
            int alumnos = UsuarisOrm.ContarUsuarios("alumnos");
            labelTotalAlumnos.Text = "Número: " + alumnos;
            int listas = ListasOrm.TotalListas();
            labelTotalListas.Text = "Número: " + listas;
            int skills = SkillOrm.TotalSkills();
            labelTotalSkills.Text = "Número: " + skills;
            int kpis = KpiOrm.TotalKPIS();
            labelTotalKpis.Text = "Número: " + kpis;
            int grupos = GruposOrm.TotalGrupos();
            labelTotalGrupos.Text = "Número: " + grupos;
        }
        private void CargarCursos() {
            List<cursos> _cursos = CursosOrm.SelectCursos();
            bindingSourceCursos.DataSource = _cursos;
        }

        private void CargarHorarios() {
            List<horari> _horari = HorarisOrm.RecibirTodosHorarios();
            bindingSourceHorarios.DataSource = _horari;
        }

        private void CargarGrupos() {
            List<grups> _grups = GruposOrm.Select();
            bindingSourceGrupos.DataSource = _grups;
        }

        private void buttonComunica_Click(object sender, EventArgs e)
        {
            Comunicados frmadminusers = new Comunicados(administrador);
            OpenChildForm(frmadminusers, buttonComunica);
        }

        private void buttonPerfil_Click(object sender, EventArgs e)
        {
            EditarDatosAdmin frmadminusers = new EditarDatosAdmin(administrador);
            OpenChildForm(frmadminusers, buttonPerfil);
        }

        private void buttonCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonModificarGrupos_Click(object sender, EventArgs e)
        {
            //ModificarGrupos frmadminusers = new ModificarGrupos();
            //OpenChildForm(frmadminusers, buttonModificarGrupos);
            FormReports frmadminusers = new FormReports();
            OpenChildForm(frmadminusers, buttonModificarGrupos);
            CargarEtiquetas();
        }

        private void CargarGrafica1(cursos _curs) {
            if (_curs != null)
            {
                List<grups_has_alumnes> _grupsDelCurs = _curs.grups_has_alumnes.ToList();
                List<grups> _gruposSinRepeticiones = GruposOrm.SeleccionarGruposDeCurso(_grupsDelCurs);
                List<int> numAlumnos = new List<int>();
                List<String> nombreGrupo = new List<string>();

                foreach (grups item in _gruposSinRepeticiones)
                {
                    numAlumnos.Add(item.grups_has_alumnes.Where(x => x.curs_id == _curs.id).Count());

                    nombreGrupo.Add(item.nom);
                }


                chartTodosLosGrupos.Series[0].Points.DataBindXY(nombreGrupo, numAlumnos);
            }
            
        }
        private void CargarGrafica2(grups _grup) {
            if (_grup != null)
            {
                List<grups_has_alumnes> _grupDiferenteAnio = _grup.grups_has_alumnes.ToList();
                List<grups> _grupoPorAnio = GruposOrm.SeleccionarMismoGrupoPorAnio(_grupDiferenteAnio);
                List<int>idCursosSinRepeticiones = GruposOrm.IDCursosContarPersonas(_grupDiferenteAnio);
                List<int> numAlumnos = new List<int>();
                List<String> nombreGrupo = new List<string>();
                List<String> anioGrupo = new List<string>();
                //foreach (int id in idCursosSinRepeticiones)
                //{
                //    numAlumnos.Add(id.grups_has_alumnes.Where(x => x.grups_id == _grup.id).Count());
                //}
                int countGrup = 0;
                foreach (int item in idCursosSinRepeticiones)
                {
                    numAlumnos.Add(GrupHasWhatOrm.CuentaAlumnosPorIdCurso(item, _grupoPorAnio[countGrup]));
                    anioGrupo.Add(CursosOrm.Nombre(item));
                    countGrup++;
                }
                int count = 0;
                foreach (grups item in _grupoPorAnio)
                {
                    String anioYGrupo = "";
                    anioYGrupo = item.nom;
                    anioYGrupo += " " + anioGrupo[count];
                    nombreGrupo.Add(anioYGrupo);
                    //nombreGrupo.Add(item.nom);
                    count++;
                }


                chartAlumnosGrupoAño.Series[0].Points.DataBindXY(nombreGrupo, numAlumnos);
            }
            
        }

        private void CargarGrafica3(grups _grup)
        {
            if (_grup != null)
            {
                List<grups_has_alumnes> _grupDiferenteAnio = _grup.grups_has_alumnes.ToList();
                List<grups> _grupoPorAnio = GruposOrm.SeleccionarMismoGrupoPorAnio(_grupDiferenteAnio);
                List<int> idCursosSinRepeticiones = GruposOrm.IDCursosContarPersonas(_grupDiferenteAnio);

                List<int> CuentaAlumnosDeEsteCurso = new List<int>();
                List<usuaris> _usuaris = new List<usuaris>();

                List<String> nombreGrupo = new List<string>();
                List<String> anioGrupo = new List<string>();

                int countGrup = 0;
                int sumaTodasNotas;
                List<int> media = new List<int>();
                foreach (int item in idCursosSinRepeticiones)
                {
                    CuentaAlumnosDeEsteCurso.Add(GrupHasWhatOrm.CuentaAlumnosPorIdCurso(item, _grupoPorAnio[countGrup]));


                    sumaTodasNotas = GrupHasWhatOrm.SumaDeTodasLasNotasDeTodosAlumnos(item, _grupoPorAnio[countGrup]);
                    int mediaProvisional = sumaTodasNotas / CuentaAlumnosDeEsteCurso[countGrup];
                    media.Add(mediaProvisional);

                    anioGrupo.Add(CursosOrm.Nombre(item));
                    countGrup++;
                }

                int count = 0;
                foreach (grups item in _grupoPorAnio)
                {
                    String anioYGrupo = "";
                    anioYGrupo = item.nom;
                    anioYGrupo += " " + anioGrupo[count];
                    nombreGrupo.Add(anioYGrupo);
                    count++;
                }

                chartNotaXGrupo.Series[0].Points.DataBindXY(nombreGrupo, media);

            }
        }

        private void comboBoxCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cursos _curs = (cursos)comboBoxCursos.SelectedItem;
            CargarGrafica1(_curs);
        }

        private void comboBoxGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            grups _grup = (grups)comboBoxGrupos.SelectedItem;
            CargarGrafica2(_grup);
            CargarGrafica3(_grup);
        }

        private void buttonHorarios_Click(object sender, EventArgs e)
        {
            HorarisGrup frmadminusers = new HorarisGrup(administrador);
            OpenChildForm(frmadminusers, buttonHorarios);
        }

        private void chartTodosLosGrupos_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            horari _horari = (horari)comboBox1.SelectedItem;
            if (_horari != null)
            {
                HorarisGrup frmadminusers = new HorarisGrup(administrador, _horari);
                OpenChildForm(frmadminusers, buttonHorarios);
            }
        }
    }
}

