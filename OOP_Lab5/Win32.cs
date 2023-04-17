using System;
using System.Runtime.InteropServices;

namespace OOP_Lab2
{
    public class Win32
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void MessageBox(int hWnd, String text, String caption, uint type);
    }
}
