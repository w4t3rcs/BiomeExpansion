using Terraria.ObjectData;

namespace BiomeExpansion.Helpers;

public static class FrameHelper
{
    public const sbyte FrameSize = 16;
    public const sbyte FramePadding = 2;
    private static readonly Vector2 Zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

    /// <summary>
    /// Sets the horizontal frame of a tile to a random one within the given range.
    /// </summary>
    /// <param name="x">The x-coordinate of the tile.</param>
    /// <param name="y">The y-coordinate of the tile.</param>
    /// <param name="width">The width of the tile frame.</param>
    /// <param name="height">The height of the tile frame.</param>
    /// <param name="frameCount">The number of frames to randomly choose from.</param>
    public static void SetRandomHorizontalFrame(int x, int y, int width, int height, int frameCount)
    {
        SetFrameX(x, y, width, height, WorldGen.genRand.Next(0, frameCount));
    }
    
    /// <summary>
    /// Sets the horizontal frame of a tile to a random one within the given range.
    /// </summary>
    /// <param name="x">The x-coordinate of the tile.</param>
    /// <param name="y">The y-coordinate of the tile.</param>
    /// <param name="height">The height of the tile frame.</param>
    /// <param name="frameCount">The number of frames to randomly choose from.</param>
    public static void SetRandomHorizontalFrame(int x, int y, int height, int frameCount)
    {
        SetFrameX(x, y, height, WorldGen.genRand.Next(0, frameCount));
    }

    /// <summary>
    /// Sets the horizontal frame of a Sea Oats tile to a random one within the range [1, 15).
    /// If the chosen frame is greater than 4, it will also set the frame of the tile above it.
    /// </summary>
    /// <param name="x">The x-coordinate of the tile.</param>
    /// <param name="y">The y-coordinate of the tile.</param>
    public static void SetFramingSeaOats(int x, int y)
    {
        int randomFrame = WorldGen.genRand.Next(1, 15);
        SetFrameX(x, y, randomFrame);
        if (randomFrame > 4) SetFrameX(x, y - 1, randomFrame);
    }
    
    /// <summary>
    /// Sets the frame of a tile to match the frame of the tiles above and below it if they are all the same type.
    /// This is used to make vines connect visually.
    /// </summary>
    /// <param name="x">The x-coordinate of the tile.</param>
    /// <param name="y">The y-coordinate of the tile.</param>
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
    
    /// <summary>
    /// Sets the horizontal frame of a rectangular area of tiles with specified width and height.
    /// Each tile in the area is assigned a frame based on the provided frame number.
    /// </summary>
    /// <param name="x">The x-coordinate of the starting tile.</param>
    /// <param name="y">The y-coordinate of the starting tile.</param>
    /// <param name="width">The width of the tile area.</param>
    /// <param name="height">The height of the tile area.</param>
    /// <param name="frameNumber">The frame number used to calculate the tile frame.</param>
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

    /// <summary>
    /// Sets the horizontal frame of a vertical column of tiles with specified height.
    /// Each tile in the column is assigned a frame based on the provided frame number.
    /// </summary>
    /// <param name="x">The x-coordinate of the tile.</param>
    /// <param name="y">The y-coordinate of the top tile in the column.</param>
    /// <param name="height">The height of the tile column.</param>
    /// <param name="frameNumber">The frame number used to calculate the tile frame.</param>
    public static void SetFrameX(int x, int y, int height, int frameNumber)
    {
        for (int i = 0; i < height; i++)
            Main.tile[x, y - i].TileFrameX =(short)(frameNumber * (FrameSize + FramePadding));
    }

    /// <summary>
    /// Sets the horizontal frame of a single tile at the specified coordinates.
    /// The frame is determined by the given frame number and is calculated using
    /// the predefined frame size and padding.
    /// </summary>
    /// <param name="x">The x-coordinate of the tile.</param>
    /// <param name="y">The y-coordinate of the tile.</param>
    /// <param name="frameNumber">The frame number used to calculate the tile frame.</param>
    public static void SetFrameX(int x, int y, int frameNumber)
    {
        Main.tile[x, y].TileFrameX =(short)(frameNumber * (FrameSize + FramePadding));
    }

    /// <summary>
    /// Draws a campfire flame effect at the specified coordinates using the provided flame texture.
    /// </summary>
    /// <param name="flameTexture">The texture to use for the flame effect.</param>
    /// <param name="x">The x-coordinate of the tile.</param>
    /// <param name="y">The y-coordinate of the tile.</param>
    /// <param name="offsetY">The vertical offset of the flame effect relative to the tile position.</param>
    public static void DrawCampfireFlameEffect(Texture2D flameTexture, int x, int y, int offsetY = 0)
    {
        Color color = new Color(255, 255, 255, 0);
        Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
        if (Main.drawToScreen) zero = Vector2.Zero;
        int width = 16;
        int height = 16;
        short frameX = Main.tile[x, y].TileFrameX;
        short frameY = Main.tile[x, y].TileFrameY;
        int addFrX = 0;
        int addFrY = 0;
        TileLoader.SetDrawPositions(x, y, ref width, ref offsetY, ref height, ref frameX, ref frameY);
        TileLoader.SetAnimationFrame(Main.tile[x, y].TileType, x, y, ref addFrX, ref addFrY);
        Rectangle drawRectangle = new Rectangle(Main.tile[x, y].TileFrameX, Main.tile[x, y].TileFrameY + addFrY, 16, 16);
        Main.spriteBatch.Draw(flameTexture, new Vector2(x * 16 - (int)Main.screenPosition.X, y * 16 - (int)Main.screenPosition.Y + offsetY) + zero, drawRectangle, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

    }
    
    /// <summary>
    /// Draws a flame effect at the specified coordinates using the provided flame texture.
    /// The flame effect is a 7-frame animation with a small amount of random shake.
    /// </summary>
    /// <param name="flameTexture">The texture to use for the flame effect.</param>
    /// <param name="i">The x-coordinate of the tile.</param>
    /// <param name="j">The y-coordinate of the tile.</param>
    /// <param name="offsetX">The horizontal offset of the flame effect relative to the tile position.</param>
    /// <param name="offsetY">The vertical offset of the flame effect relative to the tile position.</param>
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
    
    /// <summary>
    /// Creates and animates flame sparks at the specified tile coordinates.
    /// The sparks are generated using the given dust type and rarity.
    /// </summary>
    /// <param name="dustType">The type of dust to use for the sparks.</param>
    /// <param name="rarity">The rarity of the sparks, affecting their spawn rate.</param>
    /// <param name="x">The x-coordinate of the tile where the sparks should appear.</param>
    /// <param name="y">The y-coordinate of the tile where the sparks should appear.</param>
    public static void DrawFlameSparks(int dustType, int rarity, int x, int y)
    {
        if (Main.gamePaused || !Main.instance.IsActive || (Lighting.UpdateEveryFrame && !Main.rand.NextBool(4)) || !Main.rand.NextBool(rarity)) return;
        int dust = Dust.NewDust(new Vector2(x * 16 + 4, y * 16 + 2), 4, 4, dustType, 0f, 0f, 100);
        if (!Main.rand.NextBool(3))
            Main.dust[dust].noGravity = true;
        Main.dust[dust].noLightEmittence = true;
        Main.dust[dust].velocity *= 0.3f;
        Main.dust[dust].velocity.Y -= 1.5f;
    }
    
    /// <summary>
    /// Toggles the frame of tiles of a specific type when a wire is activated at the specified coordinates.
    /// </summary>
    /// <param name="type">The type of the tile to be affected by the wire.</param>
    /// <param name="x">The x-coordinate of the tile where the wire is activated.</param>
    /// <param name="y">The y-coordinate of the tile where the wire is activated.</param>
    /// <param name="tileX">The width of the tile area to be affected by the wire.</param>
    /// <param name="tileY">The height of the tile area to be affected by the wire.</param>
    public static void LightHitWire(int type, int x, int y, int tileX, int tileY)
    {
        int frameX = x - Main.tile[x, y].TileFrameX / 18 % tileX;
        int frameY = y - Main.tile[x, y].TileFrameY / 18 % tileY;
        int tile = 18 * tileX;
        for (int l = frameX; l < frameX + tileX; l++)
        {
            for (int m = frameY; m < frameY + tileY; m++)
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
                    Wiring.SkipWire(frameX + k, frameY + l);
            }
        }
    }

    /// <summary>
    /// Draws a tile at the specified coordinates with its glow mask.
    /// The tile is drawn with the color obtained from <see cref="Lighting.GetColor(int, int)"/>, and the glow mask is drawn on top of it with a white color.
    /// </summary>
    /// <param name="spriteBatch">The SpriteBatch to draw with.</param>
    /// <param name="tileTexture">The name of the texture of the tile to be drawn.</param>
    /// <param name="x">The x-coordinate of the tile to be drawn.</param>
    /// <param name="y">The y-coordinate of the tile to be drawn.</param>
    /// <param name="width">The width of the tile to be drawn.</param>
    /// <param name="height">The height of the tile to be drawn.</param>
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

    /// <summary>
    /// Draws an item at its center position with a glow mask.
    /// The glow mask is drawn with a white color and the item is drawn on top of it with its regular color and alpha.
    /// </summary>
    /// <param name="spriteBatch">The SpriteBatch to draw with.</param>
    /// <param name="itemTexture">The name of the texture of the item to be drawn.</param>
    /// <param name="item">The item to be drawn.</param>
    /// <param name="rotation">The rotation of the item to be drawn.</param>
    public static void DrawItemWithGlowMask(SpriteBatch spriteBatch, string itemTexture, Item item, float rotation)
    {
        var glowTextureLocation = $"{itemTexture}Glow";
        var glowTexture = ModContent.Request<Texture2D>(glowTextureLocation).Value;
        Vector2 origin = new Vector2(glowTexture.Width / 2f, glowTexture.Height / 2f);
        Color color = new Color(250, 250, 250, item.alpha);
        spriteBatch.Draw(glowTexture, item.Center - Main.screenPosition, null, color, rotation, origin, 1f, SpriteEffects.None, 0f);
    }

    public static void AnimateNPCWithDirection(NPC npc, int frameHeight, int animationSpeed)
    {
        Vector2 direction = npc.velocity;
        direction.Normalize();
        npc.spriteDirection = npc.direction = npc.velocity.X > 0 ? 1 : -1;
        AnimateNPC(npc, frameHeight, animationSpeed);
    }

    public static void AnimateNPC(NPC npc, int frameHeight, int animationSpeed)
    {
        AnimateNPC(npc, frameHeight, animationSpeed, Main.npcFrameCount[npc.type]);
    }

    public static void AnimateNPC(NPC npc, int frameHeight, int animationSpeed, int frameCount = 2)
    {
        if (++npc.frameCounter >= animationSpeed)
        {
            npc.frameCounter = 0;
            npc.frame.Y = (npc.frame.Y + frameHeight) % (frameHeight * frameCount);
        }
    }

    public static void AnimateProjectile(Projectile projectile, int animationSpeed)
    {
		projectile.frameCounter++;
		if (projectile.frameCounter >= animationSpeed) {
			projectile.frameCounter = 0;
			projectile.frame++;

			if (projectile.frame >= Main.projFrames[projectile.type]) {
				projectile.frame = 0;
			}
		}
    }

    public static void AnimateTile(ref int frame, ref int frameCounter, int frameCount, int animationSpeed)
    {
        frameCounter++;
        if (frameCounter >= animationSpeed)
        {
            frame++;
            frameCounter = 0;
        }
        if (frame >= frameCount)
        {
            frame = 0;
        }
    }

    public static int GetAnimationOffset(ModTile tile, int x, int y, int frameCount, int width, int height, int animationFrameLength)
    {
        int frameSizeWithPadding = FrameSize + FramePadding;
        int frameX = Main.tile[x, y].TileFrameX % (frameCount * width);
        int frameY = Main.tile[x, y].TileFrameY % (frameSizeWithPadding * height);
        x -= frameX / frameSizeWithPadding;
        y -= frameY / frameSizeWithPadding;
        int uniqueAnimationFrame = (Main.tileFrame[tile.Type] + y + ((x % 2 + x % 3 + x % 4 + y % 2 + y % 3 + y % 4) * 3)) % frameCount;
        return uniqueAnimationFrame * animationFrameLength;
    }
}