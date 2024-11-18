namespace BiomeExpansion.Content.Items.NPCs.Critters;

public class CrimsonInfectedButterfly : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedButterfly"];


    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToCapturedCritter(ModContent.NPCType<Content.NPCs.Critters.CrimsonInfectedButterfly>());
        Item.width = 12;
        Item.height = 12;
        Item.bait = 25;
    }
}
