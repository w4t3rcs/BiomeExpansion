using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class InfectedMushroomWoodSink : ModItem
{
    public override string Texture => TextureHelper.GetDynamicItemTexture("InfectedMushroomWoodSink");
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.InfectedMushroomWoodSink>());
        Item.width = 32;
        Item.height = 26;
    }
}