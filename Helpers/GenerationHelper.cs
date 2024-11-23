using System.Collections.Generic;
using BiomeExpansion.Core.Generation;
using BiomeExpansion.Core.Generation.Cleaners;
using BiomeExpansion.Core.Generation.Locators;
using BiomeExpansion.Core.Generation.Modifications;
using BiomeExpansion.Core.Generation.Placers.Biomes;
using BiomeExpansion.Core.Generation.Placers.Decorations;
using BiomeExpansion.Core.Generation.Placers.Walls;
using BiomeExpansion.Core.Generation.Registrars;
using BiomeExpansion.Core.Generation.Steps;

namespace BiomeExpansion.Helpers;

public class GenerationHelper
{
    public const int MainGenerationId = 0;
    public const int DirtGenerationId = 1;
    public const int GrassGenerationId = 2;
    public const int StoneGenerationId = 3;
    public const int SandGenerationId = 4;
    public static readonly IBiomePlacer RectangleBiomePlacer = new RectangleBiomePlacer();
    public static readonly IGroundModification HorizontalTunnelModification = new HorizontalTunnelModification();
    public static readonly IGroundModification TwoDirectionDiagonalTunnelModification = new TwoDirectionDiagonalTunnelModification();
    public static readonly IWallPlacer SimpleWallPlacer = new SimpleWallPlacer();
    public static readonly IWallPlacer ForcedWallPlacer = new ForcedWallPlacer();
    public static readonly ISurfaceDecorationPlacer SimpleDecorationPlacer = new SimpleDecorationPlacer();
    public static readonly ISurfaceDecorationPlacer SimplePlantPlacer = new SimplePlantPlacer();
    public static readonly ISurfaceDecorationPlacer VinePlacer = new VinePlacer();
    public static readonly ISurfaceDecorationPlacer SeaOatsPlacer = new SeaOatsPlacer();
    public static readonly ISurfaceDecorationPlacer BunchPlacer = new BunchPlacer();
    public static readonly Dictionary<BEBiome, KeyValuePair<int, int>> BEBiomesXCoordinates = new();
    public static readonly Dictionary<BEBiome, KeyValuePair<int, int>> BEBiomesYCoordinates = new();
    private static readonly IBiomeRegistrar BiomeRegistrar = new BiomeRegistrar();
    private static readonly IBiomeLocator SurfaceBiomeLocator = new SurfaceBiomeLocator();
    private static readonly IDependentBiomeLocator DependentBiomeLocator = new DependentBiomeLocator();
    private static readonly ITileCleaner TileCleaner = new SimpleTileCleaner();
    
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
        public readonly List<WallGenerationStep> WallGenerationSteps = [];
        private BEBiome _biome;
        private bool _isNearEvil;
        private int _width;
        private int _height;
        private IGroundModification _groundModification;
        private IBiomePlacer _biomePlacer;
        private int[] _tilesToKill = [];
        
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

        public SurfaceBiomeBuilder BiomePlacer(IBiomePlacer biomePlacer)
        {
            _biomePlacer = biomePlacer;
            return this;
        }
        
