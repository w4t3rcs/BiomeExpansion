using BiomeExpansion.Core.Generation.Placers.Decorations;

namespace BiomeExpansion.Core.Generation.Steps;

public class GroundDecorationGenerationStep
{
    public readonly GenerationHelper.SurfaceBiomeBuilder SurfaceBiomeBuilder;
    public readonly GenerationHelper.CaveBiomeBuilder CaveBiomeBuilder;
    public ushort rarity { get; private set; } = 1;
    public int tileType { get; private set; }
    public sbyte frameCount { get; private set; } = 0;
    public ISurfaceDecorationPlacer decorationPlacer { get; private set; }

    public GroundDecorationGenerationStep(GenerationHelper.SurfaceBiomeBuilder surfaceBiomeBuilder)
    {
        SurfaceBiomeBuilder = surfaceBiomeBuilder;
    }

    public GroundDecorationGenerationStep(GenerationHelper.CaveBiomeBuilder caveBiomeBuilder)
    {
        CaveBiomeBuilder = caveBiomeBuilder;
    }

    public GroundDecorationGenerationStep Rarity(ushort rarity)
    {
        this.rarity = rarity;
        return this;
    }

    public GroundDecorationGenerationStep TileType(int tileType)
    {
        this.tileType = tileType;
        return this;
    }

    public GroundDecorationGenerationStep FrameCount(sbyte frameCount)
    {
        this.frameCount = frameCount;
        return this;
    }

    public GroundDecorationGenerationStep DecorationPlacer(ISurfaceDecorationPlacer decorationPlacer)
    {
        this.decorationPlacer = decorationPlacer;
        return this;
    }

    public GenerationHelper.SurfaceBiomeBuilder AndSurface()
    {
        SurfaceBiomeBuilder.GroundDecorationGenerationSteps.Add(this);
        return SurfaceBiomeBuilder;
    }

    public GenerationHelper.CaveBiomeBuilder AndCave()
    {
        CaveBiomeBuilder.GroundDecorationGenerationSteps.Add(this);
        return CaveBiomeBuilder;
    }
}