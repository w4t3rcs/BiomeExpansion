using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Stones;

public class CrimsonInfectedMushroomStone : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedMushroomStone"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Stones.CrimsonInfectedMushroomStone>());
        Item.width = 12;
        Item.height = 12;
    }
}