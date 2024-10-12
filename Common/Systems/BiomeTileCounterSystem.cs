using System;
using BiomeExpansion.Content.Tiles;
using Terraria.ModLoader;

namespace BiomeExpansion.Common.Systems;

public class BiomeTileCounterSystem : ModSystem
{
    public int CorruptionInfectedMushroomSurfaceBiomeTileCount;
    public int CrimsonInfectedMushroomSurfaceBiomeTileCount;
    
    public override void ResetNearbyTileEffects()
    {
        CorruptionInfectedMushroomSurfaceBiomeTileCount = 0;
        CrimsonInfectedMushroomSurfaceBiomeTileCount = 0;
    }

    public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
    {
        CorruptionInfectedMushroomSurfaceBiomeTileCount = tileCounts[ModContent.TileType<CorruptionInfectedMushroomGrass>()] + tileCounts[ModContent.TileType<CorruptionInfectedMushroomStone>()];
        CrimsonInfectedMushroomSurfaceBiomeTileCount = tileCounts[ModContent.TileType<CrimsonInfectedMushroomGrass>()] + tileCounts[ModContent.TileType<CrimsonInfectedMushroomStone>()];
    }
}