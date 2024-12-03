using System.Collections.Generic;
using Terraria.ObjectData;

namespace BiomeExpansion.Core.Generation;

public static class GenerationTileData
{
    public static Dictionary<ushort, int> Widths { get; private set; } = [];
    public static Dictionary<ushort, int> Heights { get; private set; } = [];
    public static Dictionary<ushort, int[]> ValidTiles { get; private set; } = [];

    public static void AddGenerationTileData(this ModTile tile, TileObjectData tileData)
    {
        Widths.Add(tile.Type, tileData.Width);
        Heights.Add(tile.Type, tileData.Height);
        ValidTiles.Add(tile.Type, tileData.AnchorValidTiles);
    }
}