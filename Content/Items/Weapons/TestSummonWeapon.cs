using BiomeExpansion.Common.Utils;
using BiomeExpansion.Content.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Weapons;

public class TestSummonWeapon : ModItem
{
    public override string Texture => TextureUtil.GetDynamicTexture("TestSummonWeapon");
    
    public override void SetStaticDefaults() {
        ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
        ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;

        ItemID.Sets.StaffMinionSlotsRequired[Type] = 1f;
    }
    
    public override void SetDefaults()
    {
        Item.damage = 30;
        Item.knockBack = 3f;
        Item.mana = 10; // mana cost
        Item.width = 32;
        Item.height = 32;
        Item.useTime = 36;
        Item.useAnimation = 36;
        Item.useStyle = ItemUseStyleID.Swing; // how the player's arm moves when using the item
        Item.value = Item.sellPrice(gold: 30);
        Item.rare = ItemRarityID.Cyan;
        Item.UseSound = SoundID.Item44; // What sound should play when using the item
        Item.buffType = ModContent.BuffType<TestMinionBuff>();
        Item.shoot = ModContent.ProjectileType<TestMinion>();
    }
    
    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
        position = Main.MouseWorld;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        player.AddBuff(Item.buffType, 2);
        var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
        projectile.originalDamage = Item.damage;
        return false;
    }
}