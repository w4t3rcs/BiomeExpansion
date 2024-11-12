namespace BiomeExpansion.Content.Items.NPCs.Critters;

public class CorruptionInfectedStagBeetle : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedStagBeetle"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToCapturedCritter(ModContent.NPCType<Content.NPCs.CorruptionInfectedStagBeetle>());
        Item.width = 12;
        Item.height = 12;
    }
}