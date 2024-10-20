using System.Collections.Generic;
using BiomeExpansion.Common.Generation;

namespace BiomeExpansion.Helpers;

public class GenerationHelper
{
    public const int MainGenerationId = 0;
    public const int DirtGenerationId = 1;
    public const int GrassGenerationId = 2;
    public const int StoneGenerationId = 3;
    public const int WallGenerationId = 4;
    public static readonly IGroundModification HorizontalTunnelModification = new HorizontalTunnelModification();
    public static readonly Dictionary<BEBiome, KeyValuePair<int, int>> BEBiomesXCoordinates = new();
    public static readonly Dictionary<BEBiome, KeyValuePair<int, int>> BEBiomesYCoordinates = new();
    private static readonly IBiomeRegistrar BiomeRegistrar = new BiomeRegistrar();
    private static readonly IBiomeLocator SurfaceBiomeLocator = new SurfaceBiomeLocator();
    private static readonly IDependentBiomeLocator DependentBiomeLocator = new DependentBiomeLocator();
    
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
        public readonly List<OreGenerationStep> OreGenerationSteps = [];
        public readonly List<GroundDecorationGenerationStep> GroundDecorationGenerationSteps = [];
        private BEBiome _biome;
        private bool _isNearEvil;
        private int _width;
        private int _height;
        private IGroundModification _groundModification;
        
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
        
        public SurfaceBiomeBuilder GroundModification(IGroundModification groundModification)
        {
            _groundModification = groundModification;
            return this;
        }
        
        public DefaultSurfaceTileGenerationStep DefaultBiomeTileGenerationStep()
        {
            return new DefaultSurfaceTileGenerationStep(this);
        }
        
        public GroundDecorationGenerationStep GroundDecorationGenerationStep()
        {
            return new GroundDecorationGenerationStep(this);
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
                KeyValuePair<int,int> xCoordinates = SurfaceBiomeLocator.GetBiomeXCoordinates(_width, BiomeHelper.EvilGroundTiles);
                KeyValuePair<int,int> yCoordinates = SurfaceBiomeLocator.GetBiomeYCoordinates(_height);
                BiomeRegistrar.Register(_biome, xCoordinates, yCoordinates);
                _groundModification?.Modify(BEBiomesXCoordinates[_biome].Key, BEBiomesXCoordinates[_biome].Value, BEBiomesYCoordinates[_biome].Key, BEBiomesYCoordinates[_biome].Value);
                BiomeHelper.GenerateSurfaceBiome(_biome, 
                    (ushort)DefaultSurfaceTileGenerationSteps[0].tileType, 
                    (ushort)DefaultSurfaceTileGenerationSteps[1].tileType,
                    (ushort)DefaultSurfaceTileGenerationSteps[2].tileType,
                    (ushort)DefaultSurfaceTileGenerationSteps[3].tileType);
                foreach (GroundDecorationGenerationStep generationStep in GroundDecorationGenerationSteps)
                {
                    if (generationStep.isPlant)
                    {
                        PlantHelper.GeneratePlant(_biome, generationStep.rarity, (ushort)generationStep.tileType, generationStep.soilTiles, 
                            generationStep.frameCount, generationStep.width, generationStep.height, 
                            generationStep.isHanging, generationStep.isBunch, generationStep.isSeaOats, generationStep.isLilypad);
                    }
                    else
                    {
                        GroundDecorationHelper.GenerateGroundDecoration(_biome, generationStep.rarity, (ushort)generationStep.tileType,
                            generationStep.width, generationStep.height, generationStep.frameCount, generationStep.soilTiles);
                    }
                }
                foreach (OreGenerationStep generationStep in OreGenerationSteps)
                    OreHelper.GenerateOre(_biome, generationStep.rarity, 
                        generationStep.strength, generationStep.steps, (ushort)generationStep.tileType);
                DefaultSurfaceTileGenerationSteps.Clear();
                GroundDecorationGenerationSteps.Clear();
                OreGenerationSteps.Clear();
            }
        }
    }

    public class CaveBiomeBuilder
    {
        public readonly List<DefaultCaveTileGenerationStep> DefaultCaveTileGenerationSteps = [];
        public readonly List<OreGenerationStep> OreGenerationSteps = [];
        public readonly List<GroundDecorationGenerationStep> GroundDecorationGenerationSteps = [];
        private BEBiome _biome;
        private bool _isDependentBiome;
        private BEBiome _aboveBiome;
        private int _deepness;
        private IGroundModification _groundModification;

        public CaveBiomeBuilder Biome(BEBiome biome)
        {
            _biome = biome;
            return this;
        }
        
        public CaveBiomeBuilder IsDependentBiome()
        {
            _isDependentBiome = true;
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
        
        public CaveBiomeBuilder GroundModification(IGroundModification groundModification)
        {
            _groundModification = groundModification;
            return this;
        }

        public DefaultCaveTileGenerationStep DefaultCaveTileGenerationStep()
        {
            return new DefaultCaveTileGenerationStep(this);
        }
        
        public GroundDecorationGenerationStep GroundDecorationGenerationStep()
        {
            return new GroundDecorationGenerationStep(this);
        }
        
        public OreGenerationStep OreGenerationStep()
        {
            return new OreGenerationStep(this);
        }

        public void Generate()
        {
            if (_isDependentBiome)
            {
                KeyValuePair<int,int> xCoordinates = DependentBiomeLocator.GetBiomeXCoordinates(_aboveBiome);
                KeyValuePair<int,int> yCoordinates = DependentBiomeLocator.GetBiomeYCoordinates(_aboveBiome, _deepness);
                BiomeRegistrar.Register(_biome, xCoordinates, yCoordinates);
                _groundModification?.Modify(BEBiomesXCoordinates[_biome].Key, BEBiomesXCoordinates[_biome].Value, BEBiomesYCoordinates[_biome].Key, BEBiomesYCoordinates[_biome].Value);
                DefaultCaveTileGenerationSteps.Sort((step1, step2) => step1.generationId - step2.generationId);
                BiomeHelper.GenerateDependentCaveBiome(_biome,
                    (ushort)DefaultCaveTileGenerationSteps[0].tileType,
                    (ushort)DefaultCaveTileGenerationSteps[1].tileType);
                foreach (GroundDecorationGenerationStep generationStep in GroundDecorationGenerationSteps)
                {
                    if (generationStep.isPlant)
                    {
                        PlantHelper.GeneratePlant(_biome, generationStep.rarity, (ushort)generationStep.tileType, generationStep.soilTiles, 
                            generationStep.frameCount, generationStep.width, generationStep.height, 
                            generationStep.isHanging, generationStep.isBunch, generationStep.isSeaOats, generationStep.isLilypad);
                    }
                    else
                    {
                        GroundDecorationHelper.GenerateGroundDecoration(_biome, generationStep.rarity, (ushort)generationStep.tileType,
                            generationStep.width, generationStep.height, generationStep.frameCount, generationStep.soilTiles);
                    }
                }
                foreach (OreGenerationStep generationStep in OreGenerationSteps)
                    OreHelper.GenerateOre(_biome, generationStep.rarity, 
                        generationStep.strength, generationStep.steps, (ushort)generationStep.tileType);
                DefaultCaveTileGenerationSteps.Clear();
                GroundDecorationGenerationSteps.Clear();
                OreGenerationSteps.Clear();
            }
        }
    }
}