using System;
using BiomeExpansion.Content.Tiles;
using Terraria.ModLoader;

namespace BiomeExpansion.Common.Systems;

public class BiomeTileCounterSystem : ModSystem
{
    public int TileCount = 0;

    public override void ResetNearbyTileEffects()
    {
        TileCount = 0;
    }

    public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
    {
        TileCount = tileCounts[ModContent.TileType<TestBlock>()] + tileCounts[ModContent.TileType<TestGrassBlock>()];
    }
}