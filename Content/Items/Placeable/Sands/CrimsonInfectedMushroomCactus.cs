namespace BiomeExpansion.Content.Items.Placeable.Sands;

public class CrimsonInfectedMushroomCactus : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedMushroomCactus"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Sands.CrimsonInfectedMushroomCactus>());
        Item.width = 12;
        Item.height = 12;
    }
}