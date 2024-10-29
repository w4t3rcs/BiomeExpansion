using BiomeExpansion.Helpers;
using Terraria;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Plants;

public class CorruptionInfectedSmallMushroom : ModItem
{
    public override string Texture => TextureHelper.GetDynamicItemTexture("CorruptionInfectedSmallMushroom");
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.width = 12;
        Item.height = 12;
        Item.maxStack = Item.CommonMaxStack;
    }
}