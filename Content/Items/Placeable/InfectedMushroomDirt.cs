using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable;

public class InfectedMushroomDirt : ModItem
{
    public override string Texture => TextureHelper.GetDynamicItemTexture("InfectedMushroomDirt");
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.InfectedMushroomDirt>());
        Item.width = 12;
        Item.height = 12;
    }
}