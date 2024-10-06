using Terraria;

namespace BiomeExpansion.Helpers;

public static class FrameHelper
{
    public static void SetRandomFrame(int x, int y, int frameCount, int frameSize, int padding)
    {
        SetFrame(x, y, WorldGen.genRand.Next(0, frameCount), frameSize, padding);
    }
    
    public static void SetFrame(int x, int y, int frameNumber, int frameSize, int padding)
    {
        Tile tile = Main.tile[x, y];
        tile.TileFrameX =(short)(frameNumber * (frameSize + padding));
    }
}