using BiomeExpansion.Common.Dtos;
using Terraria;

namespace BiomeExpansion.Helpers;

public static class OreHelper
{
    public static void GenerateOre(BEBiome biome, int startY, int endY, sbyte rarity, float strength, int steps, ushort ore)
    {
        var (leftX, rightX) = BiomeHelper.BEBiomesXCoordinates[biome];
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