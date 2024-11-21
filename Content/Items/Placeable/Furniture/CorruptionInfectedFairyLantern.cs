namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class CorruptionInfectedFairyLantern : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedFairyLantern"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CorruptionInfectedFairyLantern>());
        Item.width = 14;
        Item.height = 32;
    }
}