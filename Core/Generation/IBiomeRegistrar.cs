using System.Collections.Generic;

namespace BiomeExpansion.Core.Generation;

public interface IBiomeRegistrar
{
    void Register(BEBiome biome, KeyValuePair<int, int> xCoordinates, KeyValuePair<int, int> yCoordinates);
}