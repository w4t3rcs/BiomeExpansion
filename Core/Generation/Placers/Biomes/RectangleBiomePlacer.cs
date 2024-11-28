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
            GenerateBiomeVertically(i, startY, endY, tileSteps, groundDecorationSteps, oreSteps, wallSteps);
        for (int i = startY; i < endY; i++)
            GenerateBiomeTransition(i, leftX, rightX, tileSteps, groundDecorationSteps, oreSteps, wallSteps);
    }

    private void GenerateBiomeVertically(int x, int startY, int endY, List<TileGenerationStep> tileSteps, List<GroundDecorationGenerationStep> groundDecorationSteps, List<OreGenerationStep> oreSteps, List<WallGenerationStep> wallSteps)
    {
        for (int y = startY; y < endY + Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); y++)
            ProcessGeneration(x, y, tileSteps, groundDecorationSteps, oreSteps, wallSteps);
    }

    private void GenerateBiomeTransition(int y, int leftX, int rightX, List<TileGenerationStep> tileSteps, List<GroundDecorationGenerationStep> groundDecorationSteps, List<OreGenerationStep> oreSteps, List<WallGenerationStep> wallSteps)
    {
        for (int x = leftX - Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); x < leftX; x++)
            ProcessGeneration(x, y, tileSteps, groundDecorationSteps, oreSteps, wallSteps);
        for (int x = rightX; x < rightX + Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); x++)
            ProcessGeneration(x, y, tileSteps, groundDecorationSteps, oreSteps, wallSteps);
    }

    private static void ProcessGeneration(int x, int y, List<TileGenerationStep> tileSteps, List<GroundDecorationGenerationStep> groundDecorationSteps, List<OreGenerationStep> oreSteps, List<WallGenerationStep> wallSteps)
    {
        if (tileSteps != null)
            foreach (var tileStep in tileSteps)
                tileStep.tilePlacer.PlaceTile(x, y, (ushort)tileStep.tileType, tileStep.additionalTileTypes);
        if (groundDecorationSteps != null)
            foreach (var groundDecorationStep in groundDecorationSteps)
                groundDecorationStep.decorationPlacer.PlaceSurfaceDecoration(x, y, groundDecorationStep.rarity, (ushort)groundDecorationStep.tileType, groundDecorationStep.frameCount);
        if (oreSteps != null)
            foreach (var oreStep in oreSteps)
                oreStep.orePlacer.PlaceOre(x, y, (ushort)oreStep.tileType, oreStep.rarity, oreStep.strength, oreStep.steps);
        if (wallSteps != null)
            foreach (var wallStep in wallSteps)
                wallStep.wallPlacer.PlaceWall(x, y, (ushort)wallStep.wallType, (ushort)wallStep.tileBehindWall, wallStep.replacedWalls, wallStep.highPriorityWalls);
    }
}