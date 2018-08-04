using System.Diagnostics;

namespace LemLib
{
  /// <summary>
  /// Klasse mit Grafik-Methoden
  /// </summary>
  public static class G
  {
    /// <summary>
    /// Methode zum Berechnen des Farbcodes
    /// </summary>
    /// <param name="r">rote Farbe (0.0 - 1.0)</param>
    /// <param name="g">grüne Farbe (0.0 - 1.0)</param>
    /// <param name="b">blaue Farbe (0.0 - 1.0)</param>
    /// <returns>gibt den kodierten Farbwert zurück</returns>
    public static int GetColor(float r, float g, float b)
    {
      Debug.Assert(r >= 0f && r <= 1f);
      Debug.Assert(g >= 0f && g <= 1f);
      Debug.Assert(b >= 0f && b <= 1f);

      return (int)(r * 255f + .5f) * 65536 // rot
           + (int)(g * 255f + .5f) * 256   // grün
           + (int)(b * 255f + .5f)         // blau
           - 16777216;                     // alpha
    }

  }
}
