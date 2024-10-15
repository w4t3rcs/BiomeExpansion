using BiomeExpansion.Content.Tiles;
using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable;

public class CrimsonInfectedSmallMushroom : ModItem
{
    public override string Texture => TextureHelper.GetDynamicItemTexture("CrimsonInfectedSmallMushroom");
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<InfectedMushroomWood>());
        Item.width = 12;
        Item.height = 12;
    }
}