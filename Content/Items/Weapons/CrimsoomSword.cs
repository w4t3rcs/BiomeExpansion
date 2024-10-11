using BiomeExpansion.Helpers;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Weapons;

public class CrimsoomSword : ModItem
{
    public override string Texture => TextureHelper.GetDynamicItemTexture("CrimsoomSword");

    public override void SetDefaults()
    {
        Item.width = 50;
        Item.height = 60;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee;
        Item.damage = 31;
        Item.knockBack = 5;
        Item.crit = 6;
        Item.UseSound = SoundID.Item1;
    }
}