using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BPFC_System
{
    public partial class ManageShow : UserControl
    {
        private CreateUsers createUsersControl;
        private CreatePlant createPlantControl;

        public ManageShow()
        {
            InitializeComponent();
            createUsersControl = new CreateUsers();
            createPlantControl = new CreatePlant();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            // Tạo các màu cho gradient
            Color color1 = Color.Black; // Màu đen
            Color color2 = Color.Navy; // Màu navy
            Color color3 = Color.DarkBlue; // Màu xanh

            // Tạo một LinearGradientBrush
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, color1, color1, LinearGradientMode.Horizontal))
            {
                ColorBlend colorBlend = new ColorBlend();
                colorBlend.Colors = new Color[] { color1, color2, color3, color2 }; // Thứ tự màu sắc
                colorBlend.Positions = new float[] { 0.0f, 0.4f, 0.6f, 1.0f };

                brush.InterpolationColors = colorBlend;

                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void btnUsersManage_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu đang hiển thị ucCreateUsers thì không cần làm gì
            if (!splManage.Panel2.Controls.Contains(createUsersControl))
            {
                splManage.Panel2.Controls.Clear();
                createUsersControl.Dock = DockStyle.Fill;
                splManage.Panel2.Controls.Add(createUsersControl);
            }
        }

        private void btnPlantManage_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu đang hiển thị ucCreatePlant thì không cần làm gì
            if (!splManage.Panel2.Controls.Contains(createPlantControl))
            {
                splManage.Panel2.Controls.Clear();
                createPlantControl.Dock = DockStyle.Fill;
                splManage.Panel2.Controls.Add(createPlantControl);
            }
        }
    }
}
