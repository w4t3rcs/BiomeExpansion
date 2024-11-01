using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class CorruptionInfectedMushroomWoodBench : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedMushroomWoodBench"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CorruptionInfectedMushroomWoodBench>());
        Item.width = 38;
        Item.height = 26;
    }
}