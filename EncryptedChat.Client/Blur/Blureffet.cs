using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace BlurredLoginUIWindow.Class
{
  class WindowBlureffect
  {
    [DllImport("user32.dll")]
    internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);
    private uint _blurBackgroundColor = 0x990000;
    internal void EnableBlur(Window window)
    {
      var windowHelper = new WindowInteropHelper(window);
      var accent = new AccentPolicy();


      //To  enable blur the image behind the window
      accent.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND;
      accent.GradientColor =  (_blurBackgroundColor & 0xFFFFFF);

      var accentStructSize = Marshal.SizeOf(accent);

      var accentPtr = Marshal.AllocHGlobal(accentStructSize);
      Marshal.StructureToPtr(accent, accentPtr, false);

      var data = new WindowCompositionAttributeData();
      data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
      data.SizeOfData = accentStructSize;
      data.Data = accentPtr;

      SetWindowCompositionAttribute(windowHelper.Handle, ref data);

      Marshal.FreeHGlobal(accentPtr);
    }

    //to call blur in our desired window
    internal WindowBlureffect(Window window)
    {
      EnableBlur(window);
    }
  }
}

