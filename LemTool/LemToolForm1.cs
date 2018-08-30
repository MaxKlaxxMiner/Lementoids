#region # using *.*
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
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

    int gradientType;
    int resolution = 6;

    void UpdatePic()
    {
      pictureBox1.Image = TestTools.GradientTest(pictureBox1.Width, pictureBox1.Height, gradientType, resolution);
      label1.Text = "[ Space ] - Gradient type: " + (gradientType == 0 ? "linear" : (gradientType == 1 ? "bilinear" : "radial"));
      label2.Text = "[ + / - ] - Resolution: " + (1 << resolution).ToString("N0");
      pictureBox1.Refresh();
      Refresh();
    }

    private void LemToolForm1_Shown(object sender, EventArgs e)
    {
      UpdatePic();
    }

    private void LemToolForm1_Resize(object sender, EventArgs e)
    {
      UpdatePic();
    }

    private void LemToolForm1_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Escape: Close(); break;

        case Keys.Space:
        {
          gradientType++;
          if (gradientType == 3) gradientType = 0;
          UpdatePic();
        } break;

        case Keys.Add:
        case Keys.Oemplus:
        {
          resolution++;
          if (resolution >= 13) resolution = 13;
          UpdatePic();
        } break;

        case Keys.Subtract:
        case Keys.OemMinus:
        {
          resolution--;
          if (resolution < 3) resolution = 3;
          UpdatePic();
        } break;
      }
    }
  }
}
