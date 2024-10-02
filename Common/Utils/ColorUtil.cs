using Microsoft.Xna.Framework;

namespace BiomeExpansion.Common.Utils;

public static class ColorUtil
{
    public static void SetRGBFromColor(out float r, out float g, out float b, Color color)
    {
        r = color.R;
        g = color.G;
        b = color.B;
    }
}