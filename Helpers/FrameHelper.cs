using Terraria;

namespace BiomeExpansion.Helpers;

public static class FrameHelper
{
    public static void SetRandomFrame(int x, int y, int frameCount, int frameSize, int padding)
    {
        Tile tileSafely = Main.tile[x, y];
        tileSafely.TileFrameX = (short)(WorldGen.genRand.Next(0, frameCount) * (frameSize + padding));
    }
}