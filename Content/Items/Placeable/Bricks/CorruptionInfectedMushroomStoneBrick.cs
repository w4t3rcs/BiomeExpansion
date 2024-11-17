namespace BiomeExpansion.Content.Items.Placeable.Bricks;

public class CorruptionInfectedMushroomStoneBrick : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedMushroomStoneBrick"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Bricks.CorruptionInfectedMushroomStoneBrick>());
        Item.width = 12;
        Item.height = 12;
    }
}