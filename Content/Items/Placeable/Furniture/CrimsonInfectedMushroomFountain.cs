namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class CrimsonInfectedMushroomFountain : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["InfectedMushroomFountain"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CrimsonInfectedMushroomFountain>());
        Item.width = 32;
        Item.height = 64;
    }
}