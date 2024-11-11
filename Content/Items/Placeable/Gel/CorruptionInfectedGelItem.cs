namespace BiomeExpansion.Content.Items.Placeable.Gel;

public class CorruptionInfectedGelItem : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedGelItem"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 25;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Gel.CorruptionInfectedGelTile>());
        Item.width = 12;
        Item.height = 12;
    }
}
