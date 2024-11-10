using System.Collections.Generic;

namespace BiomeExpansion.Core.Generation;

public class BiomeRegistrar : IBiomeRegistrar
{
    public void Register(BEBiome biome, KeyValuePair<int, int> xCoordinates, KeyValuePair<int, int> yCoordinates)
    {
        GenerationHelper.BEBiomesXCoordinates.Add(biome, xCoordinates);
        GenerationHelper.BEBiomesYCoordinates.Add(biome, yCoordinates);
    }
}