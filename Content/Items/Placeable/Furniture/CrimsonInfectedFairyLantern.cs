namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class CrimsonInfectedFairyLantern : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedFairyLantern"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CrimsonInfectedFairyLantern>());
        Item.width = 14;
        Item.height = 32;
    }
}