using Microsoft.Xna.Framework;

namespace BiomeExpansion.Helpers;

public static class ColorHelper
{
    public static void SetRGBFromColor(out float r, out float g, out float b, Color color)
    {
        r = color.R;
        g = color.G;
        b = color.B;
    }
}