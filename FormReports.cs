using Microsoft.Reporting.WinForms;
using Proyecto2.Models;
using Proyecto2.Models2Controllers;
using Proyecto2.Models2Reportes;
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
    public partial class FormReports : Form
    {
        public FormReports()
        {
            InitializeComponent();
        }

        private void FormReports_Load(object sender, EventArgs e)
        {
            
            List<grups> groups = GruposOrm.Select();
            bindingSourceGrups.DataSource = groups;
            comboBoxGrups.DataSource = bindingSourceGrups;


            usuarisBindingSource.DataSource = UserController.SeleccionarTodosUsuariosController();

            CargaDeReportePrincipal();

            
        }

        private void CargaDeReportePrincipal() {

                reportViewer1.Visible = false;
                reportViewer3.Visible = false;
                reportViewer2.Visible = true;

                ReportDataSource x = new ReportDataSource("DataSet1", usuarisBindingSource);
                this.reportViewer2.LocalReport.DataSources.Add(x);

                this.reportViewer2.RefreshReport();

        }

        private void CargarReporteGrupal() {

            reportViewer1.Visible = false;
            reportViewer3.Visible = true;
            reportViewer2.Visible = false;

            grups _grup = (grups)comboBoxGrups.SelectedItem;

            List<UserReport> x = UserController.SeleccionarUsuariosPorGrupo(_grup.id);
            List<NotaUsuario> y = UserController.SeleccionarNotasPorGrupo(_grup.id);

            UserReportBindingSource.DataSource = x;
            NotaUsuarioBindingSource.DataSource = y;

            ReportDataSource yy = new ReportDataSource("DataSetAlumanosGrupo", UserReportBindingSource);
            ReportDataSource yyy = new ReportDataSource("DataSetAlumnosNotas", NotaUsuarioBindingSource);

            this.reportViewer3.LocalReport.DataSources.Add(yy);
            this.reportViewer3.LocalReport.DataSources.Add(yyy);

            this.reportViewer3.RefreshReport();

        }

        private void CargarReporteIndividual() {
            reportViewer2.Visible = false;
            reportViewer3.Visible = false;
            reportViewer1.Visible = true;

            String Dni = textBoxUsuarioABuscar.Text.ToString();
            if (!Dni.Equals("Insertar DNI"))
            {
                UserReport x = UserController.SeleccionarUnUsuarioController(Dni);
                
                if (x.Id == 0)
                {
                    MessageBox.Show("No existe el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CargaDeReportePrincipal();
                }
                else if (x.Id == 1 || x.Id == 2)
                {
                    MessageBox.Show("Administradores o Profesores NO tienen reportes individuales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CargaDeReportePrincipal();
                }
                else
                {
                    bindingSourceUsuari.DataSource = x;
                    bindingSourceNotasUser.DataSource = UserController.SeleccionarTodasNotasUsuari(x.Id);
                    ReportDataSource xx = new ReportDataSource("DataSetUsuarioIndividual", bindingSourceUsuari);
                    ReportDataSource xxx = new ReportDataSource("DataSetNotasIndividuales", bindingSourceNotasUser);

                    this.reportViewer1.LocalReport.DataSources.Add(xx);
                    this.reportViewer1.LocalReport.DataSources.Add(xxx);

                    this.reportViewer1.RefreshReport();
                }
            }
            else
            {
                MessageBox.Show("Debes insertar el DNI del usuario a buscar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CargaDeReportePrincipal();
            }

        }

        private void buttonBuscaReport_Click(object sender, EventArgs e)
        {
            if (radioButtonTodosUsers.Checked)
            {
                CargaDeReportePrincipal();
            }
            else if (radioButtonUsuarioIndividual.Checked)
            {
                CargarReporteIndividual();
            }
            else if (radioButtonPorGrupo.Checked)
            {
                CargarReporteGrupal();
            }

            
        }
    }
}
