using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.WorldBuilding;

namespace BiomeExpansion.Common.Utils;

public static class WorldUtil
{
    public static void GenerateBiomeNextToEvilBiome(GenerationProgress progress, int biomeWidth, int biomeHeight, ushort dirtBlock, ushort grassBlock)
    {
        progress.Message = "Generating BiomeExpansion biomes...";
        int startY = Main.maxTilesY / 8, endY = (int)(Main.worldSurface - 10 + biomeHeight);
        KeyValuePair<int,int> evilBiomeXCoordinates = GetBiomeXCoordinates(startY, endY, [
                TileID.CorruptGrass, TileID.CorruptSandstone, TileID.Ebonsand, TileID.Ebonstone,
                TileID.CrimsonGrass, TileID.CrimsonSandstone, TileID.Crimsand, TileID.Crimstone,
        ]);
        int startX = Main.maxTilesX - evilBiomeXCoordinates.Value < evilBiomeXCoordinates.Key ? evilBiomeXCoordinates.Key - biomeWidth : evilBiomeXCoordinates.Value;
        for (int i = startX; i < startX + biomeWidth; i++)
        {
            for (int j = startY; j < endY; j++)
            {
                ReplaceBlocks(i, j, startX, biomeWidth, startY, biomeHeight, [TileID.Dirt, TileID.ClayBlock, TileID.Stone], dirtBlock);
                ReplaceBlocks(i, j, startX, biomeWidth, startY, biomeHeight, [TileID.Grass], grassBlock);
            }
        }
    }
    
    public static KeyValuePair<int, int> GetBiomeXCoordinates(int startY, int endY, ushort[] biomeTiles)
    {
        int maximumBiomeTileDistance = 25;
        int leftX = 0, rightX = 0;
        for (int i = startY; i < endY; i++)
        {
            for (int j = 0; j < Main.maxTilesX; j++)
            {
                if (biomeTiles.Contains(Main.tile[j, i].TileType))
                {
                    if (leftX == 0)
                    {
                        leftX = j;
                        rightX = j + 1;
                    }
                    else
                    {
                        if (maximumBiomeTileDistance < j - rightX)
                        {
                            rightX++;
                        }
                    }
                }
            }
        }

        return new KeyValuePair<int, int>(leftX, rightX);
    }
    
    public static void ReplaceBlocks(int x, int y, int startX, int biomeWidth, int startY, int biomeHeight, ushort[] replacedTiles, ushort tileType)
    {
        int distanceToEdgeX = Math.Min(x - startX, startX + biomeWidth - x);
        int distanceToEdgeY = startY + biomeHeight - y;
        if (Main.tile[x, y].HasTile && replacedTiles.Contains(Main.tile[x, y].TileType))
        {
            if (distanceToEdgeX > 20 || distanceToEdgeY > 20)
            {
                Main.tile[x, y].TileType = tileType; 
            }
            else
            {
                if (WorldGen.genRand.NextFloat() < 0.5f)
                {
                    Main.tile[x, y].TileType = tileType;
                }
            }
        } 
    }
}