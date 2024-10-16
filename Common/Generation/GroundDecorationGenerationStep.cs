using BiomeExpansion.Helpers;

namespace BiomeExpansion.Common.Generation;

public class GroundDecorationGenerationStep
{
    public GenerationHelper.SurfaceBiomeBuilder SurfaceBiomeBuilder;
    public GenerationHelper.CaveBiomeBuilder CaveBiomeBuilder;
    public sbyte rarity = 1;
    public int tileType;
    public sbyte width = 1;
    public sbyte height = 1;
    public sbyte frameCount = 0;
    public ushort[] allowedTiles = [];

    public GroundDecorationGenerationStep(GenerationHelper.SurfaceBiomeBuilder surfaceBiomeBuilder)
    {
        this.SurfaceBiomeBuilder = surfaceBiomeBuilder;
    }
    
    public GroundDecorationGenerationStep(GenerationHelper.CaveBiomeBuilder caveBiomeBuilder)
    {
        this.CaveBiomeBuilder = caveBiomeBuilder;
    }
    
    public GroundDecorationGenerationStep Rarity(sbyte rarity)
    {
        this.rarity = rarity;
        return this;
    }
    
    public GroundDecorationGenerationStep TileType(int tileType)
    {
        this.tileType = tileType;
        return this;
    }
    
    public GroundDecorationGenerationStep Width(sbyte width)
    {
        this.width = width;
        return this;
    }

    public GroundDecorationGenerationStep Height(sbyte height)
    {
        this.height = height;
        return this;
    }
    
    public GroundDecorationGenerationStep FrameCount(sbyte frameCount)
    {
        this.frameCount = frameCount;
        return this;
    }
    
    public GroundDecorationGenerationStep AllowedTiles(ushort[] allowedTiles)
    {
        this.allowedTiles = allowedTiles;
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