using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class InfectedMushroomWoodPlatform : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["InfectedMushroomWoodPlatform"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.InfectedMushroomWoodPlatform>());
        Item.width = 12;
        Item.height = 12;
    }
}