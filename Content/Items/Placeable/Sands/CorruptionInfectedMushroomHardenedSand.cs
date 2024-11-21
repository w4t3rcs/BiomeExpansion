namespace BiomeExpansion.Content.Items.Placeable.Sands;

public class CorruptionInfectedMushroomHardenedSand : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedMushroomHardenedSand"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Sands.CorruptionInfectedMushroomHardenedSand>());
        Item.width = 12;
        Item.height = 12;
    }
}