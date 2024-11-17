namespace BiomeExpansion.Content.Items.Placeable.Bricks;

public class CrimsonInfectedMushroomStoneBrick : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedMushroomStoneBrick"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Bricks.CrimsonInfectedMushroomStoneBrick>());
        Item.width = 12;
        Item.height = 12;
    }
}