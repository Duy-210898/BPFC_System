namespace BFPC_System
{
    partial class KaizenPlugin
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
            this.btnDocument = new DevExpress.XtraEditors.SimpleButton();
            this.btnEvaluate = new DevExpress.XtraEditors.SimpleButton();
            this.btnData = new DevExpress.XtraEditors.SimpleButton();
            this.btnMe = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnDocument
            // 
            this.btnDocument.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocument.Appearance.Options.UseFont = true;
            this.btnDocument.Location = new System.Drawing.Point(20, 114);
            this.btnDocument.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDocument.LookAndFeel.SkinName = "Dark Side";
            this.btnDocument.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDocument.Name = "btnDocument";
            this.btnDocument.Size = new System.Drawing.Size(160, 40);
            this.btnDocument.TabIndex = 11;
            this.btnDocument.Text = "TÀI LIỆU";
            // 
            // btnEvaluate
            // 
            this.btnEvaluate.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvaluate.Appearance.Options.UseFont = true;
            this.btnEvaluate.Location = new System.Drawing.Point(20, 67);
            this.btnEvaluate.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEvaluate.LookAndFeel.SkinName = "Dark Side";
            this.btnEvaluate.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnEvaluate.Name = "btnEvaluate";
            this.btnEvaluate.ShowToolTips = false;
            this.btnEvaluate.Size = new System.Drawing.Size(160, 40);
            this.btnEvaluate.TabIndex = 10;
            this.btnEvaluate.Text = "ĐÁNH GIÁ KAIZEN";
            // 
            // btnData
            // 
            this.btnData.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnData.Appearance.Options.UseFont = true;
            this.btnData.Location = new System.Drawing.Point(20, 20);
            this.btnData.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnData.LookAndFeel.SkinName = "Dark Side";
            this.btnData.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(160, 40);
            this.btnData.TabIndex = 9;
            this.btnData.Text = "DỮ LIỆU KAIZEN";
            // 
            // btnMe
            // 
            this.btnMe.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMe.Appearance.Options.UseFont = true;
            this.btnMe.Location = new System.Drawing.Point(20, 161);
            this.btnMe.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMe.LookAndFeel.SkinName = "Dark Side";
            this.btnMe.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnMe.Name = "btnMe";
            this.btnMe.Size = new System.Drawing.Size(160, 40);
            this.btnMe.TabIndex = 13;
            this.btnMe.Text = "NHẬP CẢI TIẾN";
            // 
            // KaizenPlugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnMe);
            this.Controls.Add(this.btnDocument);
            this.Controls.Add(this.btnEvaluate);
            this.Controls.Add(this.btnData);
            this.Name = "KaizenPlugin";
            this.Size = new System.Drawing.Size(618, 465);
            this.Load += new System.EventHandler(this.Kaizenlugin_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnDocument;
        private DevExpress.XtraEditors.SimpleButton btnEvaluate;
        private DevExpress.XtraEditors.SimpleButton btnData;
        private DevExpress.XtraEditors.SimpleButton btnMe;
    }
}
