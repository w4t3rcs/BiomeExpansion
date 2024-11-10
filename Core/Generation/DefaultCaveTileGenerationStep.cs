namespace BiomeExpansion.Core.Generation;

public class DefaultCaveTileGenerationStep
{
    public GenerationHelper.CaveBiomeBuilder CaveBiomeBuilder;
    public int generationId = -1;
    public int tileType;
    public ushort[] skippedTiles;

    public DefaultCaveTileGenerationStep(GenerationHelper.CaveBiomeBuilder caveBiomeBuilder)
    {
        CaveBiomeBuilder = caveBiomeBuilder;
    }

    public DefaultCaveTileGenerationStep GenerationId(int generationId)
    {
        this.generationId = generationId;
        return this;
    }

    public DefaultCaveTileGenerationStep TileType(int tileType)
    {
        this.tileType = tileType;
        return this;
    }

    public DefaultCaveTileGenerationStep SkippedTiles(ushort[] skippedTiles)
    {
        this.skippedTiles = skippedTiles;
        return this;
    }

    public GenerationHelper.CaveBiomeBuilder AndCave()
    {
        CaveBiomeBuilder.DefaultCaveTileGenerationSteps.Add(this);
        return CaveBiomeBuilder;
    }
}