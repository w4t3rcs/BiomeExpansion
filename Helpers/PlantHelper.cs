using System.Linq;
using BiomeExpansion.Common.Dtos;
using Terraria;

namespace BiomeExpansion.Helpers;

public static class PlantHelper
{
    public static void GeneratePlant(BEBiome biome, sbyte rarity, ushort plantTile, ushort[] soilBlocks, int frameCount = 0)
    {
        var (leftX, rightX) = BiomeHelper.BEBiomesXCoordinates[biome];
        for (int x = leftX; x < rightX; x++)
        {
            for (int y = BiomeHelper.StartY; y < Main.maxTilesY; y++)
            {
                if (CheckNeededPositionToPlace(rarity, soilBlocks, x, y)) PlacePlant(plantTile, x, y - 1, frameCount);
            }
        }
    }

    private static void PlacePlant(ushort plantTile, int x, int y, int frameCount)
    {
        WorldGen.PlaceTile(x, y, plantTile);
        FrameHelper.SetRandomFrame(x, y, frameCount, 16, 2);
    }

    private static bool CheckNeededPositionToPlace(sbyte rarity, ushort[] soilBlocks, int x, int y)
    {
        return soilBlocks.Contains(Main.tile[x, y].TileType) && !Main.tile[x, y].IsHalfBlock && !Main.tile[x, y - 1].HasTile && WorldGen.genRand.NextBool(rarity);
    }
   
}