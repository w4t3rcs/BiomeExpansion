using Terraria.ModLoader;

namespace BiomeExpansion.Backgrounds;

public class СorruptionInfectedMushroomSurfaceBiomeBGStyle : ModSurfaceBackgroundStyle
{
    public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
    {
        b -= 250f;
        return BackgroundTextureLoader.GetBackgroundSlot("BiomeExpansion/Assets/Backgrounds/CorruptionInfectedMushroomSurfaceBiomeClose");
    }

    public override void ModifyFarFades(float[] fades, float transitionSpeed)
    {
        for (int i = 0; i < fades.Length; i++)
        {
            if (i == Slot)
            {
                fades[i] += transitionSpeed;
                if (fades[i] > 1f)
                {
                    fades[i] = 1f;
                }
            }
            else
            {
                fades[i] -= transitionSpeed;
                if (fades[i] < 0f)
                {
                    fades[i] = 0f;
                }
            }
        }
    }
}