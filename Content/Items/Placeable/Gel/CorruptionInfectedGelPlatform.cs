namespace BiomeExpansion.Content.Items.Placeable.Gel;

public class CorruptionInfectedGelPlatform : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedGelPlatform"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 25;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Gel.CorruptionInfectedGelPlatform>());
        Item.width = 12;
        Item.height = 12;
    }

    public override void AddRecipes()
    {
        CreateRecipe(2)
            .AddIngredient<CorruptionInfectedGel>()
            .Register();
    }
}
