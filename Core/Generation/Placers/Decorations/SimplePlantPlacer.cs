using System.Linq;
using Terraria.ObjectData;

namespace BiomeExpansion.Core.Generation.Placers.Decorations;

public class SimplePlantPlacer : ISurfaceDecorationPlacer
{
    public void PlaceSurfaceDecoration(int x, int y, ushort rarity, ushort tile, sbyte frameCount = 0)
    {
        if (!PlantHelper.CheckTopPositionToPlace(rarity, GenerationTileData.ValidTiles[tile], x, y, GenerationTileData.Widths[tile], GenerationTileData.Heights[tile])) return;
        WorldGen.PlaceTile(x, y, tile);
        if (frameCount == 0) return;
        if (GenerationTileData.Widths[tile] != 1) FrameHelper.SetRandomHorizontalFrame(x, y, GenerationTileData.Widths[tile], GenerationTileData.Heights[tile], frameCount);
        else FrameHelper.SetRandomHorizontalFrame(x, y, GenerationTileData.Heights[tile], frameCount);
    }
}