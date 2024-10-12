using Terraria.ModLoader;

namespace BiomeExpansion.Backgrounds;

public class СrimsonInfectedMushroomCaveBiomeBGStyle : ModUndergroundBackgroundStyle
{ 
    private const string Texture = "BiomeExpansion/Assets/Backgrounds/CrimsonInfectedMushroomCaveBiome";

    public override void FillTextureArray(int[] textureSlots)
    {
        textureSlots[0] = BackgroundTextureLoader.GetBackgroundSlot(Texture);
    }
}