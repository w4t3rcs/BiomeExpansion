using System.Collections.Generic;

namespace BiomeExpansion.Core.Generation;

public class SurfaceBiomeLocator : IBiomeLocator
{
    public KeyValuePair<int, int> GetBiomeXCoordinates(int width, ushort[] nearbyTiles = null)
    {
        KeyValuePair<int, int> result = new KeyValuePair<int, int>(0, 0);
        if (nearbyTiles is not null && nearbyTiles.Length != 0)
        {
            KeyValuePair<int, int> nearbyBiomeCoordinates = BiomeHelper.GetBiomeXCoordinates(BiomeHelper.SurfaceY, nearbyTiles);
            if (nearbyBiomeCoordinates.Value < Main.maxTilesX / 2)
            {
                result = !BiomeHelper.IsSpawnNear(nearbyBiomeCoordinates.Value + width, width)
                    ? new KeyValuePair<int, int>(nearbyBiomeCoordinates.Value, nearbyBiomeCoordinates.Value + width)
                    : new KeyValuePair<int, int>(nearbyBiomeCoordinates.Key - width, nearbyBiomeCoordinates.Key);
            }
            else
            {
                result = !BiomeHelper.IsSpawnNear(nearbyBiomeCoordinates.Key - width, width)
                    ? new KeyValuePair<int, int>(nearbyBiomeCoordinates.Key - width, nearbyBiomeCoordinates.Key)
                    : new KeyValuePair<int, int>(nearbyBiomeCoordinates.Value, nearbyBiomeCoordinates.Value + width);
            }
        }

        return result;
    }

    public KeyValuePair<int, int> GetBiomeYCoordinates(int height)
    {
        return new KeyValuePair<int, int>(BiomeHelper.SurfaceY, (int)(Main.worldSurface - 10 + height));
    }
}