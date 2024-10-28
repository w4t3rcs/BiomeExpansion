using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CrimsonInfectedMushroomWoodChandelier : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CrimsonInfectedMushroomWoodChandelier");

    public override void SetStaticDefaults()
    {
        TileHelper.SetChandelier(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.OrangeTorch;
        AddMapEntry(Color.Cyan);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CrimsonInfectedMushroomWoodChandelier>());
    }
    
    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        Tile tile = Main.tile[i, j];
        if (tile.TileFrameX < 18)
        {
            r = 1.5f;
            g = 0.7f;
            b = 0.1f;
        }
        else
        {
            r = 0f;
            g = 0f;
            b = 0f;
        }
    }

    public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
    {
        FrameHelper.DrawFlameEffect(ModContent.Request<Texture2D>("BiomeExpansion/Assets/Tiles/Furniture/CrimsonInfectedMushroomWoodChandelierFlame").Value, i, j);
    }
    
    public override void HitWire(int i, int j)
    {
        FrameHelper.LightHitWire(Type, i, j, 3, 3);
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}