using System.Collections.Generic;

namespace BiomeExpansion.Core.Generation.Locators;

public class DependentBiomeLocator : IDependentBiomeLocator
{
    public KeyValuePair<int, int> GetBiomeXCoordinates(BEBiome biome)
    {
        return GenerationHelper.BEBiomesXCoordinates[biome];
    }

    public KeyValuePair<int, int> GetBiomeYCoordinates(BEBiome biome, int height, bool isUnderParent = true)
    {
        return isUnderParent
            ? new KeyValuePair<int, int>(GenerationHelper.BEBiomesYCoordinates[biome].Value, GenerationHelper.BEBiomesYCoordinates[biome].Value + height)
            : new KeyValuePair<int, int>(GenerationHelper.BEBiomesYCoordinates[biome].Key - height, GenerationHelper.BEBiomesYCoordinates[biome].Key);
    }
}