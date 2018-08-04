#region # using *.*
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LemLib;
#endregion

namespace LemTool
{
  public partial class LemToolForm1 : Form
  {
    public LemToolForm1()
    {
      InitializeComponent();
    }

    private void LemToolForm1_Shown(object sender, EventArgs e)
    {
      var c0 = new Color3F(0, 0, 0); // black
      var c1 = new Color3F(0, 0, 1); // blue
      var c2 = new Color3F(0, 1, 0); // gree
      var c3 = new Color3F(1, 0, 0); // red
      var c4 = new Color3F(1, 1, 1); // white

      var gColor = new int[1024];
      for (int i = 0; i < 256; i++)
      {
        float f = i / 256f;

        gColor[i] = Color3F.Mix(c0, c1, f).Int32;
        gColor[i + 256] = Color3F.Mix(c1, c2, f).Int32;
        gColor[i + 512] = Color3F.Mix(c2, c3, f).Int32;
        gColor[i + 768] = Color3F.Mix(c3, c4, f).Int32;
      }

      var gradient = new Bitmap(1024, gradientBox1.Height, PixelFormat.Format32bppRgb);
      int width = gradient.Width;
      int height = gradient.Height;
      var gradientPix = new int[width * height];

      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          gradientPix[x + y * width] = gColor[x];
        }
      }

      var bdata = gradient.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
      Marshal.Copy(gradientPix, 0, bdata.Scan0, gradientPix.Length);
      gradient.UnlockBits(bdata);
      gradientBox1.Image = gradient;
    }
  }
}
