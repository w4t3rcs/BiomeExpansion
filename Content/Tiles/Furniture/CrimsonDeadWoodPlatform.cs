namespace BiomeExpansion.Content.Tiles.Furniture
{
    public class CrimsonDeadWoodPlatform : ModTile
    {
        public override string Texture => TextureHelper.DynamicTilesTextures["CrimsonDeadWoodPlatform"];

        public override void SetStaticDefaults()
        {
            TileHelper.SetPlatform(this);
            HitSound = SoundID.Dig;
            DustType = DustID.Shadewood;
            AddMapEntry(Color.Brown);
            RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CrimsonDeadWoodPlatform>());
        }
    }
}
