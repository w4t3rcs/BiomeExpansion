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
                if (WorldGen.genRand.NextBool(rarity)) 
                    WorldGen.OreRunner(x, y, strength, steps, ore);
            }
        }
    }
}