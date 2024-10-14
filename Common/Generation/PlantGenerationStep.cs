using BiomeExpansion.Helpers;
using Terraria.ID;

namespace BiomeExpansion.Common.Generation;

public class PlantGenerationStep
{
    public GenerationHelper.SurfaceBiomeBuilder SurfaceBiomeBuilder;
    public GenerationHelper.CaveBiomeBuilder CaveBiomeBuilder;
    public sbyte rarity = 1;
    public int tileType;
    public ushort[] soilTiles = [TileID.Grass];
    public sbyte frameCount = 0;
    public bool isHanging = false;
    public bool isBunch = false;

    public PlantGenerationStep(GenerationHelper.SurfaceBiomeBuilder surfaceBiomeBuilder)
    {
        this.SurfaceBiomeBuilder = surfaceBiomeBuilder;
    }
    
    public PlantGenerationStep(GenerationHelper.CaveBiomeBuilder caveBiomeBuilder)
    {
        this.CaveBiomeBuilder = caveBiomeBuilder;
    }
    
    public PlantGenerationStep Rarity(sbyte rarity)
    {
        this.rarity = rarity;
        return this;
    }
    
    public PlantGenerationStep TileType(int tileType)
    {
        this.tileType = tileType;
        return this;
    }
    
    public PlantGenerationStep SoilTiles(ushort[] soilTiles)
    {
        this.soilTiles = soilTiles;
        return this;
    }

    public PlantGenerationStep FrameCount(sbyte frameCount)
    {
        this.frameCount = frameCount;
        return this;
    }
    
    public PlantGenerationStep IsHanging()
    {
        this.isHanging = true;
        return this;
    }
    
    public PlantGenerationStep IsBunch()
    {
        this.isBunch = true;
        return this;
    }


    public GenerationHelper.SurfaceBiomeBuilder AndSurface()
    {
        SurfaceBiomeBuilder.PlantGenerationSteps.Add(this);
        return SurfaceBiomeBuilder;
    }
    
    public GenerationHelper.CaveBiomeBuilder AndCave()
    {
        CaveBiomeBuilder.PlantGenerationSteps.Add(this);
        return CaveBiomeBuilder;
    }
}