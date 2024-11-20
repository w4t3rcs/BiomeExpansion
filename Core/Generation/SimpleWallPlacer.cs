namespace BiomeExpansion.Core.Generation;

public class SimpleWallPlacer : IWallPlacer
{
    public void PlaceWall(BEBiome biome, ushort wall, ushort tileBehindWall = 0)
    {
        var (leftX, rightX) = GenerationHelper.BEBiomesXCoordinates[biome];
        var (startY, endY) = GenerationHelper.BEBiomesYCoordinates[biome];
        for (int i = leftX; i < rightX; i++)
            GenerateWallsVertically(i, startY, endY, wall, tileBehindWall);
        for (int i = startY; i < endY; i++)
            GenerateWallTransition(i, startY, endY, wall, tileBehindWall);
    }

    private void GenerateWallsVertically(int x, int startY, int endY, ushort wall, ushort tileBehindWall = 0) 
    {
        for (int y = startY; y < endY + Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); y++)
        {
            PlaceWallPoint(x, y, wall, tileBehindWall);
        }
    }

    private void GenerateWallTransition(int y, int leftX, int rightX, ushort wall, ushort tileBehindWall = 0) 
    {
        for (int x = leftX - Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); x < leftX; x++)
        {
            PlaceWallPoint(x, y, wall, tileBehindWall);
        }

        for (int x = rightX ; x < rightX + Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); x++)
        {
            PlaceWallPoint(x, y, wall, tileBehindWall);
        }
    }

    private void PlaceWallPoint(int x, int y, ushort wall, ushort tileBehindWall = 0)
    {
        if (tileBehindWall == 0 || Main.tile[x, y].TileType == tileBehindWall) WorldGen.ReplaceWall(x, y, wall);
    }
}