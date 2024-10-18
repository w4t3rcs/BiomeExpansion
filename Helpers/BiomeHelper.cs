using System.Collections.Generic;
using System.Linq;
using BiomeExpansion.Common.Generation;
using Terraria;
using Terraria.ID;

namespace BiomeExpansion.Helpers;

public static class BiomeHelper
{
    public static readonly int SurfaceY = Main.maxTilesY / 8;
    public static readonly ushort[] StoneTiles = [TileID.CorruptSandstone, TileID.Ebonstone, TileID.CrimsonSandstone, TileID.Crimstone, TileID.Stone];
    public static readonly ushort[] EvilGroundTiles = [TileID.CorruptGrass, TileID.CorruptSandstone, TileID.Ebonsand, TileID.Ebonstone, TileID.CrimsonGrass, TileID.CrimsonSandstone, TileID.Crimsand, TileID.Crimstone];
    private const int MaximumBiomeTileDistance = 10;
    
    public static void GenerateSurfaceBiome(BEBiome biome, ushort dirt, ushort grass, ushort stone, ushort wall)
    {
        var (leftX, rightX) = GenerationHelper.BEBiomesXCoordinates[biome];
        var (startY, endY) = GenerationHelper.BEBiomesYCoordinates[biome];
        for (int i = leftX; i < rightX; i++)
        {
            GenerateBiomeVertically(i, startY, endY, dirt, grass, stone, wall);
        }
    }

    public static void GenerateDependentCaveBiome(BEBiome biome, ushort mainTile, ushort wall)
    {
        var (leftX, rightX) = GenerationHelper.BEBiomesXCoordinates[biome];
        var (startY, endY) = GenerationHelper.BEBiomesYCoordinates[biome];
        for (int i = leftX; i < rightX; i++)
        {
            GenerateBiomeVertically(i, startY, endY, mainTile, wall);
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

    public static KeyValuePair<int, int> GetBiomeXCoordinates(int startY, ushort[] biomeTiles)
    {
        int leftX = GetBiomeLeftX(startY, biomeTiles);
        int rightX = GetBiomeRightX(startY, biomeTiles, leftX);
        return new KeyValuePair<int, int>(leftX, rightX);
    }
    
    private static int GetBiomeRightX(int startY, ushort[] biomeTiles, int leftX)
    {
        int distanceCounter = 0;
        int rightX = leftX + 1;
        for (int x = rightX; x < Main.maxTilesX; x++)
        {
            bool neededTileFound = false;
            for (int y = startY; y < startY + startY/2; y++)
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

    private static int GetBiomeLeftX(int startY, ushort[] biomeTiles)
    {
        int leftX = 0;
        for (int y = startY; y < startY + startY/2; y++)
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
    
    public static bool IsSpawnNear(int x, int minimumDistance)
    {
        int spawnTileX = Main.maxTilesX / 2;
        return (x + minimumDistance > spawnTileX && x < spawnTileX + minimumDistance)
               || (x - minimumDistance < spawnTileX && x > spawnTileX - minimumDistance);
    }
}