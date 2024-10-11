using BiomeExpansion.Helpers;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Weapons;

public class CrimsoomPickaxe : ModItem
{
    public override string Texture => TextureHelper.GetDynamicItemTexture("CrimsoomPickaxe");

    public override void SetDefaults()
    {
        Item.width = 50;
        Item.height = 40;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee;
        Item.damage = 10;
        Item.knockBack = 2;
        Item.UseSound = SoundID.Item1;
        Item.pick = 65;
        Item.attackSpeedOnlyAffectsWeaponAnimation = true;
    }
}