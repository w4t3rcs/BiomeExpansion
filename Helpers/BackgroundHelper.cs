using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;

namespace BiomeExpansion.Helpers;

public static class BackgroundHelper
{
    private const float BackgroundScaleMultiplier = 2f;
    private static readonly FieldInfo ScreenOffField = typeof(Main).GetField("screenOff", BindingFlags.Instance | BindingFlags.NonPublic);
    private static readonly FieldInfo ScAdjField = typeof(Main).GetField("scAdj", BindingFlags.Instance | BindingFlags.NonPublic);
    private static readonly float ScreenOff = (float)ScreenOffField.GetValue(Main.instance)!;
    private static readonly float ScAdj = (float)ScAdjField.GetValue(Main.instance)!;
    
    /// <summary>
    /// Draws a repeating background layer with parallax scrolling based on
    /// <paramref name="surfacePosition"/>, with the given <paramref name="bgScale"/> and
    /// <paramref name="bgParallax"/> relative to the screen position.
    /// <paramref name="bgyOffset"/>, <paramref name="topYMultiplier"/>, <paramref name="a"/>, <paramref name="b"/>, and <paramref name="pushBGTopHack"/> are used to position the background layer vertically.
    /// The background is drawn with the given <paramref name="minDepth"/> and is offset horizontally by <paramref name="bgX"/> when in the game menu.
    /// </summary>
    /// <param name="layer">The background layer to draw.</param>
    /// <param name="surfacePosition">The surface position of the world, in tiles.</param>
    /// <param name="bgyOffset">The vertical offset of the background layer relative to the world surface.</param>
    /// <param name="bgScale">The scale of the background layer relative to the world surface.</param>
    /// <param name="bgParallax">The parallax of the background layer relative to the screen position.</param>
    /// <param name="topYMultiplier">The vertical position of the background layer relative to the screen position when above the world surface.</param>
    /// <param name="a">The y-coordinate of the background layer relative to the screen position.</param>
    /// <param name="b">The y-coordinate of the background layer relative to the screen position when in the game menu.</param>
    /// <param name="bgX">The horizontal offset of the background layer relative to the screen position when in the game menu.</param>
    /// <param name="minDepth">The minimum depth of the background layer.</param>
    /// <param name="pushBGTopHack">A hack to push the background layer above the world surface when in the game menu.</param>
    public static void DrawLayer(Texture2D layer, float surfacePosition, int bgyOffset, float bgScale, float bgParallax, float topYMultiplier, float a, int b, int bgX, float minDepth, int pushBGTopHack)
    {
        float screenPosition = Main.screenPosition.Y + Main.screenHeight / 2 - 600f;
        double backgroundTopMagicNumber = (0f - screenPosition + ScreenOff / 2f) / (surfacePosition * 16f);
        int bgTopY = (int)(backgroundTopMagicNumber * topYMultiplier + a) + (int)ScAdj + pushBGTopHack;
        bgScale *= BackgroundScaleMultiplier;
        int bgWidthScaled = (int)(layer.Width * bgScale);
        SkyManager.Instance.DrawToDepth(Main.spriteBatch, minDepth / bgParallax);
        int bgStartX = (int)(0.0 - Math.IEEERemainder((double)Main.screenPosition.X * bgParallax, bgWidthScaled) - bgWidthScaled / 2);
        if (Main.gameMenu)
        {
            bgTopY = b + pushBGTopHack;
            bgStartX -= bgX;
        }
        var bgLoops = Main.screenWidth / bgWidthScaled + 2;
        if (Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
        {
            for (int i = 0; i < bgLoops; i++)
            {
                Main.spriteBatch.Draw(layer,
                    new Vector2(bgStartX + bgWidthScaled * i, bgTopY + bgyOffset),
                    new Rectangle(0, 0, layer.Width,
                        layer.Height), Main.ColorOfTheSkies * Main.atmo, 0f,
                    default, bgScale, SpriteEffects.None, 0f);
            }
        }
        
    }
}