using BiomeExpansion.Common.Dtos;
using Terraria;
using Terraria.ID;

namespace BiomeExpansion.Helpers;

public static class OreHelper
{
    public static void GenerateOre(BEBiome biome, int startY, int endY, sbyte rarity, float strength, int steps, ushort ore, ushort dirtReplace = 0)
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

        if (dirtReplace != 0)
            ClearDirt(rightX, leftX, startY, endY, dirtReplace);
    }

    private static void ClearDirt(int startX, int endX, int startY, int endY, ushort dirtReplace)
    {
        for (int x = startX; x < endX; x++)
        {
            for (int y = startY; y < endY; y++)
            {
                if (Main.tile[x, y].TileType == TileID.Dirt || Main.tile[x, y].TileType == TileID.Grass)
                {
                    WorldGen.PlaceTile(x, y, dirtReplace);
                }
            }
        }
    }
}