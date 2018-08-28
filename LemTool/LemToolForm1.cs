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

    bool multiColor = true;

    void UpdatePic()
    {
      pictureBox1.Image = TestTools.GradientTest(pictureBox1.Width, pictureBox1.Height, multiColor);
    }

    private void LemToolForm1_Shown(object sender, EventArgs e)
    {
      UpdatePic();
    }

    private void LemToolForm1_Resize(object sender, EventArgs e)
    {
      UpdatePic();
    }

    private void LemToolForm1_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == ' ')
      {
        multiColor = !multiColor;
        UpdatePic();
      }
    }
  }
}
