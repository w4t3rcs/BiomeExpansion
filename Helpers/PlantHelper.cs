using System.Linq;
using BiomeExpansion.Common.Generation;
using Terraria;

namespace BiomeExpansion.Helpers;

public static class PlantHelper
{
    public static void GeneratePlant(BEBiome biome, sbyte rarity, ushort plantTile, ushort[] soilBlocks, sbyte frameCount = 0, bool isVine = false)
    {
        var (leftX, rightX) = GenerationHelper.BEBiomesXCoordinates[biome];
        for (int x = leftX; x < rightX; x++)
        {
            for (int y = GenerationHelper.SurfaceY; y < Main.maxTilesY; y++)
            {
                if (isVine)
                {
                    int randomRange = WorldGen.genRand.Next(2, 12);
                    if (CheckBottomPositionToPlace(rarity, soilBlocks, x, y, randomRange)) PlaceVine(plantTile, x, y, randomRange);
                }
                else
                {
                    if (CheckTopPositionToPlace(rarity, soilBlocks, x, y)) PlacePlant(plantTile, x, y - 1, frameCount);
                }
            }
        }
    }
    
    private static bool CheckBottomPositionToPlace(sbyte rarity, ushort[] soilBlocks, int x, int y, int range)
    {
        if (soilBlocks.Contains(Main.tile[x, y].TileType) && !Main.tile[x, y].IsHalfBlock && WorldGen.genRand.NextBool(rarity))
        {
            for (int i = y + 1; i < y + range; i++)
            {
                if (Main.tile[x, i].HasTile) return false;
            }
            
            return true;
        }
        
        return false;
    }
    
    private static void PlaceVine(ushort plantTile, int x, int y, int range)
    {
        for (int i = y; i < y + range; i++)
        {
            WorldGen.PlaceTile(x, i, plantTile);
        }

        for (int i = y; i < y + range; i++)
        {
            FrameHelper.SetFramingVine(x, i);   
        }
    }

    private static bool CheckTopPositionToPlace(sbyte rarity, ushort[] soilBlocks, int x, int y)
    {
        return soilBlocks.Contains(Main.tile[x, y].TileType) && !Main.tile[x, y].IsHalfBlock && !Main.tile[x, y - 1].HasTile && WorldGen.genRand.NextBool(rarity);
    }
    
    private static void PlacePlant(ushort plantTile, int x, int y, sbyte frameCount)
    {
        WorldGen.PlaceTile(x, y, plantTile);
        FrameHelper.SetRandomFrame(x, y, frameCount, 16, 2);
    }
}