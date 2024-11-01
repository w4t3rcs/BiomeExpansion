using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CrimsonInfectedMushroomWoodLamp : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CrimsonInfectedMushroomWoodLamp"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetLamp(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.OrangeTorch;
        AddMapEntry(Color.Cyan);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CrimsonInfectedMushroomWoodLamp>());
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
        FrameHelper.DrawFlameEffect(ModContent.Request<Texture2D>("BiomeExpansion/Assets/Tiles/Furniture/CrimsonInfectedMushroomWoodLampFlame").Value, i, j);
    }

    public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
    {
        if (Main.tile[i, j].TileFrameX < 18)
            FrameHelper.DrawFlameSparks(DustID.RedTorch, 7, i, j - 1);
    }
    
    public override void HitWire(int i, int j)
    {
        FrameHelper.LightHitWire(Type, i, j, 1, 3);
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}