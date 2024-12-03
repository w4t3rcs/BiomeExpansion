namespace BiomeExpansion.Content.Items.Placeable.Furniture
{
    public class CrimsonDeadWoodPlatform : ModItem
    {
        public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonDeadWoodPlatform"];

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 25;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CrimsonDeadWoodPlatform>());
            Item.width = 12;
            Item.height = 12;
        }

        public override void AddRecipes()
        {
            CreateRecipe(2)
                .AddIngredient<CrimsonDeadWood>()
                .Register();
        }
    }
}
