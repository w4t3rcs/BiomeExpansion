namespace BiomeExpansion.Content.Items.NPCs.Critters;

public class CrimsonInfectedLadybug : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedLadybug"];


    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToCapturedCritter(ModContent.NPCType<Content.NPCs.Critters.CrimsonInfectedLadybug>());
        Item.width = 12;
        Item.height = 12;
        Item.bait = 25;
    }
}
