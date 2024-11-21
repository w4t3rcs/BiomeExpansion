namespace BiomeExpansion.Content.Tiles.Stones
{
    public class Layer2Stone2 : ModTile
    {
        public override string Texture => TextureHelper.DynamicTilesTextures["Layer2Stone2"];

        public override void SetStaticDefaults()
        {
            TileHelper.SetStone(Type);
            HitSound = SoundID.Tink;
            DustType = DustID.Stone;
            AddMapEntry(Color.DarkGray);
            RegisterItemDrop(ModContent.ItemType<Items.Placeable.Stones.Layer2Stone2>());
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
