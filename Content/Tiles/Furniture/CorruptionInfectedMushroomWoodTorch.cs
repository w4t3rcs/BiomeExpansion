using BiomeExpansion.Content.Biomes;
using Terraria.DataStructures;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CorruptionInfectedMushroomWoodTorch : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomWoodTorch"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetTorch(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.BlueTorch;
        AddMapEntry(Color.Cyan);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodTorch>());
    }

    public override void MouseOver(int i, int j)
    {
        TileInteractionHelper.MouseOver(ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodTorch>());
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        Tile tile = Main.tile[i, j];
        if (tile.TileFrameX < 66)
        {
            r = 0f;
            g = 0.6f;
            b = 1.0f;
        }
    }

    public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
    {
        offsetY = 0;
        if (!WorldGen.SolidTile(i, j - 1)) return;
        offsetY = 2;
        if (WorldGen.SolidTile(i - 1, j + 1) || WorldGen.SolidTile(i + 1, j + 1))
            offsetY = 4;
    }

    public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
    {
        FrameHelper.DrawFlameEffect(ModContent.Request<Texture2D>("BiomeExpansion/Assets/Tiles/Furniture/CorruptionInfectedMushroomWoodTorchFlame").Value, i, j, 2);
    }

    public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
    {
        if (Main.tile[i, j].TileFrameX < 66)
            FrameHelper.DrawFlameSparks(DustID.BlueFlare, 5, i, j);
    }

    public override bool RightClick(int i, int j)
    {
        return TileInteractionHelper.RightClickDestroy(i, j);
    }

    public override float GetTorchLuck(Player player)
    {
        return player.InModBiome<CorruptionInfectedMushroomSurfaceBiome>() ? 1f : -1f;
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}