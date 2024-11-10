using ReLogic.Content;

namespace BiomeExpansion.Content.Waters;

public class CrimsonInfectedMushroomWaterStyle : ModWaterStyle
{
    public override string Texture => TextureHelper.DynamicWatersTextures["CrimsonInfectedMushroomWaterStyle"];
        
    public override int ChooseWaterfallStyle()
    {
        return ModContent.GetInstance<CrimsonInfectedMushroomWaterfallStyle>().Slot;
    }

    public override int GetSplashDust()
    {
        return DustID.Crimson;
    }

    public override int GetDropletGore()
    {
        return ModContent.GoreType<CrimsonInfectedMushroomDroplet>();
    }
        
    public override void LightColorMultiplier(ref float r, ref float g, ref float b)
    {
        r = 1;
        g = 1;
        b = 1;
    }

    public override Color BiomeHairColor()
    {
        return Color.Lerp(Color.Crimson, Color.DarkRed, 0.75f);
    }

    public override Asset<Texture2D> GetRainTexture()
    {
        return Mod.Assets.Request<Texture2D>("Assets/Rains/CrimsonInfectedMushroomRain");
    }

    public override byte GetRainVariant()
    {
        return (byte) Main.rand.Next(3);
    }
}