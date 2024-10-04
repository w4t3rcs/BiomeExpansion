using BiomeExpansion.Common.Utils;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Biomes;

public class InfectedMushroomDroplet : ModGore
{
    public override string Texture => TextureUtil.GetDynamicTexture("InfectedMushroomDroplet");

    public override void SetStaticDefaults()
    { 
        ChildSafety.SafeGore[Type] = true; 
        GoreID.Sets.LiquidDroplet[Type] = true;
        UpdateType = GoreID.WaterDrip;
    }
}