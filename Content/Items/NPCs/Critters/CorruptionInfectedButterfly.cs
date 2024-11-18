namespace BiomeExpansion.Content.Items.NPCs.Critters;

public class CorruptionInfectedButterfly : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedButterfly"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToCapturedCritter(ModContent.NPCType<Content.NPCs.Critters.CorruptionInfectedButterfly>());
        Item.width = 12;
        Item.height = 12;
        Item.bait = 25;
    }
}