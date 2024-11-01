using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class CorruptionInfectedMushroomWoodCandle : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedMushroomWoodCandle"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CorruptionInfectedMushroomWoodCandle>());
        Item.width = 14;
        Item.height = 18;
    }
}