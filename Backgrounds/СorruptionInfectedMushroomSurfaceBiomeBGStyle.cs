using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace BiomeExpansion.Backgrounds;

public class СorruptionInfectedMushroomSurfaceBiomeBGStyle : ModSurfaceBackgroundStyle
{ 
    internal static readonly FieldInfo screenOffField = typeof(Main).GetField("screenOff", BindingFlags.Instance | BindingFlags.NonPublic);
    internal static readonly FieldInfo scAdjField = typeof(Main).GetField("scAdj", BindingFlags.Instance | BindingFlags.NonPublic);
    internal static readonly FieldInfo COSBMAplhaField = typeof(Main).GetField("ColorOfSurfaceBackgroundsModified", BindingFlags.Static | BindingFlags.NonPublic);
    private const int MiddleBGYOffset = 475;
    private const int CloseBGYOffset = 175;
    private const int FrontBGYOffset = 275; //Offsets for the height positioning. Make these 0 for backgrounds that want to be the same as treeline backgrounds (backgrounds that have the front 3 layers as trees)
    private const string HorizonTexture = "BiomeExpansion/Assets/Backgrounds/CorruptionInfectedMushroomSurfaceBiomeHorizon";
    private const string FarTexture = "BiomeExpansion/Assets/Backgrounds/CorruptionInfectedMushroomSurfaceBiomeFar";
    private const string MiddleTexture = "BiomeExpansion/Assets/Backgrounds/CorruptionInfectedMushroomSurfaceBiomeMiddle";
    private const string CloseTexture = "BiomeExpansion/Assets/Backgrounds/CorruptionInfectedMushroomSurfaceBiomeClose";
    public override int ChooseFarTexture() => BackgroundTextureLoader.GetBackgroundSlot(HorizonTexture);
    public override int ChooseMiddleTexture() => BackgroundTextureLoader.GetBackgroundSlot(FarTexture);
    public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b) => BackgroundTextureLoader.GetBackgroundSlot(MiddleTexture);

    public override void ModifyFarFades(float[] fades, float transitionSpeed)
    {
        for (int i = 0; i < fades.Length; i++)
        {
            if (i == Slot)
            {
                fades[i] += transitionSpeed;
                if (fades[i] > 1f)
                {
                    fades[i] = 1f;
                }
            }
            else
            {
                fades[i] -= transitionSpeed;
                if (fades[i] < 0f)
                {
                    fades[i] = 0f;
                }
            }
        }
    }

    public override bool PreDrawCloseBackground(SpriteBatch spriteBatch)
    {
        // Color colorOfSurfaceBackgroundsModified = new Color(63, 51, 90, BackgroundHelper.COSBMAplha.A);
        // bool canBGDraw = (!Main.remixWorld || (Main.gameMenu && !WorldGen.remixWorldGen)) && (!WorldGen.remixWorldGen || !WorldGen.drunkWorldGen);
        // if (Main.mapFullscreen) canBGDraw = false;
        // int offset = 30;
        // if (Main.gameMenu) offset = 0;
        // if (WorldGen.drunkWorldGen) offset = -180;
        // float surfacePosition = (float)Main.worldSurface;
        // if (surfacePosition == 0f) surfacePosition = 1f;
        // int pushBGTopHack;
        // const int offset2 = -180;
        // int menuOffset = 0;
        // if (Main.gameMenu) menuOffset -= offset2;
        // pushBGTopHack = menuOffset;
        // pushBGTopHack += offset;
        // pushBGTopHack += offset2; //Offsets to the background placement
        // if (canBGDraw) //If the background can draw (player is not in a remix world or is not in a map).  This can probably be removed since backgrounds already go through these checks
        // {
        //     BackgroundHelper.DrawLayer(ModContent.Request<Texture2D>(MiddleTexture).Value, surfacePosition,
        //         MiddleBGYOffset, 1.25f, 0.4f, 1800.0f, 1500.0f, 320, 0, 1.2f, ref pushBGTopHack,
        //         colorOfSurfaceBackgroundsModified);
        //     BackgroundHelper.DrawLayer(ModContent.Request<Texture2D>(CloseTexture).Value, surfacePosition,
        //         CloseBGYOffset, 1.31f, 0.43f, 1950.0f, 1750.0f, 400, 80, 1f, ref pushBGTopHack,
        //         colorOfSurfaceBackgroundsModified);
        //     // BackgroundHelper.DrawLayer(ModContent.Request<Texture2D>(FrontTexture).Value, surfacePosition,
        //     //     FrontBGYOffset, 1.34f, 0.49f, 2100.0f, 2000.0f, 480, 120, 1f, ref pushBGTopHack,
        //     //     colorOfSurfaceBackgroundsModified);
        // }
        
        float screenOff = (float)screenOffField.GetValue(Main.instance)!;
        float scAdj = (float)scAdjField.GetValue(Main.instance)!;
        Color COSBMAplha = (Color)COSBMAplhaField.GetValue(null)!;
        Color colorOfSurfaceBackgroundsModified = new Color(63, 51, 90, COSBMAplha.A); //Astral Biome Coloration with the alpha as the background fade
        bool canBGDraw = (!Main.remixWorld || (Main.gameMenu && !WorldGen.remixWorldGen)) && (!WorldGen.remixWorldGen || !WorldGen.drunkWorldGen);
        if (Main.mapFullscreen) canBGDraw = false;
        int offset = 30;
        if (Main.gameMenu) offset = 0;
        if (WorldGen.drunkWorldGen) offset = -180;
        float surfacePosition = (float)Main.worldSurface;
        if (surfacePosition == 0f) surfacePosition = 1f;
        float screenPosition = Main.screenPosition.Y + (float)(Main.screenHeight / 2) - 600f;
        double backgroundTopMagicNumber = (0f - screenPosition + screenOff / 2f) / (surfacePosition * 16f);
        float bgGlobalScaleMultiplier = 2f;
        int pushBGTopHack;
        int offset2 = -180;
        int menuOffset = 0;
        if (Main.gameMenu) menuOffset -= offset2;
        pushBGTopHack = menuOffset;
        pushBGTopHack += offset;
        pushBGTopHack += offset2; //Offsets to the background placement
        if (canBGDraw) //If the background can draw (player is not in a remix world or is not in a map).  This can probably be removed since backgrounds already go through these checks
        {
            //3rd layer (Middle)
            var bgScale = 1.25f; //Scale of the furthest of the closest background layers (3rd layer)
            var bgParallax = 0.4; //The parallax of the background layer
            var bgTopY = (int)(backgroundTopMagicNumber * 1800.0 + 1500.0) + (int)scAdj + pushBGTopHack; //the Y position of the background
            bgScale *= bgGlobalScaleMultiplier; //Scale of the background
            Texture2D middleLayer = ModContent.Request<Texture2D>(MiddleTexture).Value;
            var bgWidthScaled = (int)((float)middleLayer.Width *
                                      bgScale); //The Width of the bg texture scaled to the correct size
            SkyManager.Instance.DrawToDepth(Main.spriteBatch, 1.2f / (float)bgParallax);
            var bgStartX = (int)(0.0 - Math.IEEERemainder((double)Main.screenPosition.X * bgParallax, bgWidthScaled) -
                                 (double)(bgWidthScaled / 2)); //The starting position of the background layer
            if (Main.gameMenu)
                bgTopY = 320 + pushBGTopHack; //increases the height in the main menu

            var bgLoops = Main.screenWidth / bgWidthScaled + 2;
            if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
            {
                for (int i = 0; i < bgLoops; i++)
                {
                    //Draw the texture and its glowmask to each loop of the texture
                    Main.spriteBatch.Draw(middleLayer,
                        new Vector2(bgStartX + bgWidthScaled * i, bgTopY + MiddleBGYOffset),
                        new Rectangle(0, 0, middleLayer.Width,
                            middleLayer.Height), colorOfSurfaceBackgroundsModified, 0f,
                        default(Vector2), bgScale, SpriteEffects.None, 0f);
                }
            }

            //2nd layer (Close)
            //Repeat of above with slight changes to variables
            bgScale = 1.31f;
            bgParallax = 0.43;
            bgTopY = (int)(backgroundTopMagicNumber * 1950.0 + 1750.0) + (int)scAdj + pushBGTopHack;
            bgScale *= bgGlobalScaleMultiplier;
            Texture2D closeLayer = ModContent.Request<Texture2D>(CloseTexture).Value;
            bgWidthScaled = (int)(closeLayer.Width * bgScale);
            SkyManager.Instance.DrawToDepth(Main.spriteBatch, 1f / (float)bgParallax);
            bgStartX = (int)(0.0 - Math.IEEERemainder(Main.screenPosition.X * bgParallax, bgWidthScaled) - bgWidthScaled / 2);
            if (Main.gameMenu)
            {
                bgTopY = 400 + pushBGTopHack;
                bgStartX -= 80; //the initial postion of where the background starts in the main menu is pushed back to not be directly ontop, mostly for tree bgs that use the same treeline texture but faded
            }

            bgLoops = Main.screenWidth / bgWidthScaled + 2;
            if (Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
            {
                for (int i = 0; i < bgLoops; i++)
                {
                    Main.spriteBatch.Draw(closeLayer,
                        new Vector2(bgStartX + bgWidthScaled * i, bgTopY + CloseBGYOffset),
                        new Rectangle(0, 0, closeLayer.Width,
                            closeLayer.Height), colorOfSurfaceBackgroundsModified, 0f,
                        default, bgScale, SpriteEffects.None, 0f);
                }
            }

            //1st layer (Front)
            //Repeat of above with slight changes to variables
            // bgScale = 1.34f;
            // bgParallax = 0.49;
            // bgTopY = (int)(backgroundTopMagicNumber * 2100.0 + 2000.0) + (int)scAdj + pushBGTopHack;
            // bgScale *= bgGlobalScaleMultiplier;
            // Texture2D frontLayer = ModContent.Request<Texture2D>(FrontTexture).Value;
            // bgWidthScaled = (int)(frontLayer.Width * bgScale);
            // SkyManager.Instance.DrawToDepth(Main.spriteBatch, 1f / (float)bgParallax);
            // bgStartX = (int)(0.0 - Math.IEEERemainder(Main.screenPosition.X * bgParallax, bgWidthScaled) - bgWidthScaled / 2);
            // if (Main.gameMenu)
            // {
            //     bgTopY = 480 + pushBGTopHack;
            //     bgStartX -= 120;
            // }
            //
            // bgLoops = Main.screenWidth / bgWidthScaled + 2;
            // if (Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
            // {
            //     for (int i = 0; i < bgLoops; i++)
            //     {
            //         Main.spriteBatch.Draw(frontLayer, new Vector2(bgStartX + bgWidthScaled * i, bgTopY + FrontBGYOffset), new Rectangle(0, 0, frontLayer.Width, frontLayer.Height), ColorOfSurfaceBackgroundsModified, 0f, default, bgScale, SpriteEffects.None, 0f);
            //     }
            // }
        }

        return false;
    }
}