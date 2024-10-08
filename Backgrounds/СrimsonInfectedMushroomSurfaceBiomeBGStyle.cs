using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace BiomeExpansion.Backgrounds;

public class СrimsonInfectedMushroomSurfaceBiomeBGStyle : ModSurfaceBackgroundStyle
{
    private const int MiddleBGYOffset = 225;
    private const int CloseBGYOffset = 75;
    private const string HorizonTexture = "BiomeExpansion/Assets/Backgrounds/CrimsonInfectedMushroomSurfaceBiomeHorizon";
    private const string FarTexture = "BiomeExpansion/Assets/Backgrounds/CrimsonInfectedMushroomSurfaceBiomeFar";
    private const string MiddleTexture = "BiomeExpansion/Assets/Backgrounds/CrimsonInfectedMushroomSurfaceBiomeMiddle";
    private const string CloseTexture = "BiomeExpansion/Assets/Backgrounds/CrimsonInfectedMushroomSurfaceBiomeClose";
    
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
            BackgroundHelper.DrawLayer(ModContent.Request<Texture2D>(MiddleTexture).Value, surfacePosition,
                MiddleBGYOffset, 1.25f, 0.4f, 1800.0f, 1500.0f, 320, 0, 1.2f, pushBGTopHack);
            BackgroundHelper.DrawLayer(ModContent.Request<Texture2D>(CloseTexture).Value, surfacePosition,
                CloseBGYOffset, 1.31f, 0.43f, 1950.0f, 1750.0f, 400, 80, 1f, pushBGTopHack);
        }
        
        return false;
    }
}