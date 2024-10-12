using System.Collections.Generic;
using BiomeExpansion.Common.Generation;
using Terraria;

namespace BiomeExpansion.Helpers;

public class GenerationHelper
{
    public const int MainGenerationId = 0;
    public const int DirtGenerationId = 1;
    public const int GrassGenerationId = 2;
    public const int StoneGenerationId = 3;
    public const int WallGenerationId = 4;
    public static readonly Dictionary<BEBiome, KeyValuePair<int, int>> BEBiomesXCoordinates = new();
    public static readonly Dictionary<BEBiome, KeyValuePair<int, int>> BEBiomesYCoordinates = new();
    public static readonly int SurfaceY = Main.maxTilesY / 8;
    
    public static SurfaceBiomeBuilder CreateSurfaceBiomeBuilder() => new();
    
    public static CaveBiomeBuilder CreateCaveBiomeBuilder() => new();

    public static void Clear()
    {
        BEBiomesXCoordinates.Clear();
        BEBiomesYCoordinates.Clear();
    }
    
    public class SurfaceBiomeBuilder
    {
        public readonly List<DefaultSurfaceTileGenerationStep> DefaultSurfaceTileGenerationSteps = [];
        public readonly List<PlantGenerationStep> PlantGenerationSteps = [];
        public readonly List<OreGenerationStep> OreGenerationSteps = [];
        private BEBiome _biome;
        private bool _isNearEvil;
        private int _width;
        private int _height;
        
        public SurfaceBiomeBuilder Biome(BEBiome biome)
        {
            _biome = biome;
            return this;
        }

        public SurfaceBiomeBuilder IsNearEvil()
        {
            _isNearEvil = true;
            return this;
        }
        
        public SurfaceBiomeBuilder Width(int width)
        {
            _width = width;
            return this;
        }
        
        public SurfaceBiomeBuilder Height(int height)
        {
            _height = height;
            return this;
        }
        
        public DefaultSurfaceTileGenerationStep DefaultBiomeTileGenerationStep()
        {
            return new DefaultSurfaceTileGenerationStep(this);
        }
        
        public PlantGenerationStep PlantGenerationStep()
        {
            return new PlantGenerationStep(this);
        }
        
        public OreGenerationStep OreGenerationStep()
        {
            return new OreGenerationStep(this);
        }

        public void Generate()
        {
            DefaultSurfaceTileGenerationSteps.Sort((step1, step2) => step1.generationId - step2.generationId);
            if (_isNearEvil)
            {
                BiomeHelper.GenerateSurfaceBiomeNextToEvilBiome(_biome, _width, _height, 
                    (ushort)DefaultSurfaceTileGenerationSteps[0].tileType, 
                    (ushort)DefaultSurfaceTileGenerationSteps[1].tileType,
                    (ushort)DefaultSurfaceTileGenerationSteps[2].tileType,
                    (ushort)DefaultSurfaceTileGenerationSteps[3].tileType);
                foreach (PlantGenerationStep generationStep in PlantGenerationSteps)
                    PlantHelper.GeneratePlant(_biome, generationStep.rarity, (ushort)generationStep.tileType,
                        generationStep.soilTiles, generationStep.frameCount, generationStep.isHanging);
                foreach (OreGenerationStep generationStep in OreGenerationSteps)
                    OreHelper.GenerateOre(_biome, generationStep.rarity, 
                        generationStep.strength, generationStep.steps, (ushort)generationStep.tileType);
                DefaultSurfaceTileGenerationSteps.Clear();
                PlantGenerationSteps.Clear();
                OreGenerationSteps.Clear();
            }
        }
    }

    public class CaveBiomeBuilder
    {
        public readonly List<DefaultCaveTileGenerationStep> DefaultCaveTileGenerationSteps = [];
        public readonly List<PlantGenerationStep> PlantGenerationSteps = [];
        public readonly List<OreGenerationStep> OreGenerationSteps = [];
        private BEBiome _biome;
        private bool _isUnderBEBiome;
        private BEBiome _aboveBiome;
        private int _deepness;

        public CaveBiomeBuilder Biome(BEBiome biome)
        {
            _biome = biome;
            return this;
        }
        
        public CaveBiomeBuilder IsUnderBEBiome()
        {
            _isUnderBEBiome = true;
            return this;
        }
        
        public CaveBiomeBuilder AboveBiome(BEBiome aboveBiome)
        {
            _aboveBiome = aboveBiome;
            return this;
        }
        
        public CaveBiomeBuilder Deepness(int deepness)
        {
            _deepness = deepness;
            return this;
        }

        public DefaultCaveTileGenerationStep DefaultCaveTileGenerationStep()
        {
            return new DefaultCaveTileGenerationStep(this);
        }

        public PlantGenerationStep PlantGenerationStep()
        {
            return new PlantGenerationStep(this);
        }

        public OreGenerationStep OreGenerationStep()
        {
            return new OreGenerationStep(this);
        }

        public void Generate()
        {
            if (_isUnderBEBiome)
            {
                DefaultCaveTileGenerationSteps.Sort((step1, step2) => step1.generationId - step2.generationId);
                BiomeHelper.GenerateCaveBiomeUnderBEBiome(_biome, _aboveBiome, _deepness,
                    (ushort)DefaultCaveTileGenerationSteps[0].tileType,
                    (ushort)DefaultCaveTileGenerationSteps[1].tileType);
                foreach (PlantGenerationStep generationStep in PlantGenerationSteps)
                    PlantHelper.GeneratePlant(_biome, generationStep.rarity, (ushort)generationStep.tileType,
                        generationStep.soilTiles, generationStep.frameCount, generationStep.isHanging, generationStep.isBunch);
                foreach (OreGenerationStep generationStep in OreGenerationSteps)
                    OreHelper.GenerateOre(_biome, generationStep.rarity,
                        generationStep.strength, generationStep.steps, (ushort)generationStep.tileType);
                DefaultCaveTileGenerationSteps.Clear();
                PlantGenerationSteps.Clear();
                OreGenerationSteps.Clear();
            }
        }
    }
}