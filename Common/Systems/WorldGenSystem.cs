using System.Collections.Generic;
using BiomeExpansion.Common.Dtos;
using BiomeExpansion.Content.Tiles;
using BiomeExpansion.Content.Walls;
using BiomeExpansion.Helpers;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace BiomeExpansion.Common.Systems;

public class WorldGenSystem : ModSystem
{
    public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
    {
        int biomeGenIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Clean Up Dirt"));
        if (biomeGenIndex != -1)
        {
            tasks.Insert(biomeGenIndex + 1, new PassLegacy("Infected Mushroom Biome", (progress, configuration) =>
            {
                BiomeHelper.GenerateBiomeNextToEvilBiome(progress, BEBiome.InfectedMushroom, 500, 20,
                    (ushort)ModContent.TileType<InfectedMushroomDirt>(),
                    WorldGen.crimson ? (ushort)ModContent.TileType<CrimsonInfectedMushroomGrass>() : (ushort)ModContent.TileType<CorruptionInfectedMushroomGrass>(),
                    WorldGen.crimson ? (ushort)ModContent.WallType<CrimsonInfectedMushroomWall>() : (ushort)ModContent.WallType<CorruptionInfectedMushroomWall>());
                PlantHelper.GeneratePlant(BEBiome.InfectedMushroom, 6,
                    WorldGen.crimson ? (ushort)ModContent.TileType<CrimsonInfectedSmallMushroom>() : (ushort)ModContent.TileType<CorruptionInfectedSmallMushroom>(), 
                    WorldGen.crimson ? [(ushort)ModContent.TileType<CrimsonInfectedMushroomGrass>()] : [(ushort)ModContent.TileType<CorruptionInfectedMushroomGrass>()]);
                PlantHelper.GeneratePlant(BEBiome.InfectedMushroom, 3,
                    WorldGen.crimson ? (ushort)ModContent.TileType<CrimsonInfectedMushroomTallGrass>() : (ushort)ModContent.TileType<CorruptionInfectedMushroomTallGrass>(),
                    WorldGen.crimson ? [(ushort)ModContent.TileType<CrimsonInfectedMushroomGrass>()] : [(ushort)ModContent.TileType<CorruptionInfectedMushroomGrass>()]);
                BiomeHelper.BEBiomesXCoordinates.Remove(BEBiome.InfectedMushroom);
            }));
        }
    }
}