﻿using System.Collections.Generic;
using System.Linq;
using BiomeExpansion.Core.Generation;
using Terraria;
using Terraria.ID;

namespace BiomeExpansion.Helpers;

public static class BiomeHelper
{
    public static readonly int SurfaceY = Main.maxTilesY/8 + 10;
    public static readonly ushort[] StoneTiles = [TileID.CorruptSandstone, TileID.Ebonstone, TileID.CrimsonSandstone, TileID.Crimstone, TileID.Stone];
    public static readonly ushort[] EvilGroundTiles = [TileID.CorruptGrass, TileID.CorruptSandstone, TileID.Ebonsand, TileID.Ebonstone, TileID.CrimsonGrass, TileID.CrimsonSandstone, TileID.Crimsand, TileID.Crimstone];
    public const int MaximumBiomeTileDistance = 10;
    public const int MaximumBiomeTransitionLength = 15;

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
    
    
    
    public static bool IsSpawnNear(int x, int minimumDistance)
    {
        int spawnTileX = Main.maxTilesX / 2;
        return (x + minimumDistance > spawnTileX && x < spawnTileX + minimumDistance) 
            || (x - minimumDistance < spawnTileX && x > spawnTileX - minimumDistance);
    }
}