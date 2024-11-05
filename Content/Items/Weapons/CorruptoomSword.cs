using BiomeExpansion.Core.Particle;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Weapons;

public class CorruptoomSword : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptoomSword"];

    public override void SetDefaults()
    {
        Item.width = 60;
        Item.height = 62;
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

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        // ParticleOrchestraHelper.SpawnOnHit(new TrueNightEdgeParticleOrchestraType(), player.whoAmI, target, [new Color(0.4f, 0.2f, 0.7f, 0.5f), new Color(0.2f, 0.9f, 0.3f, 0.5f)], DustID.GreenTorch);
        ParticleOrchestraHelper.SpawnOnHit(new TerraBladeParticleOrchestraType(), player.whoAmI, target, [new Color(0.5f, 0.2f, 0.8f, 0.6f), new Color(0.2f, 0.9f, 0.3f, 0.6f), new Color(0.1f, 1.4f, 0.5f, 0.6f)], DustID.GreenTorch);
    }
}