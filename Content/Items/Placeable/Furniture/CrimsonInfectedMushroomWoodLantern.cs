using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class CrimsonInfectedMushroomWoodLantern : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedMushroomWoodLantern"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CrimsonInfectedMushroomWoodLantern>());
        Item.width = 14;
        Item.height = 30;
    }
}