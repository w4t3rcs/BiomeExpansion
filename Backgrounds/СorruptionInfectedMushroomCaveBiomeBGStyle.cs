using Terraria.ModLoader;

namespace BiomeExpansion.Backgrounds;

public class СorruptionInfectedMushroomCaveBiomeBGStyle : ModUndergroundBackgroundStyle
{ 
    private const string Texture = "BiomeExpansion/Assets/Backgrounds/CorruptionInfectedMushroomCaveBiome";

    public override void FillTextureArray(int[] textureSlots)
    {
        textureSlots[0] = BackgroundTextureLoader.GetBackgroundSlot(Texture);
    }
}