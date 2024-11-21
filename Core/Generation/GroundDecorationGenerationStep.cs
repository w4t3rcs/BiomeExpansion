namespace BiomeExpansion.Core.Generation;

public class GroundDecorationGenerationStep
{
    public readonly GenerationHelper.SurfaceBiomeBuilder SurfaceBiomeBuilder;
    public readonly GenerationHelper.CaveBiomeBuilder CaveBiomeBuilder;
    public ushort rarity {get; private set;} = 1;
    public int tileType {get; private set;}
    public ushort[] soilTiles {get; private set;} = [];
    public sbyte frameCount {get; private set;} = 0;
    public sbyte width {get; private set;} = 1;
    public sbyte height {get; private set;} = 1;
    public bool isPlant {get; private set;} = false;
    public bool isHanging {get; private set;} = false;
    public bool isBunch {get; private set;} = false;
    public bool isSeaOats {get; private set;} = false;
    public bool isLilyPad {get; private set;} = false;

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

    public GroundDecorationGenerationStep SoilTiles(ushort[] soilTiles)
    {
        this.soilTiles = soilTiles;
        return this;
    }

    public GroundDecorationGenerationStep FrameCount(sbyte frameCount)
    {
        this.frameCount = frameCount;
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

    public GroundDecorationGenerationStep IsPlant()
    {
        isPlant = true;
        return this;
    }

    public GroundDecorationGenerationStep IsHanging()
    {
        isHanging = true;
        return this;
    }

    public GroundDecorationGenerationStep IsBunch()
    {
        isBunch = true;
        return this;
    }

    public GroundDecorationGenerationStep IsSeaOats()
    {
        isSeaOats = true;
        return this;
    }

    public GroundDecorationGenerationStep IsLilyPad()
    {
        isLilyPad = true;
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