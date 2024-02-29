namespace BPFC_System
{
    partial class ManageShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageShow));
            this.splManage = new System.Windows.Forms.SplitContainer();
            this.btnPlantManage = new DevExpress.XtraEditors.SimpleButton();
            this.btnUserManage = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splManage)).BeginInit();
            this.splManage.Panel1.SuspendLayout();
            this.splManage.SuspendLayout();
            this.SuspendLayout();
            // 
            // splManage
            // 
            this.splManage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splManage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splManage.IsSplitterFixed = true;
            this.splManage.Location = new System.Drawing.Point(0, 0);
            this.splManage.Name = "splManage";
            // 
            // splManage.Panel1
            // 
            this.splManage.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splManage.Panel1.Controls.Add(this.btnPlantManage);
            this.splManage.Panel1.Controls.Add(this.btnUserManage);
            // 
            // splManage.Panel2
            // 
            this.splManage.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splManage.Size = new System.Drawing.Size(1298, 634);
            this.splManage.SplitterDistance = 184;
            this.splManage.SplitterWidth = 1;
            this.splManage.TabIndex = 1;
            // 
            // btnPlantManage
            // 
            this.btnPlantManage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlantManage.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlantManage.Appearance.Options.UseFont = true;
            this.btnPlantManage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPlantManage.ImageOptions.Image")));
            this.btnPlantManage.Location = new System.Drawing.Point(15, 65);
            this.btnPlantManage.LookAndFeel.SkinMaskColor = System.Drawing.Color.SkyBlue;
            this.btnPlantManage.LookAndFeel.SkinName = "Coffee";
            this.btnPlantManage.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPlantManage.Name = "btnPlantManage";
            this.btnPlantManage.Size = new System.Drawing.Size(154, 40);
            this.btnPlantManage.TabIndex = 0;
            this.btnPlantManage.Text = "Quản lý xưởng";
            this.btnPlantManage.Click += new System.EventHandler(this.btnPlantManage_Click);
            // 
            // btnUserManage
            // 
            this.btnUserManage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserManage.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserManage.Appearance.Options.UseFont = true;
            this.btnUserManage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUserManage.ImageOptions.Image")));
            this.btnUserManage.Location = new System.Drawing.Point(15, 10);
            this.btnUserManage.LookAndFeel.SkinMaskColor = System.Drawing.Color.SkyBlue;
            this.btnUserManage.LookAndFeel.SkinName = "Coffee";
            this.btnUserManage.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnUserManage.Name = "btnUserManage";
            this.btnUserManage.Size = new System.Drawing.Size(154, 40);
            this.btnUserManage.TabIndex = 0;
            this.btnUserManage.Text = "Quản lý tài khoản";
            this.btnUserManage.Click += new System.EventHandler(this.btnUsersManage_Click);
            // 
            // ManageShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splManage);
            this.Name = "ManageShow";
            this.Size = new System.Drawing.Size(1298, 634);
            this.Load += new System.EventHandler(this.btnUsersManage_Click);
            this.splManage.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splManage)).EndInit();
            this.splManage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splManage;
        private DevExpress.XtraEditors.SimpleButton btnPlantManage;
        private DevExpress.XtraEditors.SimpleButton btnUserManage;
    }
}
