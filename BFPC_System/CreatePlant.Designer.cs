namespace BPFC_System
{
    partial class CreatePlant
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePlant));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtEditLine = new WatermarkTextBox();
            this.cbxPlantNames = new System.Windows.Forms.ComboBox();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveLines = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteLine = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditLines = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeletePlant = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.lvProductionLines = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddPlant = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numNumberOfLines = new System.Windows.Forms.NumericUpDown();
            this.txtPlantName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfLines)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(1105, 626);
            this.splitContainer1.SplitterDistance = 361;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtEditLine);
            this.panel2.Controls.Add(this.cbxPlantNames);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSaveLines);
            this.panel2.Controls.Add(this.btnDeleteLine);
            this.panel2.Controls.Add(this.btnEditLines);
            this.panel2.Controls.Add(this.btnDeletePlant);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lvProductionLines);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 132);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 494);
            this.panel2.TabIndex = 10;
            // 
            // txtEditLine
            // 
            this.txtEditLine.Location = new System.Drawing.Point(17, 95);
            this.txtEditLine.Multiline = true;
            this.txtEditLine.Name = "txtEditLine";
            this.txtEditLine.Size = new System.Drawing.Size(198, 309);
            this.txtEditLine.TabIndex = 19;
            // 
            // cbxPlantNames
            // 
            this.cbxPlantNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxPlantNames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxPlantNames.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPlantNames.FormattingEnabled = true;
            this.cbxPlantNames.Location = new System.Drawing.Point(102, 55);
            this.cbxPlantNames.Name = "cbxPlantNames";
            this.cbxPlantNames.Size = new System.Drawing.Size(236, 27);
            this.cbxPlantNames.TabIndex = 18;
            this.cbxPlantNames.SelectedIndexChanged += new System.EventHandler(this.cbxPlantNames_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(240, 95);
            this.btnCancel.LookAndFeel.SkinMaskColor = System.Drawing.Color.Orange;
            this.btnCancel.LookAndFeel.SkinName = "Pumpkin";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 29);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveLines
            // 
            this.btnSaveLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveLines.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveLines.Appearance.Options.UseFont = true;
            this.btnSaveLines.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveLines.ImageOptions.Image")));
            this.btnSaveLines.Location = new System.Drawing.Point(240, 130);
            this.btnSaveLines.LookAndFeel.SkinMaskColor = System.Drawing.Color.Orange;
            this.btnSaveLines.LookAndFeel.SkinName = "Pumpkin";
            this.btnSaveLines.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSaveLines.Name = "btnSaveLines";
            this.btnSaveLines.Size = new System.Drawing.Size(69, 29);
            this.btnSaveLines.TabIndex = 14;
            this.btnSaveLines.Text = "Lưu";
            this.btnSaveLines.Visible = false;
            this.btnSaveLines.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDeleteLine
            // 
            this.btnDeleteLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteLine.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteLine.Appearance.Options.UseFont = true;
            this.btnDeleteLine.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteLine.ImageOptions.Image")));
            this.btnDeleteLine.Location = new System.Drawing.Point(240, 130);
            this.btnDeleteLine.LookAndFeel.SkinMaskColor = System.Drawing.Color.Orange;
            this.btnDeleteLine.LookAndFeel.SkinName = "Pumpkin";
            this.btnDeleteLine.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDeleteLine.Name = "btnDeleteLine";
            this.btnDeleteLine.Size = new System.Drawing.Size(98, 29);
            this.btnDeleteLine.TabIndex = 14;
            this.btnDeleteLine.Text = "Xóa chuyền";
            this.btnDeleteLine.Visible = false;
            this.btnDeleteLine.Click += new System.EventHandler(this.btnDeleteLine_Click);
            // 
            // btnEditLines
            // 
            this.btnEditLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditLines.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditLines.Appearance.Options.UseFont = true;
            this.btnEditLines.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditLines.ImageOptions.Image")));
            this.btnEditLines.Location = new System.Drawing.Point(240, 95);
            this.btnEditLines.LookAndFeel.SkinMaskColor = System.Drawing.Color.Orange;
            this.btnEditLines.LookAndFeel.SkinName = "Pumpkin";
            this.btnEditLines.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnEditLines.Name = "btnEditLines";
            this.btnEditLines.Size = new System.Drawing.Size(98, 29);
            this.btnEditLines.TabIndex = 14;
            this.btnEditLines.Text = "Đổi tên";
            this.btnEditLines.Visible = false;
            this.btnEditLines.Click += new System.EventHandler(this.btnEditLines_Click);
            // 
            // btnDeletePlant
            // 
            this.btnDeletePlant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeletePlant.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePlant.Appearance.Options.UseFont = true;
            this.btnDeletePlant.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeletePlant.ImageOptions.Image")));
            this.btnDeletePlant.Location = new System.Drawing.Point(240, 95);
            this.btnDeletePlant.LookAndFeel.SkinMaskColor = System.Drawing.Color.Orange;
            this.btnDeletePlant.LookAndFeel.SkinName = "Pumpkin";
            this.btnDeletePlant.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDeletePlant.Name = "btnDeletePlant";
            this.btnDeletePlant.Size = new System.Drawing.Size(98, 29);
            this.btnDeletePlant.TabIndex = 14;
            this.btnDeletePlant.Text = "Xóa xưởng";
            this.btnDeletePlant.Click += new System.EventHandler(this.btnDeletePlant_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(17, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 26);
            this.label5.TabIndex = 17;
            this.label5.Text = "Chọn:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvProductionLines
            // 
            this.lvProductionLines.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lvProductionLines.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvProductionLines.HideSelection = false;
            this.lvProductionLines.Location = new System.Drawing.Point(17, 95);
            this.lvProductionLines.Name = "lvProductionLines";
            this.lvProductionLines.Size = new System.Drawing.Size(198, 309);
            this.lvProductionLines.TabIndex = 16;
            this.lvProductionLines.TabStop = false;
            this.lvProductionLines.UseCompatibleStateImageBehavior = false;
            this.lvProductionLines.View = System.Windows.Forms.View.List;
            this.lvProductionLines.SelectedIndexChanged += new System.EventHandler(this.lvProductionLines_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(357, 44);
            this.label4.TabIndex = 12;
            this.label4.Text = "   XƯỞNG HIỆN TẠI";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnAddPlant);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numNumberOfLines);
            this.panel1.Controls.Add(this.txtPlantName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 132);
            this.panel1.TabIndex = 9;
            // 
            // btnAddPlant
            // 
            this.btnAddPlant.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPlant.Appearance.Options.UseFont = true;
            this.btnAddPlant.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPlant.ImageOptions.Image")));
            this.btnAddPlant.Location = new System.Drawing.Point(240, 94);
            this.btnAddPlant.LookAndFeel.SkinMaskColor = System.Drawing.Color.Orange;
            this.btnAddPlant.LookAndFeel.SkinName = "Pumpkin";
            this.btnAddPlant.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAddPlant.Name = "btnAddPlant";
            this.btnAddPlant.Size = new System.Drawing.Size(98, 28);
            this.btnAddPlant.TabIndex = 13;
            this.btnAddPlant.Text = "Tạo xưởng";
            this.btnAddPlant.Click += new System.EventHandler(this.btnAddPlant_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(17, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 26);
            this.label3.TabIndex = 11;
            this.label3.Text = "Số chuyền:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(17, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tên xưởng:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numNumberOfLines
            // 
            this.numNumberOfLines.BackColor = System.Drawing.SystemColors.Window;
            this.numNumberOfLines.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numNumberOfLines.Location = new System.Drawing.Point(102, 94);
            this.numNumberOfLines.Name = "numNumberOfLines";
            this.numNumberOfLines.Size = new System.Drawing.Size(121, 26);
            this.numNumberOfLines.TabIndex = 10;
            this.numNumberOfLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPlantName
            // 
            this.txtPlantName.BackColor = System.Drawing.SystemColors.Window;
            this.txtPlantName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlantName.Location = new System.Drawing.Point(102, 57);
            this.txtPlantName.Name = "txtPlantName";
            this.txtPlantName.Size = new System.Drawing.Size(121, 26);
            this.txtPlantName.TabIndex = 9;
            this.txtPlantName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPlantName_KeyDown);
            this.txtPlantName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlantName_KeyPress);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(357, 44);
            this.label2.TabIndex = 7;
            this.label2.Text = "   THÊM XƯỞNG MỚI";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(740, 626);
            this.panel3.TabIndex = 0;
            // 
            // CreatePlant
            // 
            this.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CreatePlant";
            this.Size = new System.Drawing.Size(1105, 626);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfLines)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnAddPlant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numNumberOfLines;
        private System.Windows.Forms.TextBox txtPlantName;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnDeletePlant;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lvProductionLines;
        private System.Windows.Forms.ComboBox cbxPlantNames;
        private System.Windows.Forms.Panel panel3;
        private WatermarkTextBox txtEditLine;
        private DevExpress.XtraEditors.SimpleButton btnSaveLines;
        private DevExpress.XtraEditors.SimpleButton btnEditLines;
        private DevExpress.XtraEditors.SimpleButton btnDeleteLine;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
