using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Content.Tiles.Plants;
using BiomeExpansion.Content.Tiles.Sands;
using BiomeExpansion.Content.Tiles.Stones;
using BiomeExpansion.Content.Walls;
using BiomeExpansion.Core.Generation;
using BiomeExpansion.Helpers;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace BiomeExpansion.Common.GenPasses;

public class InfectedMushroomSurfaceGenPass(string name, double loadWeight) : GenPass(name, loadWeight)
{
    protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
    { 
        progress.Message = "Generating Surface Infected Mushroom biome...";
        var surfaceBiomeBuilder = GenerationHelper.CreateSurfaceBiomeBuilder()
            .Biome(BEBiome.InfectedMushroomSurface)
            .BiomePlacer(GenerationHelper.RectangleBiomePlacer)
            .Width(500)
            .Height(20)
            .IsNearEvil();
        if (!WorldGen.crimson)
        {
            surfaceBiomeBuilder = surfaceBiomeBuilder
                .DefaultBiomeTileGenerationStep()
                    .GenerationId(GenerationHelper.DirtGenerationId)
                    .TileType(ModContent.TileType<InfectedMushroomDirt>())
                    .AndSurface()
                .DefaultBiomeTileGenerationStep()
                    .GenerationId(GenerationHelper.GrassGenerationId)
                    .TileType(ModContent.TileType<CrimsonInfectedMushroomGrass>())
                    .AndSurface()
                .DefaultBiomeTileGenerationStep()
                    .GenerationId(GenerationHelper.SandGenerationId)
                    .TileType(ModContent.TileType<CrimsonInfectedMushroomSand>())
                    .AndSurface()
                .DefaultBiomeTileGenerationStep()
                    .GenerationId(GenerationHelper.StoneGenerationId)
                    .TileType(ModContent.TileType<CrimsonInfectedMushroomStone>())
                    .AndSurface()
                .WallGenerationStep()
                    .WallType(ModContent.WallType<CrimsonInfectedMushroomGrassWall>())
                    .WallPlacer(GenerationHelper.SimpleWallPlacer)
                    .AndSurface()
                .GroundDecorationGenerationStep()
                    .TileType(ModContent.TileType<CrimsonInfectedMushroomLyingStem>())
                    .Rarity(50)
                    .DecorationPlacer(GenerationHelper.SimpleDecorationPlacer)
                    .AndSurface()
                .GroundDecorationGenerationStep()
                    .TileType(ModContent.TileType<CrimsonInfectedMushroomRock>())
                    .Rarity(50)
                    .DecorationPlacer(GenerationHelper.SimpleDecorationPlacer)
                    .AndSurface()
                .GroundDecorationGenerationStep()
                    .TileType(ModContent.TileType<CrimsonInfectedMushroomOats>())
                    .Rarity(15)
                    .DecorationPlacer(GenerationHelper.SeaOatsPlacer)
                    .AndSurface()
                .GroundDecorationGenerationStep()
                    .TileType(ModContent.TileType<CrimsonInfectedSmallMushroom>())
                    .Rarity(3)
                    .DecorationPlacer(GenerationHelper.SimplePlantPlacer)
                    .FrameCount(5)
                    .AndSurface()
                .GroundDecorationGenerationStep()
                    .TileType(ModContent.TileType<CrimsonInfectedMushroomTallGrass>())
                    .Rarity(2)
                    .DecorationPlacer(GenerationHelper.SimplePlantPlacer)
                    .FrameCount(9)
                    .AndSurface()
                .GroundDecorationGenerationStep()
                    .TileType(ModContent.TileType<CrimsonInfectedMushroomVines>())
                    .Rarity(2)
                    .DecorationPlacer(GenerationHelper.VinePlacer)
                    .AndSurface();
        }
        else 
        {
            surfaceBiomeBuilder = surfaceBiomeBuilder
                .DefaultBiomeTileGenerationStep()
                    .GenerationId(GenerationHelper.DirtGenerationId)
                    .TileType(ModContent.TileType<InfectedMushroomDirt>())
                    .AndSurface()
                .DefaultBiomeTileGenerationStep()
                    .GenerationId(GenerationHelper.GrassGenerationId)
                    .TileType(ModContent.TileType<CorruptionInfectedMushroomGrass>())
                    .AndSurface()
                .DefaultBiomeTileGenerationStep()
                    .GenerationId(GenerationHelper.SandGenerationId)
                    .TileType(ModContent.TileType<CorruptionInfectedMushroomSand>())
                    .AndSurface()
                .DefaultBiomeTileGenerationStep()
                    .GenerationId(GenerationHelper.StoneGenerationId)
                    .TileType(ModContent.TileType<CorruptionInfectedMushroomStone>())
                    .AndSurface()
                .WallGenerationStep()
                    .WallType(ModContent.WallType<CorruptionInfectedMushroomGrassWall>())
                    .WallPlacer(GenerationHelper.SimpleWallPlacer)
                    .AndSurface()
                .GroundDecorationGenerationStep()
                    .TileType(ModContent.TileType<CorruptionInfectedMushroomLyingStem>())
                    .Rarity(50)
                    .DecorationPlacer(GenerationHelper.SimpleDecorationPlacer)
                    .AndSurface()
                .GroundDecorationGenerationStep()
                    .TileType(ModContent.TileType<CorruptionInfectedMushroomRock>())
                    .Rarity(50)
                    .DecorationPlacer(GenerationHelper.SimpleDecorationPlacer)
                    .AndSurface()
                .GroundDecorationGenerationStep()
                    .TileType(ModContent.TileType<CorruptionInfectedMushroomOats>())
                    .Rarity(15)
                    .DecorationPlacer(GenerationHelper.SeaOatsPlacer)
                    .AndSurface()
                .GroundDecorationGenerationStep()
                    .TileType(ModContent.TileType<CorruptionInfectedSmallMushroom>())
                    .Rarity(3)
                    .DecorationPlacer(GenerationHelper.SimplePlantPlacer)
                    .FrameCount(5)
                    .AndSurface()
                .GroundDecorationGenerationStep()
                    .TileType(ModContent.TileType<CorruptionInfectedMushroomTallGrass>())
                    .Rarity(2)
                    .DecorationPlacer(GenerationHelper.SimplePlantPlacer)
                    .FrameCount(9)
                    .AndSurface()
                .GroundDecorationGenerationStep()
                    .TileType(ModContent.TileType<CorruptionInfectedMushroomVines>())
                    .Rarity(2)
                    .DecorationPlacer(GenerationHelper.VinePlacer)
                    .AndSurface();
        }
        
        surfaceBiomeBuilder.Generate();
    }
}