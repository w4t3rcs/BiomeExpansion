namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class CorruptionInfectedButterflyJar : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedButterflyJar"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CorruptionInfectedButterflyJar>());
        Item.width = 32;
        Item.height = 32;
    }
}