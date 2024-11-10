namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class InfectedMushroomWoodDresser : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["InfectedMushroomWoodDresser"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.InfectedMushroomWoodDresser>());
        Item.width = 40;
        Item.height = 24;
    }
}