        public SurfaceBiomeBuilder TilesToKill(int[] tilesToKill)
        {
            _tilesToKill = tilesToKill;
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

        public WallGenerationStep WallGenerationStep()
        {
            return new WallGenerationStep(this);
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
                _biomePlacer.Place(_biome, [
                    (ushort)DefaultSurfaceTileGenerationSteps[0].tileType, 
                    (ushort)DefaultSurfaceTileGenerationSteps[1].tileType,
                    (ushort)DefaultSurfaceTileGenerationSteps[2].tileType,
                    DefaultSurfaceTileGenerationSteps.Count > 3 ? (ushort)DefaultSurfaceTileGenerationSteps[3].tileType : (ushort)0,
                ]);
                foreach (GroundDecorationGenerationStep generationStep in GroundDecorationGenerationSteps)
                    generationStep.decorationPlacer.PlaceSurfaceDecoration(_biome, generationStep.rarity, (ushort)generationStep.tileType, generationStep.frameCount);
                foreach (OreGenerationStep generationStep in OreGenerationSteps)
                    OreHelper.GenerateOre(_biome, generationStep.rarity, 
                        generationStep.strength, generationStep.steps, (ushort)generationStep.tileType);
                foreach (WallGenerationStep generationStep in WallGenerationSteps)
                    generationStep.wallPlacer.PlaceWall(_biome, (ushort)generationStep.wallType, 
                        (ushort)generationStep.tileBehindWall, generationStep.replacedWall, generationStep.highPriorityWalls);
                TileCleaner.Clean(BEBiomesXCoordinates[_biome].Key, BEBiomesXCoordinates[_biome].Value, BEBiomesYCoordinates[_biome].Key, BEBiomesYCoordinates[_biome].Value, _tilesToKill);
                DefaultSurfaceTileGenerationSteps.Clear();
                GroundDecorationGenerationSteps.Clear();
                OreGenerationSteps.Clear();
                WallGenerationSteps.Clear();
            }
        }
    }

    public class CaveBiomeBuilder
    {
        public readonly List<DefaultCaveTileGenerationStep> DefaultCaveTileGenerationSteps = [];
        public readonly List<OreGenerationStep> OreGenerationSteps = [];
        public readonly List<GroundDecorationGenerationStep> GroundDecorationGenerationSteps = [];
        public readonly List<WallGenerationStep> WallGenerationSteps = [];
        private BEBiome _biome;
        private bool _isDependentBiome;
        private BEBiome _aboveBiome;
        private int _deepness;
        private IGroundModification _groundModification;
        private IBiomePlacer _biomePlacer;
        private int[] _tilesToKill = [];

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

        public CaveBiomeBuilder BiomePlacer(IBiomePlacer biomePlacer)
        {
            _biomePlacer = biomePlacer;
            return this;
        }

        public CaveBiomeBuilder TilesToKill(int[] tilesToKill)
        {
            _tilesToKill = tilesToKill;
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

        public WallGenerationStep WallGenerationStep()
        {
            return new WallGenerationStep(this);
        }

        public void Generate()
        {
            if (_isDependentBiome)
            {
                KeyValuePair<int,int> xCoordinates = DependentBiomeLocator.GetBiomeXCoordinates(_aboveBiome);
                KeyValuePair<int,int> yCoordinates = DependentBiomeLocator.GetBiomeYCoordinates(_aboveBiome, _deepness);
                BiomeRegistrar.Register(_biome, xCoordinates, yCoordinates);
                _groundModification?.Modify(BEBiomesXCoordinates[_biome].Key, BEBiomesXCoordinates[_biome].Value, BEBiomesYCoordinates[_biome].Key, BEBiomesYCoordinates[_biome].Value);
                _biomePlacer.PlaceOnlyWithMainTile(_biome, (ushort)DefaultCaveTileGenerationSteps[0].tileType);
                foreach (GroundDecorationGenerationStep generationStep in GroundDecorationGenerationSteps)
                    generationStep.decorationPlacer.PlaceSurfaceDecoration(_biome, generationStep.rarity, (ushort)generationStep.tileType, generationStep.frameCount);
                foreach (OreGenerationStep generationStep in OreGenerationSteps)
                    OreHelper.GenerateOre(_biome, generationStep.rarity, 
                        generationStep.strength, generationStep.steps, (ushort)generationStep.tileType);
                foreach (WallGenerationStep generationStep in WallGenerationSteps)
                    generationStep.wallPlacer.PlaceWall(_biome, (ushort)generationStep.wallType, 
                        (ushort)generationStep.tileBehindWall, generationStep.replacedWall, generationStep.highPriorityWalls);                
                TileCleaner.Clean(BEBiomesXCoordinates[_biome].Key, BEBiomesXCoordinates[_biome].Value, BEBiomesYCoordinates[_biome].Key, BEBiomesYCoordinates[_biome].Value, _tilesToKill);
                DefaultCaveTileGenerationSteps.Clear();
                GroundDecorationGenerationSteps.Clear();
                OreGenerationSteps.Clear();
                WallGenerationSteps.Clear();
            }
        }
    }
}