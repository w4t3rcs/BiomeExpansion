using Terraria.DataStructures;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CorruptionInfectedMushroomWoodCandle : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomWoodCandle"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetCandle(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.BlueTorch;
        AddMapEntry(Color.Cyan);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodCandle>());
    }

    public override void MouseOver(int i, int j)
    {
        TileInteractionHelper.MouseOver(ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodCandle>());
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        Tile tile = Main.tile[i, j];
        if (tile.TileFrameX < 18)
        {
            r = 0f;
            g = 0.6f;
            b = 1.0f;
        }
        else
        {
            r = 0f;
            g = 0f;
            b = 0f;
        }
    }

    public override void HitWire(int i, int j)
    {
        FrameHelper.LightHitWire(Type, i, j, 1, 1);
    }

    public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
    {
        FrameHelper.DrawFlameEffect(ModContent.Request<Texture2D>("BiomeExpansion/Assets/Tiles/Furniture/CorruptionInfectedMushroomWoodCandleFlame").Value, i, j, 2, -3);
    }

    public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
    {
        if (Main.tile[i, j].TileFrameX < 18)
            FrameHelper.DrawFlameSparks(DustID.BlueFlare, 5, i, j);
    }
    
    public override bool RightClick(int i, int j)
    {
        FrameHelper.LightHitWire(Type, i, j, 1, 1);
        return true;
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}