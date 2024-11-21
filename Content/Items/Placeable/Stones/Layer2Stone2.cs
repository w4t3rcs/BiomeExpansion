namespace BiomeExpansion.Content.Items.Placeable.Stones
{
    public class Layer2Stone2 : ModItem
    {
        public override string Texture => TextureHelper.DynamicItemsTextures["Layer2Stone2"];

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Stones.Layer2Stone2>());
            Item.width = 16;
            Item.height = 16;
        }
    }
}
