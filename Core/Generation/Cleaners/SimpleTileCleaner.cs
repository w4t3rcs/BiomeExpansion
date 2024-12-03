using System.Linq;

namespace BiomeExpansion.Core.Generation.Cleaners;

public class SimpleTileCleaner : ITileCleaner
{
    public void Clean(int leftX, int rightX, int topY, int bottomY, int[] removedTiles)
    {
        if (removedTiles is null || removedTiles.Length == 0) return;
        for (int i = topY - BiomeHelper.MaximumBiomeTransitionLength; i < bottomY + BiomeHelper.MaximumBiomeTransitionLength; i++)
        {
            for (int j = leftX - BiomeHelper.MaximumBiomeTransitionLength; j < rightX + BiomeHelper.MaximumBiomeTransitionLength; j++)
            {
                if (removedTiles.Contains(Main.tile[j, i].TileType))
                    WorldGen.KillTile(j, i, noItem: true);
            }    
        }
    }
}