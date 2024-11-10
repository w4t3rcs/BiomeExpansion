namespace BiomeExpansion.Content.Items.Placeable.Biome;

public class InfectedMushroomDirt : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["InfectedMushroomDirt"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Biome.InfectedMushroomDirt>());
        Item.width = 12;
        Item.height = 12;
    }
}