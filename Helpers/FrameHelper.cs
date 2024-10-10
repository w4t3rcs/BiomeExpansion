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

    public static void SetFramingVine(int x, int y)
    {
        Tile vineTile = Main.tile[x, y];
        Tile topTile = Main.tile[x, y - 1];
        Tile bottomTile = Main.tile[x, y + 1];
        if (topTile.HasTile && topTile.TileType == vineTile.TileType && bottomTile.HasTile && bottomTile.TileType == vineTile.TileType) 
            WorldGen.SquareTileFrame(x, y);
    }
}