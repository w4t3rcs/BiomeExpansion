namespace BiomeExpansion.Content.Items.Weapons;

public class CrimsoomAxe : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsoomAxe"];

    public override void SetDefaults()
    {
        Item.width = 50;
        Item.height = 48;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 35;
        Item.useAnimation = 35;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee;
        Item.damage = 21;
        Item.knockBack = 5;
        Item.UseSound = SoundID.Item1;
        Item.axe = 15;
        Item.attackSpeedOnlyAffectsWeaponAnimation = true;
    }
}