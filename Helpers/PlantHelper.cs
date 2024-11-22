using System.Linq;
using BiomeExpansion.Core.Generation;

namespace BiomeExpansion.Helpers;

public static class PlantHelper
{
    public static bool CheckBottomPositionToPlace(ushort rarity, int[] soilTiles, int x, int y, int range)
    {
        if (soilTiles.Contains(Main.tile[x, y].TileType) && !Main.tile[x, y].TopSlope && WorldGen.genRand.NextBool(rarity))
        {
            for (int i = y + 1; i < y + range; i++)
            {
                if (Main.tile[x, i].HasTile) return false;
            }
            
            return true;
        }
        
        return false;
    }
    
    public static bool CheckTopPositionToPlace(ushort rarity, int[] soilTiles, int x, int y, int width = 1, int height = 1)
    {
        if (!soilTiles.Contains(Main.tile[x, y].TileType) || Main.tile[x, y].BottomSlope || !WorldGen.genRand.NextBool(rarity)) return false;
        for (int i = 1; i <= height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (Main.tile[x + j, y - i].HasTile) return false;
            }
        }
        
        return true;
    }
}