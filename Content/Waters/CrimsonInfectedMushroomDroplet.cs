using BiomeExpansion.Helpers;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Waters;

public class CrimsonInfectedMushroomDroplet : ModGore
{
    public override string Texture => TextureHelper.GetDynamicWaterTexture("CrimsonInfectedMushroomDroplet");

    public override void SetStaticDefaults()
    { 
        ChildSafety.SafeGore[Type] = true; 
        GoreID.Sets.LiquidDroplet[Type] = true;
        UpdateType = GoreID.WaterDrip;
    }
}