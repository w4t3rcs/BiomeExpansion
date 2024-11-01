using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class InfectedMushroomWoodClock : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["InfectedMushroomWoodClock"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.InfectedMushroomWoodClock>());
        Item.width = 18;
        Item.height = 40;
    }
}