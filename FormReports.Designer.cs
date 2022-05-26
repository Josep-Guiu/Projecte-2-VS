
namespace Proyecto2
{
    partial class FormReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.UserReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NotaUsuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxGrups = new System.Windows.Forms.ComboBox();
            this.radioButtonPorGrupo = new System.Windows.Forms.RadioButton();
            this.buttonBuscaReport = new System.Windows.Forms.Button();
            this.textBoxUsuarioABuscar = new System.Windows.Forms.TextBox();
            this.radioButtonUsuarioIndividual = new System.Windows.Forms.RadioButton();
            this.radioButtonTodosUsers = new System.Windows.Forms.RadioButton();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.usuarisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bindingSourceUsuari = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceGrups = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bindingSourceNotasUser = new System.Windows.Forms.BindingSource(this.components);
            this.grupsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UserReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotaUsuarioBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usuarisBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUsuari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGrups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceNotasUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // UserReportBindingSource
            // 
            this.UserReportBindingSource.DataSource = typeof(Proyecto2.Models2Reportes.UserReport);
            // 
            // NotaUsuarioBindingSource
            // 
            this.NotaUsuarioBindingSource.DataSource = typeof(Proyecto2.Models2Reportes.NotaUsuario);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(76)))), ((int)(((byte)(92)))));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1334, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 900);
            this.panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxGrups);
            this.groupBox1.Controls.Add(this.radioButtonPorGrupo);
            this.groupBox1.Controls.Add(this.buttonBuscaReport);
            this.groupBox1.Controls.Add(this.textBoxUsuarioABuscar);
            this.groupBox1.Controls.Add(this.radioButtonUsuarioIndividual);
            this.groupBox1.Controls.Add(this.radioButtonTodosUsers);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(22, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(303, 863);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar reportes";
            // 
            // comboBoxGrups
            // 
            this.comboBoxGrups.DataSource = this.grupsBindingSource;
            this.comboBoxGrups.DisplayMember = "nom";
            this.comboBoxGrups.FormattingEnabled = true;
            this.comboBoxGrups.Location = new System.Drawing.Point(30, 394);
            this.comboBoxGrups.Name = "comboBoxGrups";
            this.comboBoxGrups.Size = new System.Drawing.Size(244, 28);
            this.comboBoxGrups.TabIndex = 106;
            this.comboBoxGrups.ValueMember = "id";
            // 
            // radioButtonPorGrupo
            // 
            this.radioButtonPorGrupo.AutoSize = true;
            this.radioButtonPorGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioButtonPorGrupo.Location = new System.Drawing.Point(30, 430);
            this.radioButtonPorGrupo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonPorGrupo.Name = "radioButtonPorGrupo";
            this.radioButtonPorGrupo.Size = new System.Drawing.Size(91, 29);
            this.radioButtonPorGrupo.TabIndex = 105;
            this.radioButtonPorGrupo.Text = "Grupo";
            this.radioButtonPorGrupo.UseVisualStyleBackColor = true;
            // 
            // buttonBuscaReport
            // 
            this.buttonBuscaReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.buttonBuscaReport.FlatAppearance.BorderSize = 0;
            this.buttonBuscaReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.buttonBuscaReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBuscaReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuscaReport.Location = new System.Drawing.Point(0, 796);
            this.buttonBuscaReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonBuscaReport.Name = "buttonBuscaReport";
            this.buttonBuscaReport.Size = new System.Drawing.Size(303, 69);
            this.buttonBuscaReport.TabIndex = 104;
            this.buttonBuscaReport.Text = "BUSCAR";
            this.buttonBuscaReport.UseVisualStyleBackColor = false;
            this.buttonBuscaReport.Click += new System.EventHandler(this.buttonBuscaReport_Click);
            // 
            // textBoxUsuarioABuscar
            // 
            this.textBoxUsuarioABuscar.Location = new System.Drawing.Point(30, 247);
            this.textBoxUsuarioABuscar.Name = "textBoxUsuarioABuscar";
            this.textBoxUsuarioABuscar.Size = new System.Drawing.Size(244, 26);
            this.textBoxUsuarioABuscar.TabIndex = 2;
            this.textBoxUsuarioABuscar.Text = "Insertar DNI";
            // 
            // radioButtonUsuarioIndividual
            // 
            this.radioButtonUsuarioIndividual.AutoSize = true;
            this.radioButtonUsuarioIndividual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioButtonUsuarioIndividual.Location = new System.Drawing.Point(30, 281);
            this.radioButtonUsuarioIndividual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonUsuarioIndividual.Name = "radioButtonUsuarioIndividual";
            this.radioButtonUsuarioIndividual.Size = new System.Drawing.Size(190, 29);
            this.radioButtonUsuarioIndividual.TabIndex = 1;
            this.radioButtonUsuarioIndividual.Text = "Usuario individual";
            this.radioButtonUsuarioIndividual.UseVisualStyleBackColor = true;
            // 
            // radioButtonTodosUsers
            // 
            this.radioButtonTodosUsers.AutoSize = true;
            this.radioButtonTodosUsers.Checked = true;
            this.radioButtonTodosUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioButtonTodosUsers.Location = new System.Drawing.Point(30, 115);
            this.radioButtonTodosUsers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonTodosUsers.Name = "radioButtonTodosUsers";
            this.radioButtonTodosUsers.Size = new System.Drawing.Size(202, 29);
            this.radioButtonTodosUsers.TabIndex = 0;
            this.radioButtonTodosUsers.TabStop = true;
            this.radioButtonTodosUsers.Text = "Todos los usuarios";
            this.radioButtonTodosUsers.UseVisualStyleBackColor = true;
            // 
            // reportViewer2
            // 
            this.reportViewer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(76)))), ((int)(((byte)(92)))));
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Proyecto2.Reportes.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(18, 18);
            this.reportViewer2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(1289, 862);
            this.reportViewer2.TabIndex = 6;
            // 
            // reportViewer1
            // 
            this.reportViewer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(76)))), ((int)(((byte)(92)))));
            this.reportViewer1.DocumentMapWidth = 51;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Proyecto2.ReportUsuarioIndividual.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(18, 19);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1289, 862);
            this.reportViewer1.TabIndex = 7;
            // 
            // reportViewer3
            // 
            this.reportViewer3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(76)))), ((int)(((byte)(92)))));
            this.reportViewer3.DocumentMapWidth = 51;
            reportDataSource1.Name = "DataSetAlumanosGrupo";
            reportDataSource1.Value = this.UserReportBindingSource;
            reportDataSource2.Name = "DataSetAlumnosNotas";
            reportDataSource2.Value = this.NotaUsuarioBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "Proyecto2.ReportPorGrupos.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(18, 18);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.ServerReport.BearerToken = null;
            this.reportViewer3.Size = new System.Drawing.Size(1289, 862);
            this.reportViewer3.TabIndex = 8;
            // 
            // bindingSourceNotasUser
            // 
            this.bindingSourceNotasUser.DataSource = typeof(Proyecto2.Models2Reportes.NotaUsuario);
            // 
            // grupsBindingSource
            // 
            this.grupsBindingSource.DataSource = typeof(Proyecto2.Models.grups);
            // 
            // FormReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1678, 900);
            this.Controls.Add(this.reportViewer3);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormReports";
            this.Text = "FormReports";
            this.Load += new System.EventHandler(this.FormReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UserReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotaUsuarioBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usuarisBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUsuari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGrups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceNotasUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonTodosUsers;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource usuarisBindingSource;
        private System.Windows.Forms.TextBox textBoxUsuarioABuscar;
        private System.Windows.Forms.RadioButton radioButtonUsuarioIndividual;
        private System.Windows.Forms.Button buttonBuscaReport;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource bindingSourceUsuari;
        private System.Windows.Forms.BindingSource bindingSourceNotasUser;
        private System.Windows.Forms.ComboBox comboBoxGrups;
        private System.Windows.Forms.RadioButton radioButtonPorGrupo;
        private System.Windows.Forms.BindingSource bindingSourceGrups;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private System.Windows.Forms.BindingSource UserReportBindingSource;
        private System.Windows.Forms.BindingSource NotaUsuarioBindingSource;
        private System.Windows.Forms.BindingSource grupsBindingSource;
    }
}