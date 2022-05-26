
namespace Proyecto2
{
    partial class AdministrarCursos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonGuardaCurs = new System.Windows.Forms.Button();
            this.checkBoxActivo = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxFiCurs = new System.Windows.Forms.TextBox();
            this.textBoxIniciCurs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonActivoTodos = new System.Windows.Forms.RadioButton();
            this.radioButtonActivoTrue = new System.Windows.Forms.RadioButton();
            this.radioButtonActivoFalse = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEliminarCurso = new System.Windows.Forms.Button();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.dataGridViewCursos = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cursiniciDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cursfiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actiuDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grupshasalumnesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupshasdocentsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupshasllistesskillsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceCursos = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCursos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCursos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(76)))), ((int)(((byte)(92)))));
            this.panel1.Controls.Add(this.buttonGuardaCurs);
            this.panel1.Controls.Add(this.checkBoxActivo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxFiCurs);
            this.panel1.Controls.Add(this.textBoxIniciCurs);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(906, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 624);
            this.panel1.TabIndex = 0;
            // 
            // buttonGuardaCurs
            // 
            this.buttonGuardaCurs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.buttonGuardaCurs.FlatAppearance.BorderSize = 0;
            this.buttonGuardaCurs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.buttonGuardaCurs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuardaCurs.Location = new System.Drawing.Point(65, 522);
            this.buttonGuardaCurs.Name = "buttonGuardaCurs";
            this.buttonGuardaCurs.Size = new System.Drawing.Size(106, 24);
            this.buttonGuardaCurs.TabIndex = 90;
            this.buttonGuardaCurs.Text = "GUARDAR";
            this.buttonGuardaCurs.UseVisualStyleBackColor = false;
            this.buttonGuardaCurs.Click += new System.EventHandler(this.buttonGuardaCurs_Click);
            // 
            // checkBoxActivo
            // 
            this.checkBoxActivo.Checked = true;
            this.checkBoxActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxActivo.FlatAppearance.BorderSize = 0;
            this.checkBoxActivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.checkBoxActivo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBoxActivo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBoxActivo.Location = new System.Drawing.Point(65, 359);
            this.checkBoxActivo.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxActivo.MinimumSize = new System.Drawing.Size(20, 19);
            this.checkBoxActivo.Name = "checkBoxActivo";
            this.checkBoxActivo.Size = new System.Drawing.Size(106, 25);
            this.checkBoxActivo.TabIndex = 85;
            this.checkBoxActivo.Text = "¿Curs actiu?";
            this.checkBoxActivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.checkBoxActivo.UseVisualStyleBackColor = true;
            this.checkBoxActivo.CheckedChanged += new System.EventHandler(this.checkBoxActivo_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(25, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 18);
            this.label5.TabIndex = 65;
            this.label5.Text = "Mantenimiento de cursos";
            // 
            // textBoxFiCurs
            // 
            this.textBoxFiCurs.Location = new System.Drawing.Point(28, 222);
            this.textBoxFiCurs.Name = "textBoxFiCurs";
            this.textBoxFiCurs.Size = new System.Drawing.Size(176, 20);
            this.textBoxFiCurs.TabIndex = 63;
            // 
            // textBoxIniciCurs
            // 
            this.textBoxIniciCurs.Location = new System.Drawing.Point(28, 129);
            this.textBoxIniciCurs.Name = "textBoxIniciCurs";
            this.textBoxIniciCurs.Size = new System.Drawing.Size(176, 20);
            this.textBoxIniciCurs.TabIndex = 62;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 60;
            this.label3.Text = "Fi de curs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Inici de curs";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.buttonEliminarCurso);
            this.panel2.Controls.Add(this.buttonModificar);
            this.panel2.Controls.Add(this.dataGridViewCursos);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(906, 624);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonActivoTodos);
            this.groupBox1.Controls.Add(this.radioButtonActivoTrue);
            this.groupBox1.Controls.Add(this.radioButtonActivoFalse);
            this.groupBox1.Location = new System.Drawing.Point(323, 561);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 38);
            this.groupBox1.TabIndex = 93;
            this.groupBox1.TabStop = false;
            // 
            // radioButtonActivoTodos
            // 
            this.radioButtonActivoTodos.AutoSize = true;
            this.radioButtonActivoTodos.Checked = true;
            this.radioButtonActivoTodos.Location = new System.Drawing.Point(152, 13);
            this.radioButtonActivoTodos.Name = "radioButtonActivoTodos";
            this.radioButtonActivoTodos.Size = new System.Drawing.Size(55, 17);
            this.radioButtonActivoTodos.TabIndex = 92;
            this.radioButtonActivoTodos.TabStop = true;
            this.radioButtonActivoTodos.Text = "Todos";
            this.radioButtonActivoTodos.UseVisualStyleBackColor = true;
            this.radioButtonActivoTodos.CheckedChanged += new System.EventHandler(this.radioButtonActivoTodos_CheckedChanged);
            // 
            // radioButtonActivoTrue
            // 
            this.radioButtonActivoTrue.AutoSize = true;
            this.radioButtonActivoTrue.Location = new System.Drawing.Point(3, 13);
            this.radioButtonActivoTrue.Name = "radioButtonActivoTrue";
            this.radioButtonActivoTrue.Size = new System.Drawing.Size(60, 17);
            this.radioButtonActivoTrue.TabIndex = 90;
            this.radioButtonActivoTrue.Text = "Activos";
            this.radioButtonActivoTrue.UseVisualStyleBackColor = true;
            this.radioButtonActivoTrue.CheckedChanged += new System.EventHandler(this.radioButtonActivoTrue_CheckedChanged);
            // 
            // radioButtonActivoFalse
            // 
            this.radioButtonActivoFalse.AutoSize = true;
            this.radioButtonActivoFalse.Location = new System.Drawing.Point(69, 13);
            this.radioButtonActivoFalse.Name = "radioButtonActivoFalse";
            this.radioButtonActivoFalse.Size = new System.Drawing.Size(77, 17);
            this.radioButtonActivoFalse.TabIndex = 91;
            this.radioButtonActivoFalse.Text = "No Activos";
            this.radioButtonActivoFalse.UseVisualStyleBackColor = true;
            this.radioButtonActivoFalse.CheckedChanged += new System.EventHandler(this.radioButtonActivoFalse_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label14.Location = new System.Drawing.Point(320, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 24);
            this.label14.TabIndex = 89;
            this.label14.Text = "/CURSOS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 29);
            this.label1.TabIndex = 88;
            this.label1.Text = "ADMINISTRAR SERVICIOS";
            // 
            // buttonEliminarCurso
            // 
            this.buttonEliminarCurso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.buttonEliminarCurso.FlatAppearance.BorderSize = 0;
            this.buttonEliminarCurso.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.buttonEliminarCurso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEliminarCurso.Location = new System.Drawing.Point(115, 573);
            this.buttonEliminarCurso.Name = "buttonEliminarCurso";
            this.buttonEliminarCurso.Size = new System.Drawing.Size(92, 24);
            this.buttonEliminarCurso.TabIndex = 87;
            this.buttonEliminarCurso.Text = "ELIMINAR";
            this.buttonEliminarCurso.UseVisualStyleBackColor = false;
            this.buttonEliminarCurso.Click += new System.EventHandler(this.buttonEliminarCurso_Click);
            // 
            // buttonModificar
            // 
            this.buttonModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.buttonModificar.FlatAppearance.BorderSize = 0;
            this.buttonModificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.buttonModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModificar.Location = new System.Drawing.Point(17, 573);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(92, 24);
            this.buttonModificar.TabIndex = 86;
            this.buttonModificar.Text = "MODIFICAR";
            this.buttonModificar.UseVisualStyleBackColor = false;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // dataGridViewCursos
            // 
            this.dataGridViewCursos.AllowUserToAddRows = false;
            this.dataGridViewCursos.AllowUserToDeleteRows = false;
            this.dataGridViewCursos.AutoGenerateColumns = false;
            this.dataGridViewCursos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewCursos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCursos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dataGridViewCursos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCursos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCursos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCursos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.cursiniciDataGridViewTextBoxColumn,
            this.cursfiDataGridViewTextBoxColumn,
            this.actiuDataGridViewCheckBoxColumn,
            this.grupshasalumnesDataGridViewTextBoxColumn,
            this.grupshasdocentsDataGridViewTextBoxColumn,
            this.grupshasllistesskillsDataGridViewTextBoxColumn});
            this.dataGridViewCursos.DataSource = this.bindingSourceCursos;
            this.dataGridViewCursos.EnableHeadersVisualStyles = false;
            this.dataGridViewCursos.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewCursos.Location = new System.Drawing.Point(13, 51);
            this.dataGridViewCursos.Name = "dataGridViewCursos";
            this.dataGridViewCursos.ReadOnly = true;
            this.dataGridViewCursos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCursos.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewCursos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCursos.Size = new System.Drawing.Size(874, 495);
            this.dataGridViewCursos.TabIndex = 0;
            this.dataGridViewCursos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCursos_CellClick);
            this.dataGridViewCursos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridViewCursos.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridViewCursos_UserDeletingRow);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 43;
            // 
            // cursiniciDataGridViewTextBoxColumn
            // 
            this.cursiniciDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cursiniciDataGridViewTextBoxColumn.DataPropertyName = "curs_inici";
            this.cursiniciDataGridViewTextBoxColumn.HeaderText = "Fecha de inicio";
            this.cursiniciDataGridViewTextBoxColumn.Name = "cursiniciDataGridViewTextBoxColumn";
            this.cursiniciDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cursfiDataGridViewTextBoxColumn
            // 
            this.cursfiDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cursfiDataGridViewTextBoxColumn.DataPropertyName = "curs_fi";
            this.cursfiDataGridViewTextBoxColumn.HeaderText = "Fecha de fin";
            this.cursfiDataGridViewTextBoxColumn.Name = "cursfiDataGridViewTextBoxColumn";
            this.cursfiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // actiuDataGridViewCheckBoxColumn
            // 
            this.actiuDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.actiuDataGridViewCheckBoxColumn.DataPropertyName = "actiu";
            this.actiuDataGridViewCheckBoxColumn.HeaderText = "Curso Activo";
            this.actiuDataGridViewCheckBoxColumn.Name = "actiuDataGridViewCheckBoxColumn";
            this.actiuDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // grupshasalumnesDataGridViewTextBoxColumn
            // 
            this.grupshasalumnesDataGridViewTextBoxColumn.DataPropertyName = "grups_has_alumnes";
            this.grupshasalumnesDataGridViewTextBoxColumn.HeaderText = "grups_has_alumnes";
            this.grupshasalumnesDataGridViewTextBoxColumn.Name = "grupshasalumnesDataGridViewTextBoxColumn";
            this.grupshasalumnesDataGridViewTextBoxColumn.ReadOnly = true;
            this.grupshasalumnesDataGridViewTextBoxColumn.Visible = false;
            this.grupshasalumnesDataGridViewTextBoxColumn.Width = 156;
            // 
            // grupshasdocentsDataGridViewTextBoxColumn
            // 
            this.grupshasdocentsDataGridViewTextBoxColumn.DataPropertyName = "grups_has_docents";
            this.grupshasdocentsDataGridViewTextBoxColumn.HeaderText = "grups_has_docents";
            this.grupshasdocentsDataGridViewTextBoxColumn.Name = "grupshasdocentsDataGridViewTextBoxColumn";
            this.grupshasdocentsDataGridViewTextBoxColumn.ReadOnly = true;
            this.grupshasdocentsDataGridViewTextBoxColumn.Visible = false;
            this.grupshasdocentsDataGridViewTextBoxColumn.Width = 154;
            // 
            // grupshasllistesskillsDataGridViewTextBoxColumn
            // 
            this.grupshasllistesskillsDataGridViewTextBoxColumn.DataPropertyName = "grups_has_llistes_skills";
            this.grupshasllistesskillsDataGridViewTextBoxColumn.HeaderText = "grups_has_llistes_skills";
            this.grupshasllistesskillsDataGridViewTextBoxColumn.Name = "grupshasllistesskillsDataGridViewTextBoxColumn";
            this.grupshasllistesskillsDataGridViewTextBoxColumn.ReadOnly = true;
            this.grupshasllistesskillsDataGridViewTextBoxColumn.Visible = false;
            this.grupshasllistesskillsDataGridViewTextBoxColumn.Width = 167;
            // 
            // bindingSourceCursos
            // 
            this.bindingSourceCursos.DataSource = typeof(Proyecto2.Models.cursos);
            // 
            // AdministrarCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 624);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdministrarCursos";
            this.Text = "AdministrarCursos";
            this.Load += new System.EventHandler(this.AdministrarCursos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCursos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCursos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewCursos;
        private System.Windows.Forms.Button buttonEliminarCurso;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxFiCurs;
        private System.Windows.Forms.TextBox textBoxIniciCurs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonGuardaCurs;
        private System.Windows.Forms.CheckBox checkBoxActivo;
        private System.Windows.Forms.BindingSource bindingSourceCursos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonActivoTodos;
        private System.Windows.Forms.RadioButton radioButtonActivoTrue;
        private System.Windows.Forms.RadioButton radioButtonActivoFalse;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cursiniciDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cursfiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn actiuDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupshasalumnesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupshasdocentsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupshasllistesskillsDataGridViewTextBoxColumn;
    }
}