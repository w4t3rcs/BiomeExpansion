using System.Linq;
using BiomeExpansion.Common.Generation;
using Terraria;

namespace BiomeExpansion.Helpers;

public static class PlantHelper
{
    public static void GeneratePlant(BEBiome biome, sbyte rarity, ushort plantTile, ushort[] soilTiles, 
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
                    PlaceVine(plantTile, x, y, rarity, soilTiles);
                else if (isBunch)
                    PlaceBunch(plantTile, x, y - 1, frameCount, rarity, soilTiles);
                else if (isUnderwater)
                    PlaceUnderwaterPlant(plantTile, x, y);
                else if (isLilyPad)
                    PlaceLilyPad(plantTile, x, y);
                else
                    PlacePlant(plantTile, x, y - 1, width, height, frameCount, rarity, soilTiles);
            }
        }
    }
    
    private static bool CheckBottomPositionToPlace(sbyte rarity, ushort[] soilTiles, int x, int y, int range)
    {
        if (soilTiles.Contains(Main.tile[x, y].TileType) && !Main.tile[x, y].TopSlope && WorldGen.genRand.NextBool(rarity))
        {
            for (int i = y + 1; i < y + range; i++)
            {
                if (Main.tile[x, i].HasTile) return false;
            }
            
            return true;
        }
        
        return false;
    }
    
    private static void PlaceVine(ushort plantTile, int x, int y, sbyte rarity, ushort[] soilTiles)
    {
        int range = WorldGen.genRand.Next(2, 12);
        if (!CheckBottomPositionToPlace(rarity, soilTiles, x, y, range)) return;
        for (int i = y; i < y + range; i++)
        {
            WorldGen.PlaceTile(x, i, plantTile);
        }

        for (int i = y; i < y + range; i++)
        {
            FrameHelper.SetFramingVine(x, i);   
        }
    }
    
    private static bool CheckTopPositionToPlace(sbyte rarity, ushort[] soilTiles, int x, int y, int width = 1, int height = 1)
    {
        if (!soilTiles.Contains(Main.tile[x, y].TileType) || Main.tile[x, y].BottomSlope || !WorldGen.genRand.NextBool(rarity)) return false;
        for (int i = 1; i <= height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (Main.tile[x + j, y - i].HasTile) return false;
            }
        }
        
        return true;
    } 
    
    private static void PlaceBunch(ushort plantTile, int x, int y, sbyte frameCount, sbyte rarity, ushort[] soilTiles)
    {
        if (!CheckTopPositionToPlace(rarity, soilTiles, x + 1, y)) return;
        int horizontalRange = WorldGen.genRand.Next(4, 8);
        int verticalRange = WorldGen.genRand.Next(3, 5);
        for (int i = 0; i < verticalRange; i++)
        {
            for (int j = 0; j < horizontalRange; j++)
            {
                if (!Main.tile[x + j/2, y + i/2].HasTile)
                {
                    WorldGen.PlaceTile(x + j/2, y + i/2, plantTile);
                    FrameHelper.SetRandomFrame(x + j/2, y + i/2, frameCount);
                }
                else if (!Main.tile[x - j/2, y - i/2].HasTile)
                {
                    WorldGen.PlaceTile(x - j/2, y - i/2, plantTile);
                    FrameHelper.SetRandomFrame(x - j/2, y - i/2, frameCount);
                    
                }
            }
        }
    }
    
    private static void PlaceUnderwaterPlant(ushort plantTile, int x, int y)
    {
        WorldGen.PlaceUnderwaterPlant(plantTile, x, y);
    }
    
    private static void PlaceLilyPad(ushort plantTile, int x, int y)
    {
        if (WorldGen.PlaceLilyPad(x, y)) 
            WorldGen.ReplaceTile(x, y, plantTile, Main.tile[x, y].TileFrameX);
    }
    
    private static void PlacePlant(ushort plantTile, int x, int y, int width, int height, sbyte frameCount, sbyte rarity, ushort[] soilTiles)
    {
        if (!CheckTopPositionToPlace(rarity, soilTiles, x, y + 1, width, height)) return;
        WorldGen.PlaceTile(x, y, plantTile);
        FrameHelper.SetRandomFrame(x, y, frameCount);
    }
}