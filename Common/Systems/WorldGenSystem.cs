using System.Collections.Generic;
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
        int biomeGenIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Guide"));

        if (biomeGenIndex != -1)
        {
            tasks.Insert(biomeGenIndex + 1, new PassLegacy("Infected Mushroom Biome", (progress, configuration) =>
                WorldUtil.GenerateBiomeNextToEvilBiome(progress, 500, 20, 
                    (ushort) ModContent.TileType<TestBlock>(), 
                    (ushort) ModContent.TileType<TestGrassBlock>(), 
                    WorldGen.crimson ? TileID.Crimstone : TileID.Ebonstone)));
        }
    }
}