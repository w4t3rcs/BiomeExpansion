using Terraria.GameContent;

namespace BiomeExpansion.Content.Waters;

public class CrimsonInfectedMushroomDroplet : ModGore
{
    public override string Texture => TextureHelper.DynamicWatersTextures["CrimsonInfectedMushroomDroplet"];

    public override void SetStaticDefaults()
    { 
        ChildSafety.SafeGore[Type] = true; 
        GoreID.Sets.LiquidDroplet[Type] = true;
        UpdateType = GoreID.WaterDrip;
    }
}