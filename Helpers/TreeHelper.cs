using System.Linq;
using BiomeExpansion.Common.Dtos;
using Terraria;

namespace BiomeExpansion.Helpers;

public static class TreeHelper
{
    public static void GenerateTree(BEBiome biome, sbyte rarity, ushort treeSapling, ushort[] soilBlocks, int height)
    {
        var (leftX, rightX) = BiomeHelper.BEBiomesXCoordinates[biome];
        for (int x = leftX; x < rightX; x++)
        {
            for (int y = BiomeHelper.StartY; y < Main.maxTilesY; y++)
            {
                if (CheckNeededPositionToPlace(rarity, soilBlocks, x, y, height)) PlaceTree(treeSapling, x, y - 1);
            }
        }
    }
    
    private static void PlaceTree(ushort treeSapling, int x, int y)
    {
        WorldGen.PlaceObject(x, y, treeSapling, true, 0, -1);
    }
     
    private static bool CheckNeededPositionToPlace(sbyte rarity, ushort[] soilBlocks, int x, int y, int height)
    {
        if (soilBlocks.Contains(Main.tile[x, y].TileType) && !Main.tile[x, y].IsHalfBlock && !Main.tile[x - 1, y].HasTile && !Main.tile[x + 1, y].HasTile)
        {
            for (int i = y - 1; i > y - height; i--) if (Main.tile[x, i].HasTile) return false;
            return WorldGen.genRand.NextBool(rarity);
        }
        
        return false;
    }
}