namespace BiomeExpansion.Content.Items.Placeable.Stones;

public class CorruptoomOre : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptoomOre"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Stones.CorruptoomOre>());
        Item.width = 12;
        Item.height = 12;
    }
}