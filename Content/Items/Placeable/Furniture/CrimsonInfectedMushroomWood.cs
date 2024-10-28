using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class CrimsonInfectedMushroomWood : ModItem
{
    public override string Texture => TextureHelper.GetDynamicItemTexture("CrimsonInfectedMushroomWood");
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CrimsonInfectedMushroomWood>());
        Item.width = 24;
        Item.height = 22;
    }
}