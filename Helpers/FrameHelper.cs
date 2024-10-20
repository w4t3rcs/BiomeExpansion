using Terraria;

namespace BiomeExpansion.Helpers;

public static class FrameHelper
{
    public const int FrameSize = 16;
    public const int FramePadding = 16;
    
    public static void SetRandomFrame(int x, int y, int frameCount)
    {
        SetFrameX(x, y, WorldGen.genRand.Next(0, frameCount));
    }
    
    public static void SetFrameX(int x, int y, int frameNumber)
    {
        Tile tile = Main.tile[x, y];
        tile.TileFrameX =(short)(frameNumber * (FrameSize + FramePadding));
    }

    public static void SetFramingSeaOats(int x, int y)
    {
        int randomFrame = WorldGen.genRand.Next(1, 15);
        SetFrameX(x, y, randomFrame);
        if (randomFrame > 4) SetFrameX(x, y - 1, randomFrame);
    }
    
    public static void SetFramingVine(int x, int y)
    {
        Tile vineTile = Main.tile[x, y];
        Tile topTile = Main.tile[x, y - 1];
        Tile bottomTile = Main.tile[x, y + 1];
        if (topTile.HasTile && topTile.TileType == vineTile.TileType && bottomTile.HasTile && bottomTile.TileType == vineTile.TileType)
        {
            WorldGen.SquareTileFrame(x, y);
            NetMessage.SendTileSquare(-1, x, y, -1);
        }
    }
}