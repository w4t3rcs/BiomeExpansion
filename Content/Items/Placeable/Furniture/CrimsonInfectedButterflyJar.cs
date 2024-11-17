namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class CrimsonInfectedButterflyJar : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedButterflyJar"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CrimsonInfectedButterflyJar>());
        Item.width = 32;
        Item.height = 32;
    }
}