namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class CrimsonInfectedDragonflyJar : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedDragonflyJar"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CrimsonInfectedDragonflyJar>());
        Item.width = 32;
        Item.height = 32;
    }
}