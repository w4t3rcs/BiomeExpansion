using Terraria.DataStructures;

namespace BiomeExpansion.Content.Items.NPCs.Critters;

public class CrimsonInfectedFairy : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedFairy"];


    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
        Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(8, 2));
    }

    public override void SetDefaults()
    {
        Item.DefaultToCapturedCritter(ModContent.NPCType<Content.NPCs.Critters.CrimsonInfectedFairy>());
        Item.width = 16;
        Item.height = 18;
    }
}
