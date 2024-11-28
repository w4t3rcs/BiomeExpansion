using System.Linq;

namespace BiomeExpansion.Core.Generation.Placers.Tiles;

public class SandTilePlacer : ITilePlacer
{
    public static readonly int[] SandTileReplacements = [TileID.Sand, TileID.Ebonsand, TileID.Crimsand];

    public void PlaceTile(int x, int y, ushort tileType, ushort[] additionalTileTypes = null)
    {
        var tile = Main.tile[x, y];
        if (SandTileReplacements.Contains(tile.TileType) || Main.tileSand[tile.TileType])
            WorldGen.ReplaceTile(x, y, tileType, tile.TileFrameX);
    }
}