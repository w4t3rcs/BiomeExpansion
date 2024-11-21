namespace BiomeExpansion.Content.Tiles.Stones
{
    public class Layer2Stone1 : ModTile
    {
        public override string Texture => TextureHelper.DynamicTilesTextures["Layer2Stone1"];

        public override void SetStaticDefaults()
        {
            TileHelper.SetStone(Type);
            Main.tileMergeDirt[Type] = false;
            HitSound = SoundID.Tink;
            DustType = DustID.Stone;
            AddMapEntry(Color.Gray);
            RegisterItemDrop(ModContent.ItemType<Items.Placeable.Stones.Layer2Stone1>());
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
