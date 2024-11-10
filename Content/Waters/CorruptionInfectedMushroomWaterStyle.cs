using ReLogic.Content;

namespace BiomeExpansion.Content.Waters;

public class CorruptionInfectedMushroomWaterStyle : ModWaterStyle
{
    public override string Texture => TextureHelper.DynamicWatersTextures["CorruptionInfectedMushroomWaterStyle"];

    public override int ChooseWaterfallStyle()
    {
        return ModContent.GetInstance<CorruptionInfectedMushroomWaterfallStyle>().Slot;
    }

    public override int GetSplashDust()
    {
        return DustID.Corruption;
    }

    public override int GetDropletGore()
    {
        return ModContent.GoreType<CorruptionInfectedMushroomDroplet>();
    }
        
    public override void LightColorMultiplier(ref float r, ref float g, ref float b)
    {
        r = 1;
        g = 1;
        b = 1;
    }

    public override Color BiomeHairColor()
    {
        return Color.White;
    }

    public override Asset<Texture2D> GetRainTexture()
    {
        return Mod.Assets.Request<Texture2D>("Assets/Rains/CorruptionInfectedMushroomRain");
    }

    public override byte GetRainVariant()
    {
        return (byte) Main.rand.Next(3);
    }
}