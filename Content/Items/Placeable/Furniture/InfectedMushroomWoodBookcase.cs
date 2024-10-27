using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class InfectedMushroomWoodBookcase : ModItem
{
    public override string Texture => TextureHelper.GetDynamicItemTexture("InfectedMushroomWoodBookcase");
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.InfectedMushroomWoodBookcase>());
        Item.width = 30;
        Item.height = 36;
    }
}