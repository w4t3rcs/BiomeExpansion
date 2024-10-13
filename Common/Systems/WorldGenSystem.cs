using System.Collections.Generic;
using BiomeExpansion.Common.GenPasses;
using BiomeExpansion.Helpers;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace BiomeExpansion.Common.Systems;

public class WorldGenSystem : ModSystem
{
    public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
    {
        int biomeGenIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Quick Cleanup"));
        if (biomeGenIndex != -1)
        {
            tasks.Insert(++biomeGenIndex, new InfectedMushroomSurfaceGenPass("Surface Infected Mushroom Biome", 100f));
            tasks.Insert(++biomeGenIndex, new InfectedMushroomCaveGenPass("Cave Infected Mushroom Biome", 100f));
            GenerationHelper.Clear();
        }
    }
}