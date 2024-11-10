using Terraria.GameContent;

namespace BiomeExpansion.Content.Waters;

public class CorruptionInfectedMushroomDroplet : ModGore
{
    public override string Texture => TextureHelper.DynamicWatersTextures["CorruptionInfectedMushroomDroplet"];

    public override void SetStaticDefaults()
    { 
        ChildSafety.SafeGore[Type] = true; 
        GoreID.Sets.LiquidDroplet[Type] = true;
        UpdateType = GoreID.WaterDrip;
    }
}