namespace BiomeExpansion.Content.Items.Placeable.Sands;

public class CrimsonInfectedMushroomHardenedSand : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedMushroomHardenedSand"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Sands.CrimsonInfectedMushroomHardenedSand>());
        Item.width = 12;
        Item.height = 12;
    }
}