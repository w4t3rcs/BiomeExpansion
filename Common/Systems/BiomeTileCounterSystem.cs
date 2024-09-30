using System;
using BiomeExpansion.Content.Tiles;
using Terraria.ModLoader;

namespace BiomeExpansion.Common.Systems;

public class BiomeTileCounterSystem : ModSystem
{
    public int InfectedMushroomBiomeTileCount;
    
    public override void ResetNearbyTileEffects()
    {
        InfectedMushroomBiomeTileCount = 0;
    }

    public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
    {
        InfectedMushroomBiomeTileCount = tileCounts[ModContent.TileType<TestBlock>()] + tileCounts[ModContent.TileType<TestGrassBlock>()];
    }
}