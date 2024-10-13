using BiomeExpansion.Common.Generation;
using BiomeExpansion.Content.Tiles;
using BiomeExpansion.Content.Walls;
using BiomeExpansion.Helpers;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace BiomeExpansion.Common.GenPasses;

public class CaveInfectedMushroomGenPass(string name, double loadWeight) : GenPass(name, loadWeight)
{
    protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
    { 
        progress.Message = "Generating Cave Infected Mushroom biome...";
        if (WorldGen.crimson)
        {
            GenerationHelper.CreateCaveBiomeBuilder()
                .Biome(BEBiome.CaveInfectedMushroom)
                .Deepness(50)
                .IsUnderBEBiome()
                .DefaultCaveTileGenerationStep()
                    .GenerationId(GenerationHelper.MainGenerationId)
                    .TileType(ModContent.TileType<CrimsonInfectedMushroomStone>())
                    .AndCave()
                .DefaultCaveTileGenerationStep()
                    .GenerationId(GenerationHelper.WallGenerationId)
                    .TileType(ModContent.WallType<CrimsonInfectedMushroomWall>())
                    .AndCave()
                .OreGenerationStep()
                    .TileType(ModContent.TileType<CrimsoomOre>())
                    .Rarity(75)
                    .Strength(WorldGen.genRand.Next(3, 6))
                    .Steps(WorldGen.genRand.Next(2, 6))
                    .AndCave()
                .Generate();
        }
        else 
        {
            GenerationHelper.CreateCaveBiomeBuilder()
                .Biome(BEBiome.CaveInfectedMushroom)
                .Deepness(50)
                .IsUnderBEBiome()
                .DefaultCaveTileGenerationStep()
                    .GenerationId(GenerationHelper.MainGenerationId)
                    .TileType(ModContent.TileType<CorruptionInfectedMushroomStone>())
                    .AndCave()
                .DefaultCaveTileGenerationStep()
                    .GenerationId(GenerationHelper.WallGenerationId)
                    .TileType(ModContent.WallType<CorruptionInfectedMushroomWall>())
                    .AndCave()
                .OreGenerationStep()
                    .TileType(ModContent.TileType<CorruptoomOre>())
                    .Rarity(75)
                    .Strength(WorldGen.genRand.Next(3, 6))
                    .Steps(WorldGen.genRand.Next(2, 6))
                    .AndCave()
                .Generate();
        }
    }
}