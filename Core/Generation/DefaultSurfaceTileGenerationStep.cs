namespace BiomeExpansion.Core.Generation;

public class DefaultSurfaceTileGenerationStep
{
    public GenerationHelper.SurfaceBiomeBuilder SurfaceBiomeBuilder;
    public int generationId = -1;
    public int tileType;
    public ushort[] replacedTiles;

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