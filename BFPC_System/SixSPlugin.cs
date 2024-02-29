using System.Windows.Forms;

namespace BFPC_System
{
    public partial class SixSPlugin : UserControl
    {
        public SixSPlugin()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }
    }
}
