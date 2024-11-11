namespace BiomeExpansion.Content.Items.Placeable.Gel;

public class CrimsonInfectedGelItem : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedGelItem"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 25;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Gel.CrimsonInfectedGelTile>());
        Item.width = 12;
        Item.height = 12;
    }
}
