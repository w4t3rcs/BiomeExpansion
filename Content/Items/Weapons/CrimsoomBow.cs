using BiomeExpansion.Helpers;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Weapons;

public class CrimsoomBow : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsoomBow"];

    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 40;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.useTime = 12;
        Item.useAnimation = 18;
        Item.reuseDelay = 18;
        Item.useLimitPerAnimation = 1;
        Item.DamageType = DamageClass.Ranged;
        Item.damage = 16;
        Item.knockBack = 1;
        Item.crit = 6;
        Item.UseSound = SoundID.Item5;
        Item.noMelee = true;
        Item.shoot = ProjectileID.WoodenArrowFriendly;
        Item.shootSpeed = 7f;
        Item.useAmmo = AmmoID.Arrow;
    }
}