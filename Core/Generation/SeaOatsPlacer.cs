using Terraria.ObjectData;

namespace BiomeExpansion.Core.Generation;

public class SeaOatsPlacer : ISurfaceDecorationPlacer
{
    public void PlaceSurfaceDecoration(BEBiome biome, ushort rarity, ushort tile, sbyte frameCount = 0)
    {
        var (leftX, rightX) = GenerationHelper.BEBiomesXCoordinates[biome];
        var (startY, endY) = GenerationHelper.BEBiomesYCoordinates[biome];
        for (int x = leftX; x < rightX; x++)
        {
            for (int y = startY; y < endY + 12; y++)
            {
                PlaceSeaOats(tile, x, y, rarity, GenerationTileData.ValidTiles[tile]);
            }
        }
    }

    private static void PlaceSeaOats(ushort plantTile, int x, int y, ushort rarity, int[] soilTiles)
    {
        if (!PlantHelper.CheckTopPositionToPlace(rarity, soilTiles, x, y + 1)) return;
        int horizontalRange = WorldGen.genRand.Next(6, 16);
        for (int i = 0; i <= horizontalRange; i++)
        {
            if (!PlantHelper.CheckTopPositionToPlace(1, soilTiles, x + i, y + 1)) return;
            WorldGen.PlaceTile(x + i, y, plantTile);
            FrameHelper.SetFramingSeaOats(x + i, y);
        }
    }
}