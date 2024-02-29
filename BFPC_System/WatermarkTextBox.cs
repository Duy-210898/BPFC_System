using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

public class WatermarkTextBox : TextBox
{
    private const uint ECM_FIRST = 0x1500;
    private const uint EM_SETCUEBANNER = ECM_FIRST + 1;
    private bool isWatermarkSet = false;

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, string lParam);

    public void SetWatermark(string watermarkText)
    {
        SendMessage(this.Handle, EM_SETCUEBANNER, (IntPtr)1, watermarkText);
        isWatermarkSet = true;
    }

    public bool IsWatermarkSet()
    {
        return isWatermarkSet;
    }
}