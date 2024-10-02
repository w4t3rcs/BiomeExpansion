using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace BiomeExpansion.Common.Utils;

public static class WorldUtil
{
    private const int MaximumBiomeTileDistance = 15;
    private static ushort[] ReplacedGrassTiles => [TileID.Grass, TileID.CorruptGrass, TileID.CrimsonGrass];
    private static ushort[] ReplacedDirtTiles => [TileID.Dirt, TileID.ClayBlock, TileID.Sand];
    private static ushort[] ReplacedStoneTiles => [TileID.Stone];
    
    public static void GenerateBiomeNextToEvilBiome(GenerationProgress progress, int biomeWidth, int biomeHeight, ushort dirtBlock, ushort grassBlock, ushort stoneBlock)
    {
        progress.Message = "Generating BiomeExpansion biomes...";
        GenerateBiomeNextToBiome(biomeWidth, biomeHeight, dirtBlock, grassBlock, stoneBlock, [
                TileID.CorruptGrass, TileID.CorruptSandstone, TileID.Ebonsand, TileID.Ebonstone,
                TileID.CrimsonGrass, TileID.CrimsonSandstone, TileID.Crimsand, TileID.Crimstone
        ]);
    }

    public static void GenerateBiomeNextToBiome(int biomeWidth, int biomeHeight, ushort dirtBlock, ushort grassBlock, ushort stoneBlock, ushort[] neighbourBiomeTiles)
    {
        int startY = Main.maxTilesY / 8, endY = (int)(Main.worldSurface - 10 + biomeHeight);
        KeyValuePair<int,int> evilBiomeXCoordinates = GetBiomeXCoordinates(startY, endY, neighbourBiomeTiles);
        if (evilBiomeXCoordinates.Value < Main.maxTilesX / 2) //True - правая сторона
        {
            if (!IsSpawnNear(evilBiomeXCoordinates.Value + biomeWidth / 2, biomeWidth))
            {
                GenerateBiomeOnTheRightSide(evilBiomeXCoordinates.Value, startY, endY, biomeWidth, dirtBlock, grassBlock, stoneBlock);
            }
            else
            {
                GenerateBiomeOnTheLeftSide(evilBiomeXCoordinates.Key, startY, endY, biomeWidth, dirtBlock, grassBlock,  stoneBlock);
            }
        }
        else
        {
            if (!IsSpawnNear(evilBiomeXCoordinates.Key - biomeWidth / 2, biomeWidth))
            {
                GenerateBiomeOnTheLeftSide(evilBiomeXCoordinates.Key, startY, endY, biomeWidth, dirtBlock, grassBlock, stoneBlock);
            }
            else
            {
                GenerateBiomeOnTheRightSide(evilBiomeXCoordinates.Value, startY, endY, biomeWidth,dirtBlock, grassBlock, stoneBlock);
            }
        }
    }

    private static bool IsSpawnNear(int x, int minimumDistance)
    {
        int spawnTileX = Main.spawnTileX;
        return (x + minimumDistance > spawnTileX && x < spawnTileX + minimumDistance)
               || (x - minimumDistance < spawnTileX && x > spawnTileX - minimumDistance);
    }
    
    private static void GenerateBiomeOnTheLeftSide(int startX, int startY, int endY, int biomeWidth, ushort dirtBlock, ushort grassBlock, ushort stoneBlock)
    {
        
        for (int i = startX - biomeWidth; i < startX; i++)
        {
            GenerateBiomeVertically(i, startY, endY, dirtBlock, grassBlock, stoneBlock);
        }
        
    }
    
    private static void GenerateBiomeOnTheRightSide(int startX, int startY, int endY, int biomeWidth, ushort dirtBlock, ushort grassBlock, ushort stoneBlock)
    {
        for (int i = startX; i < startX + biomeWidth; i++)
        {
            GenerateBiomeVertically(i, startY, endY, dirtBlock, grassBlock, stoneBlock);
        }
    }

    private static void GenerateBiomeVertically(int x, int startY, int endY, ushort dirtBlock, ushort grassBlock, ushort stoneBlock) 
    {
        for (int j = startY; j < endY; j++)
        {
            ReplaceBlocks(x, j, ReplacedGrassTiles, grassBlock);
            ReplaceBlocks(x, j, ReplacedDirtTiles, dirtBlock);
            ReplaceBlocks(x, j, ReplacedStoneTiles, stoneBlock);
        }
    }

    private static KeyValuePair<int, int> GetBiomeXCoordinates(int startY, int endY, ushort[] biomeTiles)
    {
        int leftX = GetBiomeLeftX(startY, endY, biomeTiles);
        int rightX = GetBiomeRightX(startY, endY, biomeTiles, leftX);
        return new KeyValuePair<int, int>(leftX, rightX);
    }
    
    private static int GetBiomeRightX(int startY, int endY, ushort[] biomeTiles, int leftX)
    {
        int distanceCounter = 0;
        int rightX = leftX + 1;
        for (int x = rightX; x < Main.maxTilesX; x++)
        {
            bool neededTileFound = false;
            for (int y = startY; y < endY; y++)
            {
                if (biomeTiles.Contains(Main.tile[x, y].TileType))
                {
                    rightX++; 
                    neededTileFound = true;
                    distanceCounter = 0;
                    break;
                }
            }
            
            if (!neededTileFound && distanceCounter < MaximumBiomeTileDistance)
            {
                rightX++;
                distanceCounter++;
            }
            else if (distanceCounter > MaximumBiomeTileDistance)
            {
                rightX -= MaximumBiomeTileDistance + 5;
                break;
            }
        }

        return rightX;
    }

    private static int GetBiomeLeftX(int startY, int endY, ushort[] biomeTiles)
    {
        int leftX = 0;
        for (int y = startY; y < endY; y++)
        {
            for (int x = 0; x < Main.maxTilesX; x++)
            {
                if (biomeTiles.Contains(Main.tile[x, y].TileType) && leftX == 0)
                {
                    leftX = x;
                    break;
                }
            }
        }

        return leftX;
    }

    private static void ReplaceBlocks(int x, int y, ushort[] replacedTiles, ushort tileType)
    {
        try
        {
            if (Main.tile[x, y].HasTile && replacedTiles.Contains(Main.tile[x, y].TileType))
            {
                Main.tile[x, y].TileType = tileType; 
            }
        }
        catch (Exception e)
        {
            ModContent.GetInstance<BiomeExpansion>().Logger.Error(e);        
        }
    }
}