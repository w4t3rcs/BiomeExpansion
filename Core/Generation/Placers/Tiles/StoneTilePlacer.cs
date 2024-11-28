using System.Linq;

namespace BiomeExpansion.Core.Generation.Placers.Tiles;

public class StoneTilePlacer : ITilePlacer
{
    public static readonly int[] StoneTileReplacements = [TileID.Stone, TileID.Ebonstone, TileID.Crimstone];

    public void PlaceTile(int x, int y, ushort tileType, ushort[] additionalTileTypes = null)
    {
        var tile = Main.tile[x, y];
        if (StoneTileReplacements.Contains(tile.TileType))
            WorldGen.ReplaceTile(x, y, tileType, tile.TileFrameX);
    }
}