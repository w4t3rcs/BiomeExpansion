using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class CrimsonInfectedMushroomWoodBench : ModItem
{
    public override string Texture => TextureHelper.GetDynamicItemTexture("CrimsonInfectedMushroomWoodBench");
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CrimsonInfectedMushroomWoodBench>());
        Item.width = 38;
        Item.height = 26;
    }
}