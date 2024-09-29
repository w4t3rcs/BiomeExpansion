using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable;

public class TestBlock : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.TestBlock>());
        Item.width = 12;
        Item.height = 12;
    }
}