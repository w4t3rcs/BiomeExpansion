﻿using Terraria.ModLoader;

namespace BiomeExpansion.Backgrounds;

public class СrimsonInfectedMushroomSurfaceBiomeBGUGStyle : ModUndergroundBackgroundStyle
{ 
    private const string Texture = "BiomeExpansion/Assets/Backgrounds/CrimsonInfectedMushroomSurfaceBiomeUG";

    public override void FillTextureArray(int[] textureSlots)
    {
        for (int i = 0; i < 3; i++)
        {
            textureSlots[i] = BackgroundTextureLoader.GetBackgroundSlot(Texture + i);
        }
    }
}