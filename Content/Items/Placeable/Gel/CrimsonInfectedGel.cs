namespace BiomeExpansion.Content.Items.Placeable.Gel;

public class CrimsonInfectedGel : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedGel"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 25;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Gel.CrimsonInfectedGel>());
        Item.width = 12;
        Item.height = 12;
    }
}
