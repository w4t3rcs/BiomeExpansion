using System.Linq;
using BiomeExpansion.Common.Generation;
using Terraria;

namespace BiomeExpansion.Helpers;

public static class PlantHelper
{
    public static void GeneratePlant(BEBiome biome, sbyte rarity, ushort plantTile, ushort[] soilBlocks, 
        sbyte frameCount = 0, sbyte width = 1, sbyte height = 1, 
        bool isVine = false, bool isBunch = false, bool isUnderwater = false, bool isLilyPad = false)
    {
        var (leftX, rightX) = GenerationHelper.BEBiomesXCoordinates[biome];
        var (startY, endY) = GenerationHelper.BEBiomesYCoordinates[biome];
        for (int x = leftX; x < rightX; x++)
        {
            for (int y = startY; y < endY + 12; y++)
            {
                if (isVine)
                {
                    int randomRange = WorldGen.genRand.Next(2, 12);
                    if (CheckBottomPositionToPlace(rarity, soilBlocks, x, y, randomRange)) PlaceVine(plantTile, x, y, randomRange);
                }
                else if (isBunch)
                {
                    int horizontalRange = WorldGen.genRand.Next(4, 8);
                    int verticalRange = WorldGen.genRand.Next(3, 5);
                    if (CheckTopPositionToPlace(rarity, soilBlocks, x, y)) PlaceBunch(plantTile, x, y - 1, frameCount, horizontalRange, verticalRange);
                }
                else if (isUnderwater)
                {
                    
                }
                else if (isLilyPad)
                {
                    
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
        if (soilBlocks.Contains(Main.tile[x, y].TileType) && !Main.tile[x, y].TopSlope && WorldGen.genRand.NextBool(rarity))
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
        return soilBlocks.Contains(Main.tile[x, y].TileType) && !Main.tile[x, y].BottomSlope && !Main.tile[x, y - 1].HasTile && WorldGen.genRand.NextBool(rarity);
    } 
    
    private static void PlaceBunch(ushort plantTile, int x, int y, sbyte frameCount, int horizontalRange, int verticalRange)
    {
        for (int i = 0; i < verticalRange; i++)
        {
            for (int j = 0; j < horizontalRange; j++)
            {
                if (!Main.tile[x + j/2, y + i/2].HasTile)
                {
                    PlacePlant(plantTile, x + j/2, y + i/2, frameCount);
                }
                else if (!Main.tile[x - j/2, y - i/2].HasTile)
                {
                    PlacePlant(plantTile, x - j/2, y - i/2, frameCount);
                }
            }
        }
    }
    
    private static void PlacePlant(ushort plantTile, int x, int y, sbyte frameCount)
    {
        WorldGen.PlaceTile(x, y, plantTile);
        FrameHelper.SetRandomFrame(x, y, frameCount);
    }
}