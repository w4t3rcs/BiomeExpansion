using BiomeExpansion.Content.Tiles.Biome;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CorruptionInfectedFairyLantern : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedFairyLantern"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetLantern(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Glass;
        AnimationFrameHeight = 36;
        AddMapEntry(Color.DarkCyan);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedFairyLantern>());
    }

    public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
    {
        Tile tile = Main.tile[i, j];
        TileObjectData data = TileObjectData.GetTileData(tile);
        int topLeftX = i - tile.TileFrameX / 18 % data.Width;
        int topLeftY = j - tile.TileFrameY / 18 % data.Height;
        if (WorldGen.IsBelowANonHammeredPlatform(topLeftX, topLeftY))
            offsetY -= 8;
    }

    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        FrameHelper.AnimateTile(ref frame, ref frameCounter, 6, 6);
    }

    public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
    {
        frameYOffset = FrameHelper.GetAnimationOffset(this, i, j, 6, 1, 2, AnimationFrameHeight);
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 0f;
        g = 0.6f;
        b = 0.1f;
    }
}