using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Stones;

public class CrimsonInfectedMushroomOldStone : ModItem
{
    public override string Texture => TextureHelper.GetDynamicItemTexture("CrimsonInfectedMushroomOldStone");
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Stones.CrimsonInfectedMushroomOldStone>());
        Item.width = 12;
        Item.height = 12;
    }
}