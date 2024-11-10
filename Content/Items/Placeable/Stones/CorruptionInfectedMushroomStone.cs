namespace BiomeExpansion.Content.Items.Placeable.Stones;

public class CorruptionInfectedMushroomStone : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedMushroomStone"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Stones.CorruptionInfectedMushroomStone>());
        Item.width = 12;
        Item.height = 12;
    }
}