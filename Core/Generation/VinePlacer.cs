using Terraria.ObjectData;

namespace BiomeExpansion.Core.Generation;

public class VinePlacer : ISurfaceDecorationPlacer
{
    public void PlaceSurfaceDecoration(BEBiome biome, ushort rarity, ushort tile, sbyte frameCount = 0)
    {
        var (leftX, rightX) = GenerationHelper.BEBiomesXCoordinates[biome];
        var (startY, endY) = GenerationHelper.BEBiomesYCoordinates[biome];
        for (int x = leftX; x < rightX; x++)
        {
            for (int y = startY; y < endY + 12; y++)
            {
                PlaceVine(tile, x, y, rarity, GenerationTileData.ValidTiles[tile]);
            }
        }
    }

    private static void PlaceVine(ushort plantTile, int x, int y, ushort rarity, int[] soilTiles)
    {
        int range = WorldGen.genRand.Next(2, 12);
        if (!PlantHelper.CheckBottomPositionToPlace(rarity, soilTiles, x, y, range)) return;
        for (int i = y; i < y + range; i++)
        {
            WorldGen.PlaceTile(x, i, plantTile);
        }

        for (int i = y; i < y + range; i++)
        {
            FrameHelper.SetFramingVine(x, i);   
        }
    }
}