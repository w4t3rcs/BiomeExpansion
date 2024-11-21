using System;
using System.Collections.Generic;
using BiomeExpansion.Content.Biomes;
using BiomeExpansion.Content.Buffs;
using BiomeExpansion.Content.Items.Placeable.Banners;
using Terraria.GameContent;

namespace BiomeExpansion.Content.NPCs.Enemies;

public class SmallTerrorGhost : ModNPC
{
    public override string Texture => TextureHelper.DynamicNPCsTextures["SmallTerrorGhost"];
    private const float _baseSpeed = 4f;
    private const float _baseAcceleration = 0.05f;

    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[NPC.type] = 3;
    }

    public override void SetDefaults()
    {
        NPC.aiStyle = -1;
        NPC.damage = 30;
        NPC.width = 28;
        NPC.height = 34;
        NPC.defense = 4;
        NPC.lifeMax = 37;
        NPC.knockBackResist = 0.2f;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
        NPC.value = Item.buyPrice(0, 0, 4, 0);
        NPC.HitSound = SoundID.NPCHit36;
        NPC.DeathSound = SoundID.NPCDeath39;
        Banner = NPC.type;
        SpawnModBiomes = [ModContent.GetInstance<CorruptionInfectedMushroomSurfaceBiome>().Type, ModContent.GetInstance<CrimsonInfectedMushroomSurfaceBiome>().Type];
        BannerItem = ModContent.ItemType<SmallTerrorGhostBanner>();
        NPCHelper.AdjustExpertMode(NPC);
        NPCHelper.AdjustMasterMode(NPC);
    }

    public override void AI()
    {
        TargetClosest();
        NPC.netUpdate = true;
    }

    private void TargetClosest()
    {
        NPC.TargetClosest(true);
        if (NPC.HasValidTarget)
        {
            Vector2 direction = Main.player[NPC.target].Center - NPC.Center;
            direction.Normalize();
            direction *= _baseSpeed;
            NPC.velocity.X = NPC.velocity.X * (1f - _baseAcceleration) + direction.X * _baseAcceleration;
            NPC.velocity.Y = NPC.velocity.Y * (1f - _baseAcceleration) + direction.Y * _baseAcceleration;
        }
    }

    public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
    {
        spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, NPC.Center - screenPos, NPC.frame, Color.White * 0.6f, NPC.rotation, NPC.frame.Size() / 2f, NPC.scale, NPC.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
    }

    public override void FindFrame(int frameHeight)
    {
        Lighting.AddLight(NPC.Center, 0.6f, 0.0f, 0.4f);
        FrameHelper.AnimateNPC(NPC, frameHeight, 6, 3);
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange([
            new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.SmallTerrorGhost")
        ]);
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.Player.InModBiome<CorruptionInfectedMushroomSurfaceBiome>() || spawnInfo.Player.InModBiome<CrimsonInfectedMushroomSurfaceBiome>())
        {
            return 0.15f;
        }

        return 0f;
    }

    public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
    {
        if (hurtInfo.Damage > 0)
        {
            if (Main.hardMode)
            {
                if (WorldGen.crimson)
                {
                    target.AddBuff(ModContent.BuffType<CrimsonSpawnrateDebuffTier2>(), 2400, true);
                }
                else
                {
                    target.AddBuff(ModContent.BuffType<CorruptionSpawnrateDebuffTier2>(), 2400, true);
                }
            }
            else
            {
                if (WorldGen.crimson)
                {
                    target.AddBuff(ModContent.BuffType<CrimsonSpawnrateDebuffTier1>(), 1800, true);
                }
                else
                {
                    target.AddBuff(ModContent.BuffType<CorruptionSpawnrateDebuffTier1>(), 1800, true);
                }
            }
        }
    }

    public override void HitEffect(NPC.HitInfo hit)
    {
        NPCHelper.DoHitDust(NPC, hit.HitDirection, DustID.PinkTorch);
    }
}