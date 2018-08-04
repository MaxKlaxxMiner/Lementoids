#region # using *.*
using System.Diagnostics;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable UnusedMember.Global
#endregion

namespace LemLib
{
  /// <summary>
  /// Struktur mit drei Float-Farbwerten (rot, grün, blau)
  /// </summary>
  public struct Color3F
  {
    /// <summary>
    /// roter Farbwert (0.0 - 1.0)
    /// </summary>
    public float r;
    /// <summary>
    /// grüner Farbwert (0.0 - 1.0)
    /// </summary>
    public float g;
    /// <summary>
    /// blauer Farbwert (0.0 - 1.0)
    /// </summary>
    public float b;

    #region # // --- Konstruktor ---
    /// <summary>
    /// Konstruktor
    /// </summary>
    /// <param name="r">roter Farbwert (0.0 - 1.0)</param>
    /// <param name="g">grüner Farbwert (0.0 - 1.0)</param>
    /// <param name="b">blauer Farbwert (0.0 - 1.0)</param>
    public Color3F(float r, float g, float b)
    {
      Debug.Assert(r >= -.001f && r <= 1.001f);
      Debug.Assert(g >= -.001f && g <= 1.001f);
      Debug.Assert(b >= -.001f && b <= 1.001f);

      this.r = r;
      this.g = g;
      this.b = b;
    }

    /// <summary>
    /// Konstruktor
    /// </summary>
    /// <param name="color">Farbwert, welcher verwendet werden soll</param>
    public Color3F(int color)
    {
      r = ((color >> 16) & 0xff) * (1f / 255); // rot
      g = ((color >> 8) & 0xff) * (1f / 255);  // grün
      b = (color & 0xff) * (1f / 255);         // blau
      // alpha (wird ignoriert)
    }
    #endregion

    /// <summary>
    /// minimal erlaubter Wert (im Bereich 0.0 - 1.0)
    /// </summary>
    const float MinVal = -0.0001f;
    /// <summary>
    /// maximal erlaubter Wert (im Bereich 0.0 - 1.0)
    /// </summary>
    const float MaxVal = 1.0001f;

    /// <summary>
    /// gibt den Farbwert als Int32 zurück oder setzt diesen
    /// </summary>
    public int Int32
    {
      get
      {
        Debug.Assert(r >= MinVal && r <= MaxVal);
        Debug.Assert(g >= MinVal && g <= MaxVal);
        Debug.Assert(b >= MinVal && b <= MaxVal);

        return (int)(r * 255f + .5f) * 65536 // rot
             + (int)(g * 255f + .5f) * 256   // grün
             + (int)(b * 255f + .5f)         // blau
             - 16777216;                     // alpha
      }
      set
      {
        this = new Color3F(value);
      }
    }

    /// <summary>
    /// mischt zwei Farbwerte und gibt das entsprechende Ergebnis zurück
    /// </summary>
    /// <param name="first">erster Farbwert</param>
    /// <param name="second">zweiter Farbwert</param>
    /// <param name="value">Anteil, wie die beiden Farben gemischt werden sollen (0.0 = nur erste Farbe, 1.0 = nur zweite Farbe, 0.5 = 50% beider Farben)</param>
    /// <returns>neu berechneter Farbwert</returns>
    public static Color3F Mix(Color3F first, Color3F second, float value)
    {
      Debug.Assert(value >= MinVal && value <= MaxVal);

      float valueR = 1f - value;

      return new Color3F(first.r * valueR + second.r * value,
                         first.g * valueR + second.g * value,
                         first.b * valueR + second.b * value);
    }

    /// <summary>
    /// gibt den Inhalt als lesbare Zeichenfolge zurück
    /// </summary>
    /// <returns>lesbare Zeichenfolge</returns>
    public override string ToString()
    {
      return string.Format("r: {0:N2}, g: {1:N2}, b: {2:N2}, c: 0x{3:X6}", r, g, b, Int32 & 0xffffff);
    }
  }
}
