using System;
using BiomeExpansion.Core.Particle;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.NetModules;
using Terraria.Graphics.Renderers;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Net;

namespace BiomeExpansion.Test;

public class TestSummonWeapon : ModItem
{
    public override void SetStaticDefaults() {
		ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true; // This lets the player target anywhere on the whole screen while using a controller
		ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		ItemID.Sets.StaffMinionSlotsRequired[Type] = 1f; // The default value is 1, but other values are supported. See the docs for more guidance. 
	}

    public override void SetDefaults()
    {
        Item.damage = 2;
		Item.knockBack = 3f;
		Item.mana = 0; // mana cost
		Item.width = 32;
		Item.height = 32;
		Item.useTime = 36;
		Item.useAnimation = 36;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.value = Item.sellPrice(gold: 30);
		Item.rare = ItemRarityID.Cyan;
		Item.UseSound = SoundID.Item44;
        Item.noMelee = true;
        Item.DamageType = DamageClass.Summon;
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

public class TestMinion : ModProjectile
{
	public override void SetStaticDefaults() {
		Main.projFrames[Projectile.type] = 4;
		ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
		Main.projPet[Projectile.type] = true; // Denotes that this projectile is a pet or minion
		ProjectileID.Sets.MinionSacrificable[Projectile.type] = true; // This is needed so your minion can properly spawn when summoned and replaced when other minions are summoned
		ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true; // Make the cultist resistant to this projectile, as it's resistant to all homing projectiles.
	}

	public sealed override void SetDefaults() {
		Projectile.width = 18;
		Projectile.height = 28;
		Projectile.tileCollide = false; // Makes the minion go through tiles freely

		Projectile.aiStyle = ProjAIStyleID.EnchantedDagger;
		AIType = ProjectileID.MagicDagger;
		Projectile.friendly = true; // Only controls if it deals damage to enemies on contact (more on that later)
		Projectile.minion = true; // Declares this as a minion (has many effects)
		Projectile.DamageType = DamageClass.Summon; // Declares the damage type (needed for it to deal damage)
		Projectile.minionSlots = 1f; // Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
		Projectile.penetrate = -1; // Needed so the minion doesn't despawn on collision with enemies or tiles
	}

	// Here you can decide if your minion breaks things like grass or pots
	public override bool? CanCutTiles() {
		return false;
	}

	// This is mandatory if your minion deals contact damage (further related stuff in AI() in the Movement region)
	public override bool MinionContactDamage() {
		return true;
	}

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {				
		FrameHelper.AnimateProjectile(Projectile, 1);
	}
}

public class TestMinionBuff : ModBuff
{
	public override void SetStaticDefaults() {
		Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
		Main.buffNoTimeDisplay[Type] = true; // The time remaining won't display on this buff
	}

	public override void Update(Player player, ref int buffIndex) {
		// If the minions exist reset the buff time, otherwise remove the buff from the player
		if (player.ownedProjectileCounts[ModContent.ProjectileType<TestMinion>()] > 0) {
			player.buffTime[buffIndex] = 18000;
		}
		else {
			player.DelBuff(buffIndex);
			buffIndex--;
		}
	}
}
