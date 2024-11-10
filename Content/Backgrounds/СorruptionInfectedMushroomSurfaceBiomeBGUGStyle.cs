namespace BiomeExpansion.Content.Backgrounds;

public class СorruptionInfectedMushroomSurfaceBiomeBGUGStyle : ModUndergroundBackgroundStyle
{ 
    private const string Texture = "BiomeExpansion/Assets/Backgrounds/CorruptionInfectedMushroomSurfaceBiomeUG";

    public override void FillTextureArray(int[] textureSlots)
    {
        for (int i = 0; i < 4; i++)
        {
            textureSlots[i] = BackgroundTextureLoader.GetBackgroundSlot(Texture + i);
        }
    }
}