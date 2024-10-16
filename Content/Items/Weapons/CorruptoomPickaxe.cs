﻿using BiomeExpansion.Helpers;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Weapons;

public class CorruptoomPickaxe : ModItem
{
    public override string Texture => TextureHelper.GetDynamicItemTexture("CorruptoomPickaxe");

    public override void SetDefaults()
    {
        Item.width = 40;
        Item.height = 40;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee;
        Item.damage = 10;
        Item.knockBack = 2;
        Item.UseSound = SoundID.Item1;
        Item.pick = 60;
        Item.attackSpeedOnlyAffectsWeaponAnimation = true;
    }
}