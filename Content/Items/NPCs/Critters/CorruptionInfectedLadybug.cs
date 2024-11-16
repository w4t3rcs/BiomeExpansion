namespace BiomeExpansion.Content.Items.NPCs.Critters;

public class CorruptionInfectedLadybug : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedLadybug"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToCapturedCritter(ModContent.NPCType<BiomeExpansion.Content.NPCs.Critters.CorruptionInfectedLadybug>());
        Item.width = 12;
        Item.height = 12;
    }
}