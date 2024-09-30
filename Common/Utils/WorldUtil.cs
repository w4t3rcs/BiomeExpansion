using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.WorldBuilding;

namespace BiomeExpansion.Common.Utils;

public static class WorldUtil
{
    private static ushort[] ReplacedGrassTiles => [TileID.Grass, TileID.CorruptGrass, TileID.CrimsonGrass];
    private static ushort[] ReplacedDirtTiles => [TileID.Dirt, TileID.ClayBlock, TileID.Stone];
    
    public static void GenerateBiomeNextToEvilBiome(GenerationProgress progress, int biomeWidth, int biomeHeight, ushort dirtBlock, ushort grassBlock)
    {
        progress.Message = "Generating BiomeExpansion biomes...";
        int startY = Main.maxTilesY / 8, endY = (int)(Main.worldSurface - 10 + biomeHeight);
        KeyValuePair<int,int> evilBiomeXCoordinates = GetBiomeXCoordinates(startY, endY, [
                TileID.CorruptGrass, TileID.CorruptSandstone, TileID.Ebonsand, TileID.Ebonstone,
                TileID.CrimsonGrass, TileID.CrimsonSandstone, TileID.Crimsand, TileID.Crimstone,
        ]);
        if (evilBiomeXCoordinates.Value < Main.maxTilesX / 2)
        {
            if (!IsSpawnNear(evilBiomeXCoordinates.Value + biomeWidth / 2, biomeWidth))
            {
                GenerateBiomeOnTheRightSide(evilBiomeXCoordinates.Value, startY, endY, biomeWidth, biomeHeight, dirtBlock, grassBlock);
            }
            else
            {
                GenerateBiomeOnTheLeftSide(evilBiomeXCoordinates.Key, startY, endY, biomeWidth, biomeHeight, dirtBlock, grassBlock);
            }
        }
        else
        {
            if (!IsSpawnNear(evilBiomeXCoordinates.Key - biomeWidth / 2, biomeWidth))
            {
                GenerateBiomeOnTheLeftSide(evilBiomeXCoordinates.Key, startY, endY, biomeWidth, biomeHeight, dirtBlock, grassBlock);
            }
            else
            {
                GenerateBiomeOnTheRightSide(evilBiomeXCoordinates.Value, startY, endY, biomeWidth, biomeHeight,dirtBlock, grassBlock);
            }
        }
    }

    public static bool IsSpawnNear(int x, int minimumDistance)
    {
        int spawnTileX = Main.spawnTileX;
        return (x + minimumDistance > spawnTileX && x < spawnTileX + Main.maxTilesX)
               || (x - minimumDistance < spawnTileX && x > spawnTileX - Main.maxTilesX);
    }
    
    public static void GenerateBiomeOnTheLeftSide(int startX, int startY, int endY, int biomeWidth, int biomeHeight, ushort dirtBlock, ushort grassBlock)
    {
        {
            for (int i = startX - biomeWidth; i < startX; i++)
            {
                for (int j = startY; j < endY; j++)
                {
                    ReplaceBlocks(i, j, ReplacedGrassTiles, grassBlock);
                    ReplaceBlocks(i, j, ReplacedDirtTiles, dirtBlock);
                }
            }
        }
    }
    
    public static void GenerateBiomeOnTheRightSide(int startX, int startY, int endY, int biomeWidth, int biomeHeight, ushort dirtBlock, ushort grassBlock)
    {
        for (int i = startX; i < startX + biomeWidth; i++)
        {
            for (int j = startY; j < endY; j++)
            {
                ReplaceBlocks(i, j, ReplacedGrassTiles, grassBlock);
                ReplaceBlocks(i, j, ReplacedDirtTiles, dirtBlock);
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
    
    public static void ReplaceBlocks(int x, int y, ushort[] replacedTiles, ushort tileType)
    {
        if (Main.tile[x, y].HasTile && replacedTiles.Contains(Main.tile[x, y].TileType))
        {
            Main.tile[x, y].TileType = tileType; 
        } 
    }
}