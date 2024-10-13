using BiomeExpansion.Helpers;

namespace BiomeExpansion.Common.Generation;

public class OreGenerationStep
{
    public GenerationHelper.SurfaceBiomeBuilder SurfaceBiomeBuilder;
    public GenerationHelper.CaveBiomeBuilder CaveBiomeBuilder;
    public sbyte rarity;
    public int tileType;
    public float strength;
    public int steps;

    public OreGenerationStep(GenerationHelper.SurfaceBiomeBuilder surfaceBiomeBuilder)
    {
        this.SurfaceBiomeBuilder = surfaceBiomeBuilder;
    }
    
    public OreGenerationStep(GenerationHelper.CaveBiomeBuilder caveBiomeBuilder)
    {
        this.CaveBiomeBuilder = caveBiomeBuilder;
    }
    
    public OreGenerationStep Rarity(sbyte rarity)
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