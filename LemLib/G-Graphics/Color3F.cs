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

    /// <summary>
    /// Konstruktor
    /// </summary>
    /// <param name="r">roter Farbwert (0.0 - 1.0)</param>
    /// <param name="g">grüner Farbwert (0.0 - 1.0)</param>
    /// <param name="b">blauer Farbwert (0.0 - 1.0)</param>
    public Color3F(float r, float g, float b)
    {
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

    /// <summary>
    /// gibt den Farbwert als Int32 zurück oder setzt diesen
    /// </summary>
    public int Int32
    {
      get
      {
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
    /// gibt den Inhalt als lesbare Zeichenfolge zurück
    /// </summary>
    /// <returns>lesbare Zeichenfolge</returns>
    public override string ToString()
    {
      return string.Format("r: {0:N2}, g: {1:N2}, b: {2:N2}, c: 0x{3:X6}", r, g, b, Int32 & 0xffffff);
    }
  }
}
