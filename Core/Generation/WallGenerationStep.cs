namespace BiomeExpansion.Core.Generation;

public class WallGenerationStep
{
    public readonly GenerationHelper.SurfaceBiomeBuilder SurfaceBiomeBuilder;
    public readonly GenerationHelper.CaveBiomeBuilder CaveBiomeBuilder;
    public int wallType { get; private set; }
    public int tileBehindWall { get; private set; } = 0;
    public int[] replacedWall { get; private set; } = [];
    public int[] highPriorityWalls { get; private set; } = [];
    public IWallPlacer wallPlacer { get; private set; }


    public WallGenerationStep(GenerationHelper.SurfaceBiomeBuilder surfaceBiomeBuilder)
    {
        SurfaceBiomeBuilder = surfaceBiomeBuilder;
    }

    public WallGenerationStep(GenerationHelper.CaveBiomeBuilder caveBiomeBuilder)
    {
        CaveBiomeBuilder = caveBiomeBuilder;
    }

    public WallGenerationStep WallType(int wallType)
    {
        this.wallType = wallType;
        return this;
    }

    public WallGenerationStep HighPriorityWalls(int[] highPriorityWalls)
    {
        this.highPriorityWalls = highPriorityWalls;
        return this;
    }

    public WallGenerationStep TileBehindWall(int tileBehindWall)
    {
        this.tileBehindWall = tileBehindWall;
        return this;
    }

    public WallGenerationStep ReplacedWalls(int[] replacedWall)
    {
        this.replacedWall = replacedWall;
        return this;
    }

    public WallGenerationStep WallPlacer(IWallPlacer wallPlacer)
    {
        this.wallPlacer = wallPlacer;
        return this;
    }

    public GenerationHelper.SurfaceBiomeBuilder AndSurface()
    {
        SurfaceBiomeBuilder.WallGenerationSteps.Add(this);
        return SurfaceBiomeBuilder;
    }

    public GenerationHelper.CaveBiomeBuilder AndCave()
    {
        CaveBiomeBuilder.WallGenerationSteps.Add(this);
        return CaveBiomeBuilder;
    }
}