﻿namespace BiomeExpansion.Content.Items.NPCs.Critters;

public class CorruptionInfectedFly : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedFly"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToCapturedCritter(ModContent.NPCType<Content.NPCs.CorruptionInfectedFly>());
        Item.width = 12;
        Item.height = 12;
    }
}