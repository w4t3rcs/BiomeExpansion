﻿using System;
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

			// These below are needed for a minion weapon
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

	// The AI of this minion is split into multiple methods to avoid bloat. This method just passes values between calls actual parts of the AI.
	public override void AI() {
		Player owner = Main.player[Projectile.owner];
		if (!CheckActive(owner)) return;
		GeneralBehavior(owner, out Vector2 vectorToIdlePosition, out float distanceToIdlePosition);
		SearchForTargets(owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter);
		Movement(foundTarget, distanceFromTarget, targetCenter, distanceToIdlePosition, vectorToIdlePosition);
		Visuals();
	}

		// This is the "active check", makes sure the minion is alive while the player is alive, and despawns if not
	private bool CheckActive(Player owner) {
		if (owner.dead || !owner.active) {
            owner.ClearBuff(ModContent.BuffType<TestMinionBuff>());
			return false;
		}

		if (owner.HasBuff(ModContent.BuffType<TestMinionBuff>())) {
			Projectile.timeLeft = 2;
		}

		return true;
	}

	private void GeneralBehavior(Player owner, out Vector2 vectorToIdlePosition, out float distanceToIdlePosition) {
		Vector2 idlePosition = owner.Center;
		idlePosition.Y -= 48f; // Go up 48 coordinates (three tiles from the center of the player)

		// If your minion doesn't aimlessly move around when it's idle, you need to "put" it into the line of other summoned minions
		// The index is projectile.minionPos
		float minionPositionOffsetX = (10 + Projectile.minionPos * 40) * -owner.direction;
		idlePosition.X += minionPositionOffsetX; // Go behind the player

		// All of this code below this line is adapted from Spazmamini code (ID 388, aiStyle 66)

			// Teleport to player if distance is too big
		vectorToIdlePosition = idlePosition - Projectile.Center;
		distanceToIdlePosition = vectorToIdlePosition.Length();

		if (Main.myPlayer == owner.whoAmI && distanceToIdlePosition > 2000f) {
			// Whenever you deal with non-regular events that change the behavior or position drastically, make sure to only run the code on the owner of the projectile,
			// and then set netUpdate to true
			Projectile.position = idlePosition;
			Projectile.velocity *= 0.1f;
			Projectile.netUpdate = true;
		}

			// If your minion is flying, you want to do this independently of any conditions
		float overlapVelocity = 0.04f;

			// Fix overlap with other minions
		foreach (var other in Main.ActiveProjectiles) {
			if (other.whoAmI != Projectile.whoAmI && other.owner == Projectile.owner && Math.Abs(Projectile.position.X - other.position.X) + Math.Abs(Projectile.position.Y - other.position.Y) < Projectile.width) {
				if (Projectile.position.X < other.position.X) {
					Projectile.velocity.X -= overlapVelocity;
				}
				else {
					Projectile.velocity.X += overlapVelocity;
				}

				if (Projectile.position.Y < other.position.Y) {
					Projectile.velocity.Y -= overlapVelocity;
				}
				else {
					Projectile.velocity.Y += overlapVelocity;
				}
			}
		}
	}

	private void SearchForTargets(Player owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter) {
		// Starting search distance
		distanceFromTarget = 700f;
		targetCenter = Projectile.position;
		foundTarget = false;

		// This code is required if your minion weapon has the targeting feature
		if (owner.HasMinionAttackTargetNPC) {
			NPC npc = Main.npc[owner.MinionAttackTargetNPC];
			float between = Vector2.Distance(npc.Center, Projectile.Center);
				// Reasonable distance away so it doesn't target across multiple screens
			if (between < 2000f) {
				distanceFromTarget = between;
				targetCenter = npc.Center;
				foundTarget = true;
			}
			else if (between <= 30)
			{
				int frameSpeed = 5;
				Projectile.frameCounter++;
				if (Projectile.frameCounter >= frameSpeed) {
					Projectile.frameCounter = 0;
					Projectile.frame++;
					if (Projectile.frame >= Main.projFrames[Projectile.type]) {
						Projectile.frame = 0;
					}
				}
			}
		}

		if (!foundTarget) {
				// This code is required either way, used for finding a target
			foreach (var npc in Main.ActiveNPCs) {
				if (npc.CanBeChasedBy()) {
					float between = Vector2.Distance(npc.Center, Projectile.Center);
					bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
					bool inRange = between < distanceFromTarget;
					bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
					// Additional check for this specific minion behavior, otherwise it will stop attacking once it dashed through an enemy while flying though tiles afterwards
					// The number depends on various parameters seen in the movement code below. Test different ones out until it works alright
					bool closeThroughWall = between < 100f;

					if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
						distanceFromTarget = between;
						targetCenter = npc.Center;
						foundTarget = true;
					}
				}
			}
		}

			// friendly needs to be set to true so the minion can deal contact damage
			// friendly needs to be set to false so it doesn't damage things like target dummies while idling
			// Both things depend on if it has a target or not, so it's just one assignment here
			// You don't need this assignment if your minion is shooting things instead of dealing contact damage
		Projectile.friendly = foundTarget;
	}

	private void Movement(bool foundTarget, float distanceFromTarget, Vector2 targetCenter, float distanceToIdlePosition, Vector2 vectorToIdlePosition) {
			// Default movement parameters (here for attacking)
		float speed = 8f;
		float inertia = 20f;
		if (foundTarget) {
			// Minion has a target: attack (here, fly towards the enemy)
			if (distanceFromTarget > 40f) {
				// The immediate range around the target (so it doesn't latch onto it when close)
				Vector2 direction = targetCenter - Projectile.Center;
				direction.Normalize();
				direction *= speed;
				Projectile.velocity = (Projectile.velocity * (inertia - 1) + direction) / inertia;
			}
		}
		else {
			// Minion doesn't have a target: return to player and idle
			if (distanceToIdlePosition > 600f) {
				// Speed up the minion if it's away from the player
				speed = 12f;
				inertia = 60f;
			}
			else {
				// Slow down the minion if closer to the player
				speed = 4f;
				inertia = 80f;
			}
			if (distanceToIdlePosition > 20f) {
					// The immediate range around the player (when it passively floats about)

					// This is a simple movement formula using the two parameters and its desired direction to create a "homing" movement
				vectorToIdlePosition.Normalize();
				vectorToIdlePosition *= speed;
				Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
			}
			else if (Projectile.velocity == Vector2.Zero) {
				// If there is a case where it's not moving at all, give it a little "poke"
				Projectile.velocity.X = -0.15f;
				Projectile.velocity.Y = -0.05f;
			}
		}
	}

	private void Visuals() {
		Projectile.rotation = Projectile.velocity.X * 0.05f;
		Lighting.AddLight(Projectile.Center, Color.White.ToVector3() * 0.78f);
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
