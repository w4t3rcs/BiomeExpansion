using System;
using System.Collections.Generic;
using System.Linq;
using BiomeExpansion.Common.Dtos;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Helpers;

public static class BiomeHelper
{
    public static Dictionary<BEBiome, KeyValuePair<int, int>> BEBiomesXCoordinates = new();
    public static readonly int StartY = Main.maxTilesY / 8;
    private static readonly ushort[] StoneTiles = [TileID.CorruptSandstone, TileID.Ebonstone, TileID.CrimsonSandstone, TileID.Crimstone, TileID.Stone];
    private const int MaximumBiomeTileDistance = 10;
    
    public static void GenerateBiomeNextToEvilBiome(BEBiome biome, int biomeWidth, int biomeHeight, ushort dirt, ushort grass, ushort stone, ushort wall)
    {
        GenerateBiomeNextToBiome(biome, biomeWidth, biomeHeight, dirt, grass, stone, wall, [
                TileID.CorruptGrass, TileID.CorruptSandstone, TileID.Ebonsand, TileID.Ebonstone,
                TileID.CrimsonGrass, TileID.CrimsonSandstone, TileID.Crimsand, TileID.Crimstone
        ]);
    }
    
    public static void GenerateBiomeNextToBiome(BEBiome biome, int biomeWidth, int biomeHeight, ushort dirt, ushort grass, ushort stone, ushort wall, ushort[] neighbourBiomeTiles)
    {
        int endY = (int)(Main.worldSurface - 10 + biomeHeight);
        KeyValuePair<int,int> evilBiomeXCoordinates = GetBiomeXCoordinates(StartY, endY, neighbourBiomeTiles);
        if (evilBiomeXCoordinates.Value < Main.maxTilesX / 2)
        {
            if (!IsSpawnNear(evilBiomeXCoordinates.Value + biomeWidth, biomeWidth))
            {
                GenerateBiomeOnTheRightSide(biome, evilBiomeXCoordinates.Value, StartY, endY, biomeWidth, dirt, grass, stone, wall);
            }
            else
            {
                GenerateBiomeOnTheLeftSide(biome, evilBiomeXCoordinates.Key, StartY, endY, biomeWidth, dirt, grass, stone, wall);
            }
        }
        else
        {
            if (!IsSpawnNear(evilBiomeXCoordinates.Key - biomeWidth, biomeWidth))
            {
                GenerateBiomeOnTheLeftSide(biome, evilBiomeXCoordinates.Key, StartY, endY, biomeWidth, dirt, grass, stone, wall);
            }
            else
            {
                GenerateBiomeOnTheRightSide(biome, evilBiomeXCoordinates.Value, StartY, endY, biomeWidth,dirt, grass, stone, wall);
            }
        }
    }

    private static bool IsSpawnNear(int x, int minimumDistance)
    {
        int spawnTileX = Main.maxTilesX / 2;
        return (x + minimumDistance > spawnTileX && x < spawnTileX + minimumDistance)
               || (x - minimumDistance < spawnTileX && x > spawnTileX - minimumDistance);
    }
    
    private static void GenerateBiomeOnTheLeftSide(BEBiome biome, int startX, int startY, int endY, int biomeWidth, ushort dirt, ushort grass, ushort stone, ushort wall)
    {
        int rightX = startX - biomeWidth;
        BEBiomesXCoordinates.Add(biome, new KeyValuePair<int, int>(rightX, startX));
        for (int i = rightX; i < startX; i++)
        {
            GenerateBiomeVertically(i, startY, endY, dirt, grass, stone, wall);
        }
    }
    
    private static void GenerateBiomeOnTheRightSide(BEBiome biome, int startX, int startY, int endY, int biomeWidth, ushort dirt, ushort grass, ushort stone, ushort wall)
    {
        int leftX = startX + biomeWidth;
        BEBiomesXCoordinates.Add(biome, new KeyValuePair<int, int>(startX, leftX));
        for (int i = startX; i < leftX; i++)
        {
            GenerateBiomeVertically(i, startY, endY, dirt, grass, stone, wall);
        }
    }

    private static void GenerateBiomeVertically(int x, int startY, int endY, ushort dirt, ushort grass, ushort stone, ushort wall) 
    {
        for (int y = startY; y < endY; y++)
        {
            PlaceDefaultBlock(x, y, dirt);
            PlaceGrassBlock(x, y, grass);
            PlaceStoneBlock(x, y, stone);
            PlaceWall(x, y, wall);
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
    
    private static void PlaceDefaultBlock(int x, int y, ushort tileType)
    {
        try
        {
            if (Main.tile[x, y].HasTile && !StoneTiles.Contains(Main.tile[x, y].TileType))
            {
                Main.tile[x, y].TileType = tileType; 
            }
        }
        catch (Exception e)
        {
            ModContent.GetInstance<BiomeExpansion>().Logger.Error(e);        
        }
    }
    
    private static void PlaceGrassBlock(int x, int y, ushort tileType)
    {
        try
        {
            if (Main.tile[x, y].HasTile && !StoneTiles.Contains(Main.tile[x, y].TileType)
                && (!Main.tile[x, y - 1].HasTile || !Main.tile[x, y + 1].HasTile 
                                                 || !Main.tile[x - 1, y].HasTile || !Main.tile[x + 1, y].HasTile
                                                 || !Main.tile[x - 1, y - 1].HasTile || !Main.tile[x - 1, y + 1].HasTile
                                                 || !Main.tile[x + 1, y - 1].HasTile || !Main.tile[x + 1, y + 1].HasTile))
            {
                Main.tile[x, y].TileType = tileType; 
            }
        }
        catch (Exception e)
        {
            ModContent.GetInstance<BiomeExpansion>().Logger.Error(e);        
        }
    }
    
    private static void PlaceStoneBlock(int x, int y, ushort tileType)
    {
        try
        {
            if (Main.tile[x, y].HasTile && StoneTiles.Contains(Main.tile[x, y].TileType))
            {
                Main.tile[x, y].TileType = tileType; 
            }
        }
        catch (Exception e)
        {
            ModContent.GetInstance<BiomeExpansion>().Logger.Error(e);        
        }
    }
    
    private static void PlaceWall(int x, int y, ushort wall)
    {
        try
        {
            if (Main.tile[x, y].WallType > 0)
            {
                Main.tile[x, y].WallType = wall; 
            }
        }
        catch (Exception e)
        {
            ModContent.GetInstance<BiomeExpansion>().Logger.Error(e);        
        }
    }
}