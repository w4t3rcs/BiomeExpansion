using System;
using BiomeExpansion.Content.Particle;
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

public class TestSword : ModItem
{
    public override string Texture => TextureHelper.GetDynamicItemTexture("CorruptoomSword");

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
        Item.rare = ItemRarityID.Purple;
        Item.UseSound = SoundID.Item1;
    }

    public override void UseAnimation(Player player)
    {
        player.itemLocation += new Vector2(-12f * player.direction, 2f * player.gravDir).RotatedBy(player.itemRotation);
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        ParticleOrchestraHelper.SpawnOnHit(new XParticleOrchestraType(), player.whoAmI, target, [Color.DarkOliveGreen, Color.Green], 30f, new ParticleOrchestraSettings());
    }
}