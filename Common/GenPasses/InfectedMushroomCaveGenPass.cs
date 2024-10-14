using BiomeExpansion.Common.Generation;
using BiomeExpansion.Content.Tiles;
using BiomeExpansion.Content.Walls;
using BiomeExpansion.Helpers;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace BiomeExpansion.Common.GenPasses;

public class InfectedMushroomCaveGenPass(string name, double loadWeight) : GenPass(name, loadWeight)
{
    protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
    { 
        progress.Message = "Generating Cave Infected Mushroom biome...";
        if (WorldGen.crimson)
        {
            GenerationHelper.CreateCaveBiomeBuilder()
                .Biome(BEBiome.InfectedMushroomCave)
                .Deepness(75)
                .IsUnderBEBiome()
                .AboveBiome(BEBiome.InfectedMushroomSurface)
                .DefaultCaveTileGenerationStep()
                    .GenerationId(GenerationHelper.MainGenerationId)
                    .TileType(ModContent.TileType<CrimsonInfectedMushroomStone>())
                    .AndCave()
                .DefaultCaveTileGenerationStep()
                    .GenerationId(GenerationHelper.WallGenerationId)
                    .TileType(ModContent.WallType<CrimsonInfectedMushroomCaveWall>())
                    .AndCave()
                .PlantGenerationStep()
                    .TileType(ModContent.TileType<CrimsonInfectedMushroomCaveTallGrass>())
                    .SoilTiles([(ushort)ModContent.TileType<CrimsonInfectedMushroomStone>()])
                    .Rarity(2)
                    .FrameCount(16)
                    .AndCave()
                .PlantGenerationStep()
                    .TileType(ModContent.TileType<CrimsonInfectedMushroomCaveVines>())
                    .SoilTiles([(ushort)ModContent.TileType<CrimsonInfectedMushroomStone>()])
                    .Rarity(4)
                    .IsHanging()
                    .AndCave()
                .PlantGenerationStep()
                    .TileType(ModContent.TileType<CrimsonInfectedMushroomCaveBulbVines>())
                    .SoilTiles([(ushort)ModContent.TileType<CrimsonInfectedMushroomStone>()])
                    .Rarity(4)
                    .IsHanging()
                    .AndCave()
                .PlantGenerationStep()
                    .TileType(ModContent.TileType<CrimsonInfectedMushroomCaveThorns>())
                    .SoilTiles([(ushort)ModContent.TileType<CrimsonInfectedMushroomStone>()])
                    .Rarity(6)
                    .IsBunch()
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
                .Biome(BEBiome.InfectedMushroomCave)
                .Deepness(75)
                .IsUnderBEBiome()
                .AboveBiome(BEBiome.InfectedMushroomSurface)
                .DefaultCaveTileGenerationStep()
                    .GenerationId(GenerationHelper.MainGenerationId)
                    .TileType(ModContent.TileType<CorruptionInfectedMushroomStone>())
                    .AndCave()
                .DefaultCaveTileGenerationStep()
                    .GenerationId(GenerationHelper.WallGenerationId)
                    .TileType(ModContent.WallType<CorruptionInfectedMushroomCaveWall>())
                    .AndCave()
                .PlantGenerationStep()
                    .TileType(ModContent.TileType<CorruptionInfectedMushroomCaveTallGrass>())
                    .SoilTiles([(ushort)ModContent.TileType<CorruptionInfectedMushroomStone>()])
                    .Rarity(2)
                    .FrameCount(16)
                    .AndCave()
                .PlantGenerationStep()
                    .TileType(ModContent.TileType<CorruptionInfectedMushroomCaveVines>())
                    .SoilTiles([(ushort)ModContent.TileType<CorruptionInfectedMushroomStone>()])
                    .Rarity(4)
                    .IsHanging()
                    .AndCave()
                .PlantGenerationStep()
                    .TileType(ModContent.TileType<CorruptionInfectedMushroomCaveBulbVines>())
                    .SoilTiles([(ushort)ModContent.TileType<CorruptionInfectedMushroomStone>()])
                    .Rarity(4)
                    .IsHanging()
                    .AndCave()
                .PlantGenerationStep()
                    .TileType(ModContent.TileType<CorruptionInfectedMushroomCaveThorns>())
                    .SoilTiles([(ushort)ModContent.TileType<CorruptionInfectedMushroomStone>()])
                    .Rarity(6)
                    .IsBunch()
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