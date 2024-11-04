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