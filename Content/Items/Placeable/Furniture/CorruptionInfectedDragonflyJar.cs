namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class CorruptionInfectedDragonflyJar : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedDragonflyJar"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CorruptionInfectedDragonflyJar>());
        Item.width = 32;
        Item.height = 32;
    }
}