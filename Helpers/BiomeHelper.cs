using System.Collections.Generic;
using System.Linq;

namespace BiomeExpansion.Helpers;

public static class BiomeHelper
{
    public static readonly int SurfaceY = Main.maxTilesY/8 + 10;
    public static readonly ushort[] StoneTiles = [TileID.CorruptSandstone, TileID.Ebonstone, TileID.CrimsonSandstone, TileID.Crimstone, TileID.Stone, TileID.Sandstone, TileID.CorruptSandstone, TileID.CrimsonSandstone, TileID.HardenedSand, TileID.CorruptHardenedSand, TileID.CrimsonHardenedSand];
    public static readonly ushort[] SandTiles = [TileID.Sand, TileID.Ebonsand, TileID.Crimsand];
    public static readonly ushort[] EvilGroundTiles = [TileID.CorruptGrass, TileID.CorruptSandstone, TileID.Ebonsand, TileID.Ebonstone, TileID.CrimsonGrass, TileID.CrimsonSandstone, TileID.Crimsand, TileID.Crimstone];
    public static readonly int[] GrassWalls = [WallID.Grass, WallID.GrassUnsafe, WallID.CorruptGrassEcho, WallID.CorruptGrassUnsafe, WallID.CrimsonGrassEcho, WallID.CrimsonGrassUnsafe, WallID.HallowedGrassEcho, WallID.HallowedGrassUnsafe, WallID.Dirt, WallID.Dirt1Echo, WallID.Dirt2Echo, WallID.Dirt3Echo, WallID.Dirt4Echo, WallID.DirtUnsafe, WallID.DirtUnsafe1, WallID.DirtUnsafe2, WallID.DirtUnsafe3, WallID.DirtUnsafe4, WallID.LivingLeaf];
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