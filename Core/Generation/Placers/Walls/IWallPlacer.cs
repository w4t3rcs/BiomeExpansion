namespace BiomeExpansion.Core.Generation.Placers.Walls;

public interface IWallPlacer
{
    public void PlaceWall(int x, int y, ushort wall, ushort tileBehindWall = 0, int[] replacedWalls = null, int[] highPriorityWalls = null);
}