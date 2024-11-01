using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class CrimsonInfectedMushroomWoodTable : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedMushroomWoodTable"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CrimsonInfectedMushroomWoodTable>());
        Item.width = 34;
        Item.height = 24;
    }
}