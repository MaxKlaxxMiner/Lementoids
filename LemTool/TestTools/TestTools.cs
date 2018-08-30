using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using LemLib;

namespace LemTool
{
  public static partial class TestTools
  {
    static int[] GradientMap(Dictionary<int, Color3F> colorsDict)
    {
      var colors = colorsDict.OrderBy(x => x.Key).ToArray();
      int min = colors.Min(x => x.Key);
      int max = colors.Max(x => x.Key);
      var output = new int[max - min + 1];

      var lastC = colors.First().Value;
      int lastP = colors.First().Key;
      foreach (var c in colors.Skip(1))
      {
        for (int p = lastP; p < c.Key; p++)
        {
          output[p - min] = Color3F.Mix(lastC, c.Value, 1f / (c.Key - lastP) * (p - lastP)).Int32;
        }
        lastP = c.Key;
        lastC = c.Value;
      }
      output[output.Length - 1] = colors.Last().Value.Int32;
      return output;
    }

    public static Bitmap GradientTest(int width, int height, int gradientType, int resolution)
    {
      int resValue = 1 << resolution;
      int resMask = resValue - 1;

      var colors = new Dictionary<int, Color3F>
      {
        { 0, new Color3F(0, 0, 0) },                    // black
        { resValue / 4 * 1 - 1, new Color3F(0, 0, 1) }, // blue
        { resValue / 4 * 2 - 1, new Color3F(0, 1, 0) }, // gree
        { resValue / 4 * 3 - 1, new Color3F(1, 0, 0) }, // red
        { resValue / 4 * 4 - 1, new Color3F(1, 1, 1) }  // white
      };

      var gradientMap = GradientMap(colors);

      var gradientTest = new Bitmap(width, height, PixelFormat.Format32bppRgb);
      var gradientPix = new int[width * height];

      switch (gradientType)
      {
        #region # case 0: // --- simple Linear ---
        case 0:
        {
          for (int x = 0; x < width; x++)
          {
            int pos = (x << resolution) / width;
            var gColor = gradientMap[pos];
            for (int y = 0; y < height; y++)
            {
              gradientPix[x + y * width] = gColor;
            }
          }
        } break;
        #endregion
        #region # case 1: // --- 2D Linear ---
        case 1:
        {
          var black = new Color3F(0x000000); // top color
          var white = new Color3F(0xffffff); // bottom color
          for (int x = 0; x < width; x++)
          {
            int pos = (x << resolution) / width;
            var gColor = new Color3F(gradientMap[pos]);
            for (int y = 0; y < height / 2; y++)
            {
              gradientPix[x + y * width] = Color3F.Mix(black, gColor, y / (height / 2f)).Int32;
            }
            for (int y = height / 2; y < height; y++)
            {
              gradientPix[x + y * width] = Color3F.Mix(gColor, white, (y - height / 2) / (height / 2f)).Int32;
            }
          }
        } break;
        #endregion
        case 2:
        {
          int max = (int)(width / 2f * (width - width / 2f) / resValue + height / 2f * (height - height / 2f) / resValue + 1f);
          for (int y = 0; y < height; y++)
          {
            for (int x = 0; x < width; x++)
            {
              gradientPix[x + y * width] = gradientMap[(uint)(x * (width - x) + y * (height - y)) / max & resMask];
            }
          }
        } break;
        default: throw new Exception("unknown gradientType: " + gradientType);
      }

      var bdata = gradientTest.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
      Marshal.Copy(gradientPix, 0, bdata.Scan0, gradientPix.Length);
      gradientTest.UnlockBits(bdata);

      return gradientTest;
    }
  }
}
