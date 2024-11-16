namespace BiomeExpansion.Content.Items.NPCs.Critters;

public class CrimsonInfectedCaterpillar : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedCaterpillar"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToCapturedCritter(ModContent.NPCType<BiomeExpansion.Content.NPCs.Critters.CrimsonInfectedCaterpillar>());
        Item.width = 12;
        Item.height = 12;
    }
}