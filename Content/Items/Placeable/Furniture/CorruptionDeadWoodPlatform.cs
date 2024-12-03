namespace BiomeExpansion.Content.Items.Placeable.Furniture
{
    public class CorruptionDeadWoodPlatform : ModItem
    {
        public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionDeadWoodPlatform"];

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 25;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CorruptionDeadWoodPlatform>());
            Item.width = 12;
            Item.height = 12;
        }

        public override void AddRecipes()
        {
            CreateRecipe(2)
                .AddIngredient<CorruptionDeadWood>()
                .Register();
        }
    }
}
