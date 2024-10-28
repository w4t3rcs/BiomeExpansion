using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class CrimsonInfectedMushroomWoodBath : ModItem
{
    public override string Texture => TextureHelper.GetDynamicItemTexture("CrimsonInfectedMushroomWoodBath");
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CrimsonInfectedMushroomWoodBath>());
        Item.width = 34;
        Item.height = 16;
    }
}