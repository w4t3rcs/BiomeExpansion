using System.Linq;
using BiomeExpansion.Common.Generation;
using Terraria;
using Terraria.ID;

namespace BiomeExpansion.Helpers;

public static class PlantHelper
{
    public static void GeneratePlant(BEBiome biome, ushort rarity, ushort plantTile, ushort[] soilTiles, 
        sbyte frameCount = 0, sbyte width = 1, sbyte height = 1, 
        bool isVine = false, bool isBunch = false, bool isSeaOats = false, bool isLilyPad = false)
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
                else if (isSeaOats)
                    PlaceSeaOats(plantTile, x, y - 1, rarity, soilTiles);
                else if (isLilyPad)
                    PlaceLilyPad(plantTile, x, y);
                else
                    PlacePlant(plantTile, x, y - 1, width, height, frameCount, rarity, soilTiles);
            }
        }
    }
    
    private static bool CheckBottomPositionToPlace(ushort rarity, ushort[] soilTiles, int x, int y, int range)
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
    
    private static void PlaceVine(ushort plantTile, int x, int y, ushort rarity, ushort[] soilTiles)
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
    
    private static void PlaceBunch(ushort plantTile, int x, int y, sbyte frameCount, ushort rarity, ushort[] soilTiles)
    {
        if (!CheckTopPositionToPlace(rarity, soilTiles, x, y + 1)) return;
        int horizontalRange = WorldGen.genRand.Next(4, 12);
        int verticalRange = WorldGen.genRand.Next(2, 6);
        for (int i = 0; i < verticalRange; i++)
        {
            for (int j = 0; j < horizontalRange; j++)
            {
                if (!Main.tile[x + j/2, y + i/2].HasTile)
                {
                    WorldGen.PlaceTile(x + j/2, y + i/2, plantTile);
                    FrameHelper.SetRandomFrame(x + j/2, y + i/2, 1, frameCount);
                }
                else if (!Main.tile[x - j/2, y - i/2].HasTile)
                {
                    WorldGen.PlaceTile(x - j/2, y - i/2, plantTile);
                    FrameHelper.SetRandomFrame(x - j/2, y - i/2, 1, frameCount);
                }
            }
        }
    }
    
    private static void PlaceSeaOats(ushort plantTile, int x, int y, ushort rarity, ushort[] soilTiles)
    {
        if (!CheckTopPositionToPlace(rarity, soilTiles, x, y + 1)) return;
        int horizontalRange = WorldGen.genRand.Next(6, 16);
        for (int i = 0; i <= horizontalRange; i++)
        {
            if (!CheckTopPositionToPlace(1, soilTiles, x + i, y + 1)) return;
            WorldGen.PlaceTile(x + i, y, plantTile);
            FrameHelper.SetFramingSeaOats(x + i, y);
        }
    }
    
    private static void PlaceLilyPad(ushort plantTile, int x, int y)
    {
        WorldGen.PlaceLilyPad(x, y);
        if (Main.tile[x, y].TileType == TileID.LilyPad)
        {
            WorldGen.ReplaceTile(x, y, plantTile, Main.tile[x, y].TileFrameX);
            FrameHelper.SetRandomFrame(x, y, 1, 18);
        }
    }
    
    private static void PlacePlant(ushort plantTile, int x, int y, int width, int height, sbyte frameCount, ushort rarity, ushort[] soilTiles)
    {
        if (!CheckTopPositionToPlace(rarity, soilTiles, x, y + 1, width, height)) return;
        WorldGen.PlaceTile(x, y, plantTile);
        if (frameCount == 0) return;
        if (width != 1) FrameHelper.SetRandomFrame(x, y, height, frameCount);
        else FrameHelper.SetRandomFrame(x, y, height, frameCount);
    }
    
    private static bool CheckTopPositionToPlace(ushort rarity, ushort[] soilTiles, int x, int y, int width = 1, int height = 1)
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
}