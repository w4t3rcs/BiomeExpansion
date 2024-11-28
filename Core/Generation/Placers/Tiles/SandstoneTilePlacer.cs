using System.Linq;

namespace BiomeExpansion.Core.Generation.Placers.Tiles;

public class SandstoneTilePlacer : ITilePlacer
{
    public static readonly int[] SandstoneTileReplacements = [TileID.CorruptSandstone, TileID.CrimsonSandstone, TileID.Sandstone, TileID.HardenedSand, TileID.CorruptHardenedSand, TileID.CrimsonHardenedSand];

    public void PlaceTile(int x, int y, ushort tileType, ushort[] additionalTileTypes = null)
    {
        var tile = Main.tile[x, y];
        if (SandstoneTileReplacements.Contains(tile.TileType))
            WorldGen.ReplaceTile(x, y, tileType, tile.TileFrameX);
    }
}