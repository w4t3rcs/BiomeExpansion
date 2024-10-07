using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace BiomeExpansion.Backgrounds;

public class СorruptionInfectedMushroomSurfaceBiomeBGStyle : ModSurfaceBackgroundStyle
{ 
    private const int HorizonBGYOffset = 75;
    private const int FarBGYOffset = 85;
    private const int MiddleBGYOffset = 140;
    private const int CloseBGYOffset = 150;
    private const int FrontBGYOffset = 160;
    private const string HorizonTexture = "BiomeExpansion/Assets/Backgrounds/CorruptionInfectedMushroomSurfaceBiomeHorizon";
    private const string FarTexture = "BiomeExpansion/Assets/Backgrounds/CorruptionInfectedMushroomSurfaceBiomeFar";
    private const string MiddleTexture = "BiomeExpansion/Assets/Backgrounds/CorruptionInfectedMushroomSurfaceBiomeMiddle";
    private const string CloseTexture = "BiomeExpansion/Assets/Backgrounds/CorruptionInfectedMushroomSurfaceBiomeClose";
    private const string FrontTexture = "BiomeExpansion/Assets/Backgrounds/CorruptionInfectedMushroomSurfaceBiomeFront";
    public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b) => BackgroundTextureLoader.GetBackgroundSlot(CloseTexture);
    

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
        bool canBGDraw = (!Main.remixWorld || (Main.gameMenu && !WorldGen.remixWorldGen)) && (!WorldGen.remixWorldGen || !WorldGen.drunkWorldGen);
        if (Main.mapFullscreen) canBGDraw = false;
        int offset = 30;
        if (Main.gameMenu) offset = 0;
        if (WorldGen.drunkWorldGen) offset = -180;
        float surfacePosition = (float)Main.worldSurface;
        if (surfacePosition == 0f) surfacePosition = 1f;
        int pushBGTopHack;
        const int offset2 = -180;
        int menuOffset = 0;
        if (Main.gameMenu) menuOffset -= offset2;
        pushBGTopHack = menuOffset;
        pushBGTopHack += offset;
        pushBGTopHack += offset2;
        if (canBGDraw)
        {
            BackgroundHelper.DrawLayer(ModContent.Request<Texture2D>(HorizonTexture).Value, surfacePosition,
                HorizonBGYOffset, 1f, 0.38f, 1400.0f, 1000.0f, 160, -120, 1.5f, ref pushBGTopHack);
            BackgroundHelper.DrawLayer(ModContent.Request<Texture2D>(FarTexture).Value, surfacePosition,
                FarBGYOffset, 1.10f, 0.43f, 1650.0f, 1250.0f, 240, -80, 1.35f, ref pushBGTopHack);
            BackgroundHelper.DrawLayer(ModContent.Request<Texture2D>(MiddleTexture).Value, surfacePosition,
                MiddleBGYOffset, 1.25f, 0.47f, 1800.0f, 1500.0f, 320, 0, 1.2f, ref pushBGTopHack);
            BackgroundHelper.DrawLayer(ModContent.Request<Texture2D>(CloseTexture).Value, surfacePosition,
                CloseBGYOffset, 1.31f, 0.55f, 1950.0f, 1750.0f, 400, 80, 1.1f, ref pushBGTopHack);
            BackgroundHelper.DrawLayer(ModContent.Request<Texture2D>(FrontTexture).Value, surfacePosition,
                FrontBGYOffset, 1.34f, 0.63f, 2100.0f, 2000.0f, 480, 120, 1f, ref pushBGTopHack);
        }
        
        return false;
    }
}