using BiomeExpansion.Common.Generation;
using BiomeExpansion.Content.Tiles;
using BiomeExpansion.Content.Walls;
using BiomeExpansion.Helpers;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace BiomeExpansion.Common.GenPasses;

public class SurfaceInfectedMushroomGenPass(string name, double loadWeight) : GenPass(name, loadWeight)
{
    protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
    { 
        progress.Message = "Generating Surface Infected Mushroom biome...";
        if (WorldGen.crimson)
        {
            GenerationHelper.CreateSurfaceBiomeBuilder()
                .Biome(BEBiome.SurfaceInfectedMushroom)
                .Width(500)
                .Height(20)
                .IsNearEvil()
                .DefaultBiomeTileGenerationStep()
                    .GenerationId(GenerationHelper.DirtGenerationId)
                    .TileType(ModContent.TileType<InfectedMushroomDirt>())
                    .AndSurface()
                .DefaultBiomeTileGenerationStep()
                    .GenerationId(GenerationHelper.GrassGenerationId)
                    .TileType(ModContent.TileType<CrimsonInfectedMushroomGrass>())
                    .AndSurface()
                .DefaultBiomeTileGenerationStep()
                    .GenerationId(GenerationHelper.StoneGenerationId)
                    .TileType(ModContent.TileType<CrimsonInfectedMushroomStone>())
                    .AndSurface()
                .DefaultBiomeTileGenerationStep()
                    .GenerationId(GenerationHelper.WallGenerationId)
                    .TileType(ModContent.WallType<CrimsonInfectedMushroomWall>())
                    .AndSurface()
                .PlantGenerationStep()
                    .TileType(ModContent.TileType<CrimsonInfectedSmallMushroom>())
                    .SoilTiles([(ushort)ModContent.TileType<CrimsonInfectedMushroomGrass>()])
                    .Rarity(3)
                    .FrameCount(5)
                    .AndSurface()
                .PlantGenerationStep()
                    .TileType(ModContent.TileType<CrimsonInfectedMushroomTallGrass>())
                    .SoilTiles([(ushort)ModContent.TileType<CrimsonInfectedMushroomGrass>()])
                    .Rarity(2)
                    .FrameCount(9)
                    .AndSurface()
                .PlantGenerationStep()
                    .TileType(ModContent.TileType<CrimsonInfectedMushroomVine>())
                    .SoilTiles([(ushort)ModContent.TileType<CrimsonInfectedMushroomGrass>()])
                    .Rarity(2)
                    .IsHanging()
                    .AndSurface()
                .Generate();
        }
        else 
        {
            GenerationHelper.CreateSurfaceBiomeBuilder()
                .Biome(BEBiome.SurfaceInfectedMushroom)
                .Width(500)
                .Height(20)
                .IsNearEvil()
                .DefaultBiomeTileGenerationStep()
                    .GenerationId(GenerationHelper.DirtGenerationId)
                    .TileType(ModContent.TileType<InfectedMushroomDirt>())
                    .AndSurface()
                .DefaultBiomeTileGenerationStep()
                    .GenerationId(GenerationHelper.GrassGenerationId)
                    .TileType(ModContent.TileType<CorruptionInfectedMushroomGrass>())
                    .AndSurface()
                .DefaultBiomeTileGenerationStep()
                    .GenerationId(GenerationHelper.StoneGenerationId)
                    .TileType(ModContent.TileType<CorruptionInfectedMushroomStone>())
                    .AndSurface()
                .DefaultBiomeTileGenerationStep()
                    .GenerationId(GenerationHelper.WallGenerationId)
                    .TileType(ModContent.WallType<CorruptionInfectedMushroomWall>())
                    .AndSurface()
                .PlantGenerationStep()
                    .TileType(ModContent.TileType<CorruptionInfectedSmallMushroom>())
                    .SoilTiles([(ushort)ModContent.TileType<CorruptionInfectedMushroomGrass>()])
                    .Rarity(3)
                    .FrameCount(5)
                    .AndSurface()
                .PlantGenerationStep()
                    .TileType(ModContent.TileType<CorruptionInfectedMushroomTallGrass>())
                    .SoilTiles([(ushort)ModContent.TileType<CorruptionInfectedMushroomGrass>()])
                    .Rarity(2)
                    .FrameCount(9)
                    .AndSurface()
                .PlantGenerationStep()
                    .TileType(ModContent.TileType<CorruptionInfectedMushroomVine>())
                    .SoilTiles([(ushort)ModContent.TileType<CorruptionInfectedMushroomGrass>()])
                    .Rarity(2)
                    .IsHanging()
                    .AndSurface()
                .Generate();
        }
    }
}