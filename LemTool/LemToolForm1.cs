using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LemLib;

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
      var gColor = new int[1024];
      for (int i = 0; i < 256; i++)
      {
        float fInc = i / 256f;
        float fDec = (255 - i) / 256f;

        gColor[i] = new Color3F(0, 0, fInc).Int32;
        gColor[i + 256] = new Color3F(0, fInc, fDec).Int32;
        gColor[i + 512] = new Color3F(fInc, fDec, 0).Int32;
        gColor[i + 768] = new Color3F(1, fInc, fInc).Int32;
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
