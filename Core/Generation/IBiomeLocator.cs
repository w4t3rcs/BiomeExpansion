using System.Collections.Generic;

namespace BiomeExpansion.Core.Generation;

public interface IBiomeLocator
{
    public KeyValuePair<int, int> GetBiomeXCoordinates(int width, ushort[] nearbyTiles = null);

    public KeyValuePair<int, int> GetBiomeYCoordinates(int height);
}