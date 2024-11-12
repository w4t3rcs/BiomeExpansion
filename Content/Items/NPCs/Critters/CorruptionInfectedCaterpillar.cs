namespace BiomeExpansion.Content.Items.NPCs.Critters;

public class CorruptionInfectedCaterpillar : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedCaterpillar"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToCapturedCritter(ModContent.NPCType<Content.NPCs.CorruptionInfectedCaterpillar>());
        Item.width = 12;
        Item.height = 12;
    }
}