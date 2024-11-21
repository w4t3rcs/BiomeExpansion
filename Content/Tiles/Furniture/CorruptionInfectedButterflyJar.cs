using BiomeExpansion.Content.Tiles.Biome;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CorruptionInfectedButterflyJar : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedButterflyJar"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetJar(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Glass;
        AnimationFrameHeight = 36;
        AddMapEntry(Color.DarkCyan);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedButterflyJar>());
    }

    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        FrameHelper.AnimateTile(ref frame, ref frameCounter, 14, 6);
    }

    public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
    {
        frameYOffset = FrameHelper.GetAnimationOffset(this, i, j, 14, 2, 2, AnimationFrameHeight);
    }
}