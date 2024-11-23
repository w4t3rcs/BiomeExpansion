using System.Linq;

namespace BiomeExpansion.Core.Generation;

public class SimpleWallPlacer : IWallPlacer
{
    public void PlaceWall(BEBiome biome, ushort wall, ushort tileBehindWall = 0, int[] replacedWalls = null, int[] highPriorityWalls = null)
    {
        var (leftX, rightX) = GenerationHelper.BEBiomesXCoordinates[biome];
        var (startY, endY) = GenerationHelper.BEBiomesYCoordinates[biome];
        for (int i = leftX; i < rightX; i++)
            GenerateWallsVertically(i, startY, endY, wall, tileBehindWall, replacedWalls, highPriorityWalls);
        for (int i = startY; i < endY; i++)
            GenerateWallTransition(i, startY, endY, wall, tileBehindWall, replacedWalls, highPriorityWalls);
    }

    private void GenerateWallsVertically(int x, int startY, int endY, ushort wall, ushort tileBehindWall = 0, int[] replacedWalls = null, int[] highPriorityWalls = null) 
    {
        for (int y = startY; y < endY + Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); y++)
        {
            PlaceWallPoint(x, y, wall, tileBehindWall, replacedWalls, highPriorityWalls);
        }
    }

    private void GenerateWallTransition(int y, int leftX, int rightX, ushort wall, ushort tileBehindWall = 0, int[] replacedWalls = null, int[] highPriorityWalls = null) 
    {
        for (int x = leftX - Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); x < leftX; x++)
        {
            PlaceWallPoint(x, y, wall, tileBehindWall, replacedWalls, highPriorityWalls);
        }

        for (int x = rightX ; x < rightX + Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); x++)
        {
            PlaceWallPoint(x, y, wall, tileBehindWall, replacedWalls, highPriorityWalls);
        }
    }

    private void PlaceWallPoint(int x, int y, ushort wall, ushort tileBehindWall = 0, int[] replacedWalls = null, int[] highPriorityWalls = null)
    {
        if ((tileBehindWall == 0 || Main.tile[x, y].TileType == tileBehindWall)
            && (replacedWalls == null || replacedWalls.Length == 0 || replacedWalls.Contains(Main.tile[x, y].WallType))
                && (highPriorityWalls == null || highPriorityWalls.Length == 0 || !highPriorityWalls.Contains(Main.tile[x, y].WallType)))
            WorldGen.ReplaceWall(x, y, wall);
    }
}