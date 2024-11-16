using Terraria.DataStructures;

namespace BiomeExpansion.Content.Items.NPCs.Critters;

public class CorruptionInfectedFairy : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedFairy"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
        Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(8, 2));
    }

    public override void SetDefaults()
    {
        Item.DefaultToCapturedCritter(ModContent.NPCType<BiomeExpansion.Content.NPCs.Critters.CorruptionInfectedFairy>());
        Item.width = 16;
        Item.height = 18;
    }
}