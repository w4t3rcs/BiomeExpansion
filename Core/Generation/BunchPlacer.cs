using Terraria.ObjectData;

namespace BiomeExpansion.Core.Generation;

public class BunchPlacer : ISurfaceDecorationPlacer
{
    public void PlaceSurfaceDecoration(BEBiome biome, ushort rarity, ushort tile, sbyte frameCount = 0)
    {
        var (leftX, rightX) = GenerationHelper.BEBiomesXCoordinates[biome];
        var (startY, endY) = GenerationHelper.BEBiomesYCoordinates[biome];
        for (int x = leftX; x < rightX; x++)
        {
            for (int y = startY; y < endY + 12; y++)
            {
                if (PlantHelper.CheckTopPositionToPlace(rarity, GenerationTileData.ValidTiles[tile], x, y))
                    PlaceBunch(tile, x, y - 1, frameCount);
            }
        }
    }

    private static void PlaceBunch(ushort plantTile, int x, int y, sbyte frameCount)
    {
        int horizontalRange = WorldGen.genRand.Next(4, 12);
        int verticalRange = WorldGen.genRand.Next(2, 6);
        for (int i = 0; i < verticalRange; i++)
        {
            for (int j = 0; j < horizontalRange; j++)
            {
                if (!Main.tile[x + j/2, y + i/2].HasTile)
                {
                    WorldGen.PlaceTile(x + j/2, y + i/2, plantTile);
                    FrameHelper.SetRandomHorizontalFrame(x + j/2, y + i/2, 1, frameCount);
                }
                else if (!Main.tile[x - j/2, y - i/2].HasTile)
                {
                    WorldGen.PlaceTile(x - j/2, y - i/2, plantTile);
                    FrameHelper.SetRandomHorizontalFrame(x - j/2, y - i/2, 1, frameCount);
                }
            }
        }
    }
}