using System.Collections.Generic;
using BiomeExpansion.Core.Generation.Steps;

namespace BiomeExpansion.Core.Generation.Placers.Biomes;

public interface IBiomePlacer
{
    public void Place(BEBiome biome, List<TileGenerationStep> tileSteps, List<GroundDecorationGenerationStep> groundDecorationSteps, List<OreGenerationStep> oreSteps, List<WallGenerationStep> wallSteps);
}