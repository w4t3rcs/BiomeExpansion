using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Helpers;

public static class FrameHelper
{
    public const sbyte FrameSize = 16;
    public const sbyte FramePadding = 2;
    private static readonly Vector2 Zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

    public static void SetRandomFrame(int x, int y, int width, int height, int frameCount)
    {
        SetFrameX(x, y, width, height, WorldGen.genRand.Next(0, frameCount));
    }
    
    public static void SetRandomFrame(int x, int y, int height, int frameCount)
    {
        SetFrameX(x, y, height, WorldGen.genRand.Next(0, frameCount));
    }

    public static void SetFramingSeaOats(int x, int y)
    {
        int randomFrame = WorldGen.genRand.Next(1, 15);
        SetFrameX(x, y, randomFrame);
        if (randomFrame > 4) SetFrameX(x, y - 1, randomFrame);
    }
    
    public static void SetFramingVine(int x, int y)
    {
        Tile vineTile = Main.tile[x, y];
        Tile topTile = Main.tile[x, y - 1];
        Tile bottomTile = Main.tile[x, y + 1];
        if (topTile.HasTile && topTile.TileType == vineTile.TileType && bottomTile.HasTile && bottomTile.TileType == vineTile.TileType)
        {
            WorldGen.SquareTileFrame(x, y);
            NetMessage.SendTileSquare(-1, x, y, -1);
        }
    }
    
    public static void SetFrameX(int x, int y, int width, int height, int frameNumber)
    {
        Tile tile = Main.tile[x - 1, y];
        short currentFrame = (short)(frameNumber * (FrameSize + FramePadding) * width);
        tile.TileFrameX = currentFrame;
        for (int j = 1; j < height; j++) Main.tile[x - 1, y - j].TileFrameX = currentFrame;
        for (int i = 0; i < width; i++)
        {
            currentFrame += FrameSize + FramePadding;
            for (int j = 0; j < height; j++)
            {
                Main.tile[x + i, y - j].TileFrameX = currentFrame;
            }
        }
    }

    public static void SetFrameX(int x, int y, int height, int frameNumber)
    {
        for (int i = 0; i < height; i++)
            Main.tile[x, y - i].TileFrameX =(short)(frameNumber * (FrameSize + FramePadding));
    }

    public static void SetFrameX(int x, int y, int frameNumber)
    {
        Main.tile[x, y].TileFrameX =(short)(frameNumber * (FrameSize + FramePadding));
    }

    public static void DrawCampfireFlameEffect(Texture2D flameTexture, int i, int j, int offsetY = 0)
    {
        Color color = new Color(255, 255, 255, 0);
        Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
        if (Main.drawToScreen) zero = Vector2.Zero;
        int width = 16;
        int height = 16;
        short frameX = Main.tile[i, j].TileFrameX;
        short frameY = Main.tile[i, j].TileFrameY;
        int addFrX = 0;
        int addFrY = 0;
        TileLoader.SetDrawPositions(i, j, ref width, ref offsetY, ref height, ref frameX, ref frameY);
        TileLoader.SetAnimationFrame(Main.tile[i, j].TileType, i, j, ref addFrX, ref addFrY);
        Rectangle drawRectangle = new Rectangle(Main.tile[i, j].TileFrameX, Main.tile[i, j].TileFrameY + addFrY, 16, 16);
        Main.spriteBatch.Draw(flameTexture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y + offsetY) + zero, drawRectangle, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

    }
    
    public static void DrawFlameEffect(Texture2D flameTexture, int i, int j, int offsetX = 0, int offsetY = 0)
    {
        const int width = 16;
        const int height = 16;
        Tile tile = Main.tile[i, j];
        Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange, Main.offScreenRange);
        int yOffset = TileObjectData.GetTileData(tile).DrawYOffset;
        ulong randomShakeEffect = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (uint)i);
        float drawPositionX = i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f;
        float drawPositionY = j * 16 - (int)Main.screenPosition.Y;
        for (int k = 0; k < 7; k++)
        {
            float shakeX = Utils.RandomInt(ref randomShakeEffect, -10, 11) * 0.15f;
            float shakeY = Utils.RandomInt(ref randomShakeEffect, -10, 1) * 0.35f;
            Main.spriteBatch.Draw(flameTexture, new Vector2(drawPositionX + shakeX, drawPositionY + shakeY + yOffset) + zero, new Rectangle(tile.TileFrameX + offsetX, tile.TileFrameY + offsetY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, SpriteEffects.None, 0f);
        }
    }
    
    public static void DrawFlameSparks(int dustType, int rarity, int i, int j)
    {
        if (Main.gamePaused || !Main.instance.IsActive || (Lighting.UpdateEveryFrame && !Main.rand.NextBool(4)) || !Main.rand.NextBool(rarity)) return;
        int dust = Dust.NewDust(new Vector2(i * 16 + 4, j * 16 + 2), 4, 4, dustType, 0f, 0f, 100);
        if (!Main.rand.NextBool(3))
            Main.dust[dust].noGravity = true;
        Main.dust[dust].noLightEmittence = true;
        Main.dust[dust].velocity *= 0.3f;
        Main.dust[dust].velocity.Y -= 1.5f;
    }
    
    //Thx Calamity Mod for this great method :)
    public static void LightHitWire(int type, int i, int j, int tileX, int tileY)
    {
        int x = i - Main.tile[i, j].TileFrameX / 18 % tileX;
        int y = j - Main.tile[i, j].TileFrameY / 18 % tileY;
        int tile = 18 * tileX;
        for (int l = x; l < x + tileX; l++)
        {
            for (int m = y; m < y + tileY; m++)
            {
                if (Main.tile[l, m].HasTile && Main.tile[l, m].TileType == type)
                    Main.tile[l, m].TileFrameX += (short)(Main.tile[l, m].TileFrameX < tile ? tile : -tile);
            }
        }

        if (Wiring.running)
        {
            for (int k = 0; k < tileX; k++)
            {
                for (int l = 0; l < tileY; l++)
                    Wiring.SkipWire(x + k, y + l);
            }
        }
    }

    public static void DrawTileWithGlowMask(SpriteBatch spriteBatch, string tileTexture, int x, int y, int width = 1, int height = 1)
    {
        var tile = Framing.GetTileSafely(x, y);
        var frameSizeWithPadding = FrameSize + FramePadding;
        var glowTextureLocation = $"{tileTexture}Glow";
        var sourceRect = new Rectangle(tile.TileFrameX, tile.TileFrameY, width * frameSizeWithPadding, height * frameSizeWithPadding);
        var texture = ModContent.Request<Texture2D>(tileTexture).Value;
        var glowTexture = ModContent.Request<Texture2D>(glowTextureLocation).Value;
        var vector = new Vector2(x * FrameSize - (int)Main.screenPosition.X, y * FrameSize - (int)Main.screenPosition.Y) + Zero;
        spriteBatch.Draw(texture, vector, sourceRect, 
            Lighting.GetColor(x, y), 0f, default, 1f, SpriteEffects.None, 0f
        );
        spriteBatch.Draw(glowTexture, vector, sourceRect, 
            Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f
        );
    }

    public static void DrawItemWithGlowMask(SpriteBatch spriteBatch, string itemTexture, Item item, float rotation)
    {
        var glowTextureLocation = $"{itemTexture}Glow";
        var glowTexture = ModContent.Request<Texture2D>(glowTextureLocation).Value;
        Vector2 origin = new Vector2(glowTexture.Width / 2f, glowTexture.Height / 2f);
        Color color = new Color(250, 250, 250, item.alpha);
        spriteBatch.Draw(glowTexture, item.Center - Main.screenPosition, null, color, rotation, origin, 1f, SpriteEffects.None, 0f);
    }
}