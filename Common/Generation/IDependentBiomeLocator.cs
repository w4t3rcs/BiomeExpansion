﻿using System.Collections.Generic;

namespace BiomeExpansion.Common.Generation;

public interface IDependentBiomeLocator
{
    public KeyValuePair<int, int> GetBiomeXCoordinates(BEBiome biome);
    
    public KeyValuePair<int, int> GetBiomeYCoordinates(BEBiome biome, int height, bool isUnderParent = true);
}