using BiomeExpansion.Core.Generation.Placers.Tiles;

namespace BiomeExpansion.Core.Generation.Steps;

public class TileGenerationStep
{
    public readonly GenerationHelper.SurfaceBiomeBuilder SurfaceBiomeBuilder;
    public readonly GenerationHelper.CaveBiomeBuilder CaveBiomeBuilder;
    public int tileType { get; private set; }
    public ITilePlacer tilePlacer { get; private set; }
    public ushort[] additionalTileTypes { get; private set; }

    public TileGenerationStep(GenerationHelper.SurfaceBiomeBuilder surfaceBiomeBuilder)
    {
        SurfaceBiomeBuilder = surfaceBiomeBuilder;
    }

    public TileGenerationStep(GenerationHelper.CaveBiomeBuilder caveBiomeBuilder)
    {
        CaveBiomeBuilder = caveBiomeBuilder;
    }

    public TileGenerationStep TileType(int tileType)
    {
        this.tileType = tileType;
        return this;
    }

    public TileGenerationStep TilePlacer(ITilePlacer tilePlacer)
    {
        this.tilePlacer = tilePlacer;
        return this;
    }

    public TileGenerationStep AdditionalTileTypes(ushort[] additionalTileTypes)
    {
        this.additionalTileTypes = additionalTileTypes;
        return this;
    }

    public GenerationHelper.SurfaceBiomeBuilder AndSurface()
    {
        SurfaceBiomeBuilder.TileGenerationSteps.Add(this);
        return SurfaceBiomeBuilder;
    }

    public GenerationHelper.CaveBiomeBuilder AndCave()
    {
        CaveBiomeBuilder.TileGenerationSteps.Add(this);
        return CaveBiomeBuilder;
    }
}