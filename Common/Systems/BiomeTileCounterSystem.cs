using System;
using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Content.Tiles.Sands;
using BiomeExpansion.Content.Tiles.Stones;
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
        CorruptionInfectedMushroomSurfaceBiomeTileCount = tileCounts[ModContent.TileType<CorruptionInfectedMushroomGrass>()] + tileCounts[ModContent.TileType<CorruptionInfectedMushroomStone>()] + tileCounts[ModContent.TileType<CorruptionInfectedMushroomOldStone>()] + tileCounts[ModContent.TileType<CorruptionInfectedMushroomSand>()];
        CrimsonInfectedMushroomSurfaceBiomeTileCount = tileCounts[ModContent.TileType<CrimsonInfectedMushroomGrass>()] + tileCounts[ModContent.TileType<CrimsonInfectedMushroomStone>()] + tileCounts[ModContent.TileType<CrimsonInfectedMushroomOldStone>()] + tileCounts[ModContent.TileType<CrimsonInfectedMushroomSand>()];
    }
}