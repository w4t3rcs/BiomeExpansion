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
                GenerateDefaultBiome(progress, 500, 20, 
                    (ushort) ModContent.TileType<TestBlock>(), (ushort) ModContent.TileType<TestGrassBlock>())));
        }
    }

    private void GenerateDefaultBiome(GenerationProgress progress, int biomeWidth, int biomeHeight, ushort dirtBlock, ushort grassBlock)
    {
        progress.Message = "Generating BiomeExpansion biomes...";
        int nearbyBiomeRadius = biomeWidth / 4;
        int startX, startY = Main.maxTilesY / 8;
        do
        {
            int worldGenPart = Main.maxTilesX / 8;
            startX = WorldGen.genRand.Next(worldGenPart, Main.maxTilesX - worldGenPart);
        } while (!WorldUtil.IsNearCorruption(startX, startY, nearbyBiomeRadius) && !WorldUtil.IsNearCrimson(startX, startY, nearbyBiomeRadius));
        for (int i = startX; i < startX + biomeWidth; i++)
        {
            for (int j = startY; j < Main.worldSurface - 10 + biomeHeight; j++)
            {
                WorldUtil.ReplaceBlocks(i, j, startX, biomeWidth, startY, biomeHeight, [TileID.Dirt, TileID.ClayBlock, TileID.Stone], dirtBlock);
                WorldUtil.ReplaceBlocks(i, j, startX, biomeWidth, startY, biomeHeight, [TileID.Grass], grassBlock);
            }
        }
    }
    
    
}