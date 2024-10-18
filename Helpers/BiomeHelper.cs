using System.Collections.Generic;
using System.Linq;
using BiomeExpansion.Common.Generation;
using Terraria;
using Terraria.ID;

namespace BiomeExpansion.Helpers;

//todo: I must refactor this static class (this code is awful and I want to cry)
public static class BiomeHelper
{
    private static readonly ushort[] StoneTiles = [TileID.CorruptSandstone, TileID.Ebonstone, TileID.CrimsonSandstone, TileID.Crimstone, TileID.Stone];
    private const int MaximumBiomeTileDistance = 10;
    
    public static void GenerateCaveBiomeUnderBEBiome(BEBiome biome, BEBiome aboveBiome, int deepness, ushort mainTile, ushort wall)
    {
        var (leftX, rightX) = GenerationHelper.BEBiomesXCoordinates[aboveBiome];
        var (_, endY) = GenerationHelper.BEBiomesYCoordinates[BEBiome.InfectedMushroomSurface];
        GenerationHelper.BEBiomesXCoordinates.Add(biome, new KeyValuePair<int, int>(leftX, rightX));
        GenerationHelper.BEBiomesYCoordinates.Add(biome, new KeyValuePair<int, int>(endY, endY + deepness));
        for (int i = leftX; i < rightX; i++)
        {
            GenerateBiomeVertically(i, endY - 10, endY + deepness, mainTile, wall);
        }
    }
    
    public static void GenerateSurfaceBiomeNextToEvilBiome(BEBiome biome, int biomeWidth, int biomeHeight, ushort dirt, ushort grass, ushort stone, ushort wall)
    {
        GenerateSurfaceBiomeNextToBiome(biome, biomeWidth, biomeHeight, dirt, grass, stone, wall, [
                TileID.CorruptGrass, TileID.CorruptSandstone, TileID.Ebonsand, TileID.Ebonstone,
                TileID.CrimsonGrass, TileID.CrimsonSandstone, TileID.Crimsand, TileID.Crimstone
        ]);
    }
    
    public static void GenerateSurfaceBiomeNextToBiome(BEBiome biome, int biomeWidth, int biomeHeight, ushort dirt, ushort grass, ushort stone, ushort wall, ushort[] neighbourBiomeTiles)
    {
        int endY = (int)(Main.worldSurface - 10 + biomeHeight);
        KeyValuePair<int,int> evilBiomeXCoordinates = GetBiomeXCoordinates(GenerationHelper.SurfaceY, endY, neighbourBiomeTiles);
        if (evilBiomeXCoordinates.Value < Main.maxTilesX / 2)
        {
            if (!IsSpawnNear(evilBiomeXCoordinates.Value + biomeWidth, biomeWidth))
            {
                GenerateBiomeOnTheRightSide(biome, evilBiomeXCoordinates.Value, GenerationHelper.SurfaceY, endY, biomeWidth, dirt, grass, stone, wall);
            }
            else
            {
                GenerateBiomeOnTheLeftSide(biome, evilBiomeXCoordinates.Key, GenerationHelper.SurfaceY, endY, biomeWidth, dirt, grass, stone, wall);
            }
        }
        else
        {
            if (!IsSpawnNear(evilBiomeXCoordinates.Key - biomeWidth, biomeWidth))
            {
                GenerateBiomeOnTheLeftSide(biome, evilBiomeXCoordinates.Key, GenerationHelper.SurfaceY, endY, biomeWidth, dirt, grass, stone, wall);
            }
            else
            {
                GenerateBiomeOnTheRightSide(biome, evilBiomeXCoordinates.Value, GenerationHelper.SurfaceY, endY, biomeWidth,dirt, grass, stone, wall);
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
        GenerationHelper.BEBiomesXCoordinates.Add(biome, new KeyValuePair<int, int>(rightX, startX));
        GenerationHelper.BEBiomesYCoordinates.Add(biome, new KeyValuePair<int, int>(startY, endY));
        for (int i = rightX; i < startX; i++)
        {
            GenerateBiomeVertically(i, startY, endY, dirt, grass, stone, wall);
        }
    }
    
    private static void GenerateBiomeOnTheRightSide(BEBiome biome, int startX, int startY, int endY, int biomeWidth, ushort dirt, ushort grass, ushort stone, ushort wall)
    {
        int leftX = startX + biomeWidth;
        GenerationHelper.BEBiomesXCoordinates.Add(biome, new KeyValuePair<int, int>(startX, leftX));
        GenerationHelper.BEBiomesYCoordinates.Add(biome, new KeyValuePair<int, int>(startY, endY));
        for (int i = startX; i < leftX; i++)
        {
            GenerateBiomeVertically(i, startY, endY, dirt, grass, stone, wall);
        }
    }

    private static void GenerateBiomeVertically(int x, int startY, int endY, ushort mainTile, ushort wall) 
    {
        for (int y = startY; y < endY; y++)
        {
            PlaceMainTile(x, y, mainTile);
            PlaceWall(x, y, wall);
        }
    }
    
    private static void GenerateBiomeVertically(int x, int startY, int endY, ushort dirt, ushort grass, ushort stone, ushort wall) 
    {
        for (int y = startY; y < endY; y++)
        {
            PlaceDirt(x, y, dirt);
            PlaceGrass(x, y, dirt, grass);
            PlaceStone(x, y, stone);
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
    
    private static void PlaceMainTile(int x, int y, ushort tileType)
    {
        WorldGen.ReplaceTile(x, y, tileType, Main.tile[x, y].TileFrameX);
    }
    
    private static void PlaceDirt(int x, int y, ushort tileType)
    {
        if (!StoneTiles.Contains(Main.tile[x, y].TileType))
            WorldGen.ReplaceTile(x, y, tileType, Main.tile[x, y].TileFrameX);
    }
    
    private static void PlaceGrass(int x, int y, ushort dirt, ushort grass)
    {
        WorldGen.SpreadGrass(x, y, dirt, grass);
    }
    
    private static void PlaceStone(int x, int y, ushort tileType)
    {
        if (StoneTiles.Contains(Main.tile[x, y].TileType))
            WorldGen.ReplaceTile(x, y, tileType, Main.tile[x, y].TileFrameX);
    }
    
    private static void PlaceWall(int x, int y, ushort wall)
    {
        WorldGen.ReplaceWall(x, y, wall);
    }
}