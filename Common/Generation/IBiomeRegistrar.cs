using System.Collections.Generic;

namespace BiomeExpansion.Common.Generation;

public interface IBiomeRegistrar
{
    void Register(BEBiome biome, KeyValuePair<int, int> xCoordinates, KeyValuePair<int, int> yCoordinates);
}