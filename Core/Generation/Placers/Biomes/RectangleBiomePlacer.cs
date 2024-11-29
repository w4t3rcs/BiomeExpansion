using System;
using System.Collections.Generic;
using System.Linq;
using BiomeExpansion.Core.Generation.Steps;

namespace BiomeExpansion.Core.Generation.Placers.Biomes;

public class RectangleBiomePlacer : IBiomePlacer
{
    public void Place(BEBiome biome, List<TileGenerationStep> tileSteps, List<GroundDecorationGenerationStep> groundDecorationSteps, List<OreGenerationStep> oreSteps, List<WallGenerationStep> wallSteps)
    {
        var (leftX, rightX) = GenerationHelper.BEBiomesXCoordinates[biome];
        var (startY, endY) = GenerationHelper.BEBiomesYCoordinates[biome];
        for (int i = leftX; i < rightX; i++)
            GenerateBiomeVertically(i, startY, endY, tileSteps, oreSteps);
        for (int i = startY; i < endY; i++)
            GenerateBiomeTransition(i, leftX, rightX, tileSteps, oreSteps, wallSteps);
        for (int i = leftX; i < rightX; i++)
            FinalizeGeneration(i, startY, endY, groundDecorationSteps, wallSteps);
    }

    private void GenerateBiomeVertically(int x, int startY, int endY, List<TileGenerationStep> tileSteps, List<OreGenerationStep> oreSteps)
    {
        for (int y = startY; y < endY + Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); y++)
            ProcessGeneration(x, y, tileSteps, oreSteps);
    }

    private void GenerateBiomeTransition(int y, int leftX, int rightX, List<TileGenerationStep> tileSteps, List<OreGenerationStep> oreSteps, List<WallGenerationStep> wallSteps)
    {
        for (int x = leftX - Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); x < leftX; x++)
            ProcessGeneration(x, y, tileSteps, oreSteps, wallSteps);
        for (int x = rightX; x < rightX + Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); x++)
            ProcessGeneration(x, y, tileSteps, oreSteps, wallSteps);
    }

    private void FinalizeGeneration(int x, int startY, int endY, List<GroundDecorationGenerationStep> groundDecorationSteps, List<WallGenerationStep> wallSteps)
    {
        for (int y = startY; y < endY + Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); y++)
            ProcessFinalization(x, y, groundDecorationSteps, wallSteps);
    }

    private static void ProcessGeneration(int x, int y, List<TileGenerationStep> tileSteps, List<OreGenerationStep> oreSteps, List<WallGenerationStep> wallSteps)
    {
        ProcessGeneration(x, y, tileSteps, oreSteps);
        if (wallSteps != null)
            foreach (var wallStep in wallSteps)
                wallStep.wallPlacer.PlaceWall(x, y, (ushort)wallStep.wallType, (ushort)wallStep.tileBehindWall, wallStep.replacedWalls, wallStep.highPriorityWalls);
    }

    private static void ProcessGeneration(int x, int y, List<TileGenerationStep> tileSteps, List<OreGenerationStep> oreSteps)
    {
        if (tileSteps != null)
            foreach (var tileStep in tileSteps)
                tileStep.tilePlacer.PlaceTile(x, y, (ushort)tileStep.tileType, tileStep.additionalTileTypes);
        if (oreSteps != null)
            foreach (var oreStep in oreSteps)
                oreStep.orePlacer.PlaceOre(x, y, (ushort)oreStep.tileType, oreStep.rarity, oreStep.strength, oreStep.steps);
    }

    private static void ProcessFinalization(int x, int y, List<GroundDecorationGenerationStep> groundDecorationSteps, List<WallGenerationStep> wallSteps)
    {
        if (groundDecorationSteps != null)
            foreach (var groundDecorationStep in groundDecorationSteps)
            {
                bool isPlaced = groundDecorationStep.decorationPlacer.PlaceSurfaceDecoration(x, y, groundDecorationStep.rarity, (ushort)groundDecorationStep.tileType, groundDecorationStep.frameCount);
                if (isPlaced) break;
            }
        if (wallSteps != null)
            foreach (var wallStep in wallSteps)
                wallStep.wallPlacer.PlaceWall(x, y, (ushort)wallStep.wallType, (ushort)wallStep.tileBehindWall, wallStep.replacedWalls, wallStep.highPriorityWalls);
    }
}