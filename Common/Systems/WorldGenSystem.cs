using System.Collections.Generic;
using BiomeExpansion.Common.Dtos;
using BiomeExpansion.Common.Utils;
using BiomeExpansion.Content.Tiles;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace BiomeExpansion.Common.Systems;

public class WorldGenSystem : ModSystem
{
    public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
    {
        int biomeGenIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Surface Ore and Stone"));
        if (biomeGenIndex != -1)
        {
            tasks.Insert(biomeGenIndex + 1, new PassLegacy("Infected Mushroom Biome", (progress, configuration) =>
            {
                BiomeUtil.GenerateBiomeNextToEvilBiome(progress, BEBiome.InfectedMushroom, 500, 20,
                    (ushort)ModContent.TileType<InfectedMushroomDirtBlock>(),
                    (ushort)ModContent.TileType<InfectedMushroomGrassBlock>(),
                    WorldGen.crimson ? TileID.Crimstone : TileID.Ebonstone);
                PlantUtil.GeneratePlant(BEBiome.InfectedMushroom, 90,
                    (ushort) ModContent.TileType<InfectedSmallMushroom>(), [(ushort) ModContent.TileType<InfectedMushroomGrassBlock>()]);
            }));
        }
    }
}