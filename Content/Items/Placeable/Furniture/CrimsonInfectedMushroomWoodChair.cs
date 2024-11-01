using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class CrimsonInfectedMushroomWoodChair : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedMushroomWoodChair"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CrimsonInfectedMushroomWoodChair>());
        Item.width = 26;
        Item.height = 32;
    }
}