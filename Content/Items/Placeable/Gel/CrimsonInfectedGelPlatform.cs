namespace BiomeExpansion.Content.Items.Placeable.Gel;

public class CrimsonInfectedGelPlatform : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedGelPlatform"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 25;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Gel.CrimsonInfectedGelPlatform>());
        Item.width = 12;
        Item.height = 12;
    }

    public override void AddRecipes()
    {
        CreateRecipe(2)
            .AddIngredient<CrimsonInfectedGel>()
            .Register();
    }
}
