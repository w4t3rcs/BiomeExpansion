using System.Linq;

namespace BiomeExpansion.Core.Generation.Placers.Walls;

public class SimpleWallPlacer : IWallPlacer
{
    public void PlaceWall(int x, int y, ushort wall, ushort tileBehindWall = 0, int[] replacedWalls = null, int[] highPriorityWalls = null)
    {
        if ((tileBehindWall == 0 || Main.tile[x, y].TileType == tileBehindWall)
            && (replacedWalls == null || replacedWalls.Length == 0 || replacedWalls.Contains(Main.tile[x, y].WallType))
                && (highPriorityWalls == null || highPriorityWalls.Length == 0 || !highPriorityWalls.Contains(Main.tile[x, y].WallType)))
            WorldGen.ReplaceWall(x, y, wall);
    }
}