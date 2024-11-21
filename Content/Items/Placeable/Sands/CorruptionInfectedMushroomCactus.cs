namespace BiomeExpansion.Content.Items.Placeable.Sands;

public class CorruptionInfectedMushroomCactus : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedMushroomCactus"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Sands.CorruptionInfectedMushroomCactus>());
        Item.width = 12;
        Item.height = 12;
    }
}