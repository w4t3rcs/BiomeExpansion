using Humanizer;

namespace BiomeExpansion.Core.Generation.Placers.Tiles;

public class MainTilePlacer : ITilePlacer
{
    public void PlaceTile(int x, int y, ushort tileType, ushort[] additionalTileTypes = null)
    {
        var tile = Main.tile[x, y];
        WorldGen.ReplaceTile(x, y, tileType, tile.TileFrameX);
    }
}