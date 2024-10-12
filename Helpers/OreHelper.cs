using BiomeExpansion.Common.Generation;
using Terraria;

namespace BiomeExpansion.Helpers;

public static class OreHelper
{
    public static void GenerateOre(BEBiome biome, sbyte rarity, float strength, int steps, ushort ore)
    {
        var (leftX, rightX) = GenerationHelper.BEBiomesXCoordinates[biome];
        var (startY, endY) = GenerationHelper.BEBiomesYCoordinates[biome];
        for (int x = leftX; x < rightX; x++)
        {
            for (int y = startY; y < endY; y++)
            {
                if (CheckPositionToPlace(rarity, x, y)) 
                    PlaceOre(x, y, strength, steps, ore);
            }
        }
    }

    public static void PlaceOre(int x, int y, float strength, int steps, ushort ore)
    {
        WorldGen.OreRunner(x, y, strength, steps, ore);
    }
    
    private static bool CheckPositionToPlace(sbyte rarity, int x, int y)
    {
        return WorldGen.genRand.NextBool(rarity) && Main.tile[x, y].HasTile;
    }
}