namespace BiomeExpansion.Core.Generation.Steps;

public class DefaultSurfaceTileGenerationStep
{
    public readonly GenerationHelper.SurfaceBiomeBuilder SurfaceBiomeBuilder;
    public int generationId { get; private set; } = 1;
    public int tileType { get; private set; }
    public ushort[] replacedTiles { get; private set; }

    public DefaultSurfaceTileGenerationStep(GenerationHelper.SurfaceBiomeBuilder surfaceBiomeBuilder)
    {
        SurfaceBiomeBuilder = surfaceBiomeBuilder;
    }

    public DefaultSurfaceTileGenerationStep GenerationId(int generationId)
    {
        this.generationId = generationId;
        return this;
    }

    public DefaultSurfaceTileGenerationStep TileType(int tileType)
    {
        this.tileType = tileType;
        return this;
    }

    public DefaultSurfaceTileGenerationStep ReplacedTiles(ushort[] replacedTiles)
    {
        this.replacedTiles = replacedTiles;
        return this;
    }

    public GenerationHelper.SurfaceBiomeBuilder AndSurface()
    {
        SurfaceBiomeBuilder.DefaultSurfaceTileGenerationSteps.Add(this);
        return SurfaceBiomeBuilder;
    }
}