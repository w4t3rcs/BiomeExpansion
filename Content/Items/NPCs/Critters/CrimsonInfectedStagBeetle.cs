namespace BiomeExpansion.Content.Items.NPCs.Critters;

public class CrimsonInfectedStagBeetle : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedStagBeetle"];


    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToCapturedCritter(ModContent.NPCType<Content.NPCs.Critters.CrimsonInfectedStagBeetle>());
        Item.width = 12;
        Item.height = 12;
    }
}
