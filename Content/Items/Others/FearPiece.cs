using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Others;

public class FearPiece : ModItem
{
    public override string Texture => TextureHelper.GetDynamicItemTexture("FearPiece");
    
    public override void SetStaticDefaults()
    {
        Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(10, 7));
        ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        ItemID.Sets.ItemNoGravity[Item.type] = true;  
        Item.ResearchUnlockCount = 25;
    }

    public override void SetDefaults()
    {
        Item.width = 42;
        Item.height = 60;
        Item.maxStack = Item.CommonMaxStack;
        Item.value = 1000;
        Item.rare = ItemRarityID.Orange;
    }
    
    public override void PostUpdate() {
        Lighting.AddLight(Item.Center, Color.Red.ToVector3() * 0.75f * Main.essScale);
    }
}