namespace BiomeExpansion.Core.Generation.Steps;

public class DefaultCaveTileGenerationStep
{
    public readonly GenerationHelper.CaveBiomeBuilder CaveBiomeBuilder;
    public int generationId { get; private set; } = -1;
    public int tileType { get; private set; }
    public ushort[] skippedTiles { get; private set; }

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