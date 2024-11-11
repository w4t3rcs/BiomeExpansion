namespace BiomeExpansion.Content.Items.Placeable.Gel;

public class CorruptionInfectedGel : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedGel"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 25;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Gel.CorruptionInfectedGel>());
        Item.width = 12;
        Item.height = 12;
    }
}
