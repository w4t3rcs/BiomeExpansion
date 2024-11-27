namespace BiomeExpansion.Content.Tiles.Furniture
{
    public class CorruptionDeadWoodPlatform : ModTile
    {
        public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionDeadWoodPlatform"];

        public override void SetStaticDefaults()
        {
            TileHelper.SetPlatform(this);
            HitSound = SoundID.Dig;
            DustType = DustID.Shadewood;
            AddMapEntry(Color.Brown);
            RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CorruptionDeadWoodPlatform>());
        }
    }
}
