using System;
using System.Linq;
using Terraria;
using Terraria.ID;

namespace BiomeExpansion.Common.Utils;

public static class WorldUtil
{
    public static bool IsNearCorruption(int x, int y, int radius)
    {
        return IsNearBiome(x, y, radius, [TileID.CorruptGrass]);
    }
    
    public static bool IsNearCrimson(int x, int y, int radius)
    {
        return IsNearBiome(x, y, radius, [TileID.CrimsonGrass]);
    }

    
    public static bool IsNearBiome(int x, int y, int radius, ushort[] biomeTiles)
    {
        try
        {
            for (int i = x - radius; i < x + radius; i++)
            {
                for (int j = y - radius; j < y + radius; j++)
                {
                    if (biomeTiles.Contains(Main.tile[i, j].TileType))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        catch (Exception e)
        {
            return false;
        }
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