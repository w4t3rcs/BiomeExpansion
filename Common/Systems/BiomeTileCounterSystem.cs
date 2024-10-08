using System;
using BiomeExpansion.Content.Tiles;
using Terraria.ModLoader;

namespace BiomeExpansion.Common.Systems;

public class BiomeTileCounterSystem : ModSystem
{
    public int CorruptionInfectedMushroomBiomeTileCount;
    public int CrimsonInfectedMushroomBiomeTileCount;
    
    public override void ResetNearbyTileEffects()
    {
        CorruptionInfectedMushroomBiomeTileCount = 0;
        CrimsonInfectedMushroomBiomeTileCount = 0;
    }

    public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
    {
        CorruptionInfectedMushroomBiomeTileCount = tileCounts[ModContent.TileType<CorruptionInfectedMushroomGrass>()] + tileCounts[ModContent.TileType<CorruptionInfectedMushroomStone>()];
        CrimsonInfectedMushroomBiomeTileCount = tileCounts[ModContent.TileType<CrimsonInfectedMushroomGrass>()];
    }
}