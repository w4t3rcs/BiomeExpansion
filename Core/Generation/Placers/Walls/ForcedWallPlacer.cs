using System.Linq;

namespace BiomeExpansion.Core.Generation.Placers.Walls;

public class ForcedWallPlacer : IWallPlacer
{
    public void PlaceWall(int x, int y, ushort wall, ushort tileBehindWall = 0, int[] replacedWalls = null, int[] highPriorityWalls = null)
    {
        if ((tileBehindWall == 0 || Main.tile[x, y].TileType == tileBehindWall)
            && (replacedWalls == null || replacedWalls.Length == 0 || replacedWalls.Contains(Main.tile[x, y].WallType)))
        {
            Main.tile[x, y].WallType = wall;
            WorldGen.SquareWallFrame(x, y);
            NetMessage.SendTileSquare(-1, x, y);
        }
    }
}