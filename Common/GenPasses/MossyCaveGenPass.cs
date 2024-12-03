using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Content.Tiles.Plants;
using BiomeExpansion.Content.Tiles.Stones;
using BiomeExpansion.Content.Walls;
using BiomeExpansion.Core.Generation;
using BiomeExpansion.Helpers;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace BiomeExpansion.Common.GenPasses;

public class MossyCaveGenPass(string name, double loadWeight) : GenPass(name, loadWeight)
{
    protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
    { 
        progress.Message = "Generating Cave Infected Mushroom biome...";
        GenerationHelper.CreateCaveBiomeBuilder()
            .Biome(BEBiome.MossyCave)
            .BiomePlacer(GenerationHelper.RectangleBiomePlacer)
            .Deepness(350)
            .IsDependentBiome()
            .AboveBiome(BEBiome.InfectedMushroomCave)
            .GroundModification(GenerationHelper.MossyCaveModification)
            .TileGenerationStep()
                .TileType(ModContent.TileType<Layer2Stone1>())
                .TilePlacer(GenerationHelper.MainTilePlacer)
                .AndCave()
            .OreGenerationStep()
                .TileType(ModContent.TileType<Layer2Stone2>())
                .Rarity(250)
                .Strength(WorldGen.genRand.Next(12, 16))
                .Steps(WorldGen.genRand.Next(10, 18))
                .AndCave()
            .Generate();
    }
}