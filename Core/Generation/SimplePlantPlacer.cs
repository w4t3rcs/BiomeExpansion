using System.Linq;
using Terraria.ObjectData;

namespace BiomeExpansion.Core.Generation;

public class SimplePlantPlacer : ISurfaceDecorationPlacer
{
    public void PlaceSurfaceDecoration(BEBiome biome, ushort rarity, ushort tile, sbyte frameCount = 0)
    {
        var (leftX, rightX) = GenerationHelper.BEBiomesXCoordinates[biome];
        var (startY, endY) = GenerationHelper.BEBiomesYCoordinates[biome];
        for (int x = leftX; x < rightX; x++)
        {
            for (int y = startY; y < endY + 12; y++)
            {
                if (PlantHelper.CheckTopPositionToPlace(rarity, GenerationTileData.ValidTiles[tile], x, y, GenerationTileData.Widths[tile], GenerationTileData.Heights[tile]))
                    PlacePlant(tile, x, y - 1, GenerationTileData.Widths[tile], GenerationTileData.Heights[tile], frameCount);
            }
        }
    }

    private static void PlacePlant(ushort plantTile, int x, int y, int width, int height, sbyte frameCount)
    {
        WorldGen.PlaceTile(x, y, plantTile);
        if (frameCount == 0) return;
        if (width != 1) FrameHelper.SetRandomHorizontalFrame(x, y, height, frameCount);
        else FrameHelper.SetRandomHorizontalFrame(x, y, height, frameCount);
    }
}