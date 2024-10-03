using System.Linq;
using BiomeExpansion.Common.Dtos;
using Terraria;

namespace BiomeExpansion.Common.Utils;

public static class PlantUtil
{
    public static void GeneratePlant(BEBiome biome, sbyte rarity, ushort plantTile, ushort[] soilBlocks)
    {
        var (leftX, rightX) = BiomeUtil.BEBiomesXCoordinates[biome];
        for (int x = leftX; x < rightX; x++)
        {
            for (int y = BiomeUtil.StartY; y < Main.maxTilesY; y++)
            {
                if (CheckNeededPositionToPlace(rarity, soilBlocks, x, y)) WorldGen.PlaceTile(x, y - 1, plantTile);
            }
        }
    }

    private static bool CheckNeededPositionToPlace(sbyte rarity, ushort[] soilBlocks, int x, int y)
    {
        return soilBlocks.Contains(Main.tile[x, y].TileType) && !Main.tile[x, y].IsHalfBlock && !Main.tile[x, y - 1].HasTile && WorldGen.genRand.Next(0, 100) > rarity;
    }
}