using BiomeExpansion.Core.Generation.Placers.Ores;

namespace BiomeExpansion.Core.Generation.Steps;

public class OreGenerationStep
{
    public readonly GenerationHelper.SurfaceBiomeBuilder SurfaceBiomeBuilder;
    public readonly GenerationHelper.CaveBiomeBuilder CaveBiomeBuilder;
    public ushort rarity { get; private set; }
    public int tileType { get; private set; }
    public float strength { get; private set; }
    public int steps { get; private set; }
    public IOrePlacer orePlacer { get; private set; } = GenerationHelper.SimpleOrePlacer;

    public OreGenerationStep(GenerationHelper.SurfaceBiomeBuilder surfaceBiomeBuilder)
    {
        SurfaceBiomeBuilder = surfaceBiomeBuilder;
    }

    public OreGenerationStep(GenerationHelper.CaveBiomeBuilder caveBiomeBuilder)
    {
        CaveBiomeBuilder = caveBiomeBuilder;
    }

    public OreGenerationStep Rarity(ushort rarity)
    {
        this.rarity = rarity;
        return this;
    }

    public OreGenerationStep TileType(int tileType)
    {
        this.tileType = tileType;
        return this;
    }

    public OreGenerationStep Strength(float strength)
    {
        this.strength = strength;
        return this;
    }

    public OreGenerationStep Steps(int steps)
    {
        this.steps = steps;
        return this;
    }

    public OreGenerationStep OrePlacer(IOrePlacer orePlacer)
    {
        this.orePlacer = orePlacer;
        return this;
    }

    public GenerationHelper.SurfaceBiomeBuilder AndSurface()
    {
        SurfaceBiomeBuilder.OreGenerationSteps.Add(this);
        return SurfaceBiomeBuilder;
    }

    public GenerationHelper.CaveBiomeBuilder AndCave()
    {
        CaveBiomeBuilder.OreGenerationSteps.Add(this);
        return CaveBiomeBuilder;
    }
}