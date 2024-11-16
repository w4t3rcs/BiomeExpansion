namespace BiomeExpansion.Content.Items.NPCs.Critters;

public class CrimsonInfectedFly : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedFly"];


    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToCapturedCritter(ModContent.NPCType<Content.NPCs.Critters.CrimsonInfectedFly>());
        Item.width = 12;
        Item.height = 12;
    }
}
