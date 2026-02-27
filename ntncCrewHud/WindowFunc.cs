using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ntncCrewHud
{
    class Window
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public static bool GetWindowBounds(IntPtr hWnd, out Rectangle rect)
        {
            RECT lpRect;

            bool success = GetWindowRect(hWnd, out lpRect);
            if (success)
            {
                rect = new Rectangle(lpRect.Left, lpRect.Top, lpRect.Right - lpRect.Left, lpRect.Bottom - lpRect.Top);
                return true;
            }
            else
            {
                rect = new Rectangle(0, 0, 0, 0);
                return false;
            }
        }
    }
}