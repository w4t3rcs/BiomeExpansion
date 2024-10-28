using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class CorruptionInfectedMushroomWoodLamp : ModItem
{
    public override string Texture => TextureHelper.GetDynamicItemTexture("CorruptionInfectedMushroomWoodLamp");
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CorruptionInfectedMushroomWoodLamp>());
        Item.width = 16;
        Item.height = 36;
    }
}