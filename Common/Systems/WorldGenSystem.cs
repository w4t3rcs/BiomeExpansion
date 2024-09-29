using System;
using System.Collections.Generic;
using System.Linq;
using BiomeExpansion.Content.Tiles;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace BiomeExpansion.Common.Systems;

public class WorldGenSystem : ModSystem
{
    public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
    {
        int terrainGenIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));

        if (terrainGenIndex != -1)
        {
            tasks.Insert(terrainGenIndex + 1, new PassLegacy("Test Biome", (progress, configuration) =>
                GenerateDefaultBiome(progress, configuration, 750, 20, 500, 
                    (ushort) ModContent.TileType<TestBlock>(), (ushort) ModContent.TileType<TestGrassBlock>())));
        }
    }

    private void GenerateDefaultBiome(GenerationProgress progress, GameConfiguration config, int biomeWidth, int biomeHeight, int minDistanceFromSpawn, ushort dirtBlock, ushort grassBlock)
    {
        progress.Message = "Generating custom biomes...";
        int startX;
        do
        {
            int worldGenPart = Main.maxTilesX / 4;
            startX = WorldGen.genRand.Next(worldGenPart, Main.maxTilesX - worldGenPart);
        } while (Math.Abs(startX - Main.spawnTileX) < minDistanceFromSpawn);
        int startY = 0;
        for (int i = startX; i < startX + biomeWidth; i++)
        {
            for (int j = startY; j < Main.worldSurface - 10 + biomeHeight; j++)
            {
                PlaceCustomBiomeBlock(i, j, startX, biomeWidth, startY, biomeHeight, [TileID.Dirt, TileID.ClayBlock, TileID.Stone], dirtBlock);
                PlaceCustomBiomeBlock(i, j, startX, biomeWidth, startY, biomeHeight, [TileID.Grass], grassBlock);
            }
        }
    }
    
    private void PlaceCustomBiomeBlock(int x, int y, int startX, int biomeWidth, int startY, int biomeHeight, ushort[] replacedTiles, ushort tileType)
    {
        int distanceToEdgeX = Math.Min(x - startX, startX + biomeWidth - x);
        int distanceToEdgeY = startY + biomeHeight - y;
        if (Main.tile[x, y].HasTile && replacedTiles.Contains(Main.tile[x, y].TileType))
        {
            if (distanceToEdgeX > 20 || distanceToEdgeY > 20)
            {
                Main.tile[x, y].TileType = tileType; 
            }
            else
            {
                if (WorldGen.genRand.NextFloat() < 0.5f)
                {
                    Main.tile[x, y].TileType = tileType;
                }
            }
        } 
    }
}