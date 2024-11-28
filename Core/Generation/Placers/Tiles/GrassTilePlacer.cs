using System.Linq;

namespace BiomeExpansion.Core.Generation.Placers.Tiles;

public class GrassTilePlacer : ITilePlacer
{
    public void PlaceTile(int x, int y, ushort tileType, ushort[] additionalTileTypes = null)
    {
        WorldGen.SpreadGrass(x, y, additionalTileTypes[0], tileType);
    }
}