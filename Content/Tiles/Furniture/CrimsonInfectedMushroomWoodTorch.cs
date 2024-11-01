using BiomeExpansion.Content.Biomes;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CrimsonInfectedMushroomWoodTorch : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CrimsonInfectedMushroomWoodTorch"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetTorch(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.OrangeTorch;
        AddMapEntry(Color.Cyan);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CrimsonInfectedMushroomWoodTorch>());
    }

    public override void MouseOver(int i, int j)
    {
        Player player = Main.LocalPlayer;
        player.noThrow = 2;
        player.cursorItemIconEnabled = true;
        player.cursorItemIconID = ModContent.ItemType<Items.Placeable.Furniture.CrimsonInfectedMushroomWoodTorch>();
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        Tile tile = Main.tile[i, j];
        if (tile.TileFrameX < 66)
        {
            r = 1.5f;
            g = 0.7f;
            b = 0.1f;
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
        FrameHelper.DrawFlameEffect(ModContent.Request<Texture2D>("BiomeExpansion/Assets/Tiles/Furniture/CrimsonInfectedMushroomWoodTorchFlame").Value, i, j, 2);
    }

    public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
    {
        if (Main.tile[i, j].TileFrameX < 66)
            FrameHelper.DrawFlameSparks(DustID.Flare, 5, i, j);
    }

    public override bool RightClick(int i, int j)
    {
        Tile tile = Main.tile[i, j];
        if (tile != null && tile.HasTile)
        {
            WorldGen.KillTile(i, j);
            if (!tile.HasTile && Main.netMode != NetmodeID.SinglePlayer)
            {
                NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, i, j);
            }
        }
        
        return true;
    }

    public override float GetTorchLuck(Player player)
    {
        return player.InModBiome<CrimsonInfectedMushroomSurfaceBiome>() ? 1f : -1f;
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}