using System;
using BiomeExpansion.Content.Biomes;
using BiomeExpansion.Content.Buffs;

namespace BiomeExpansion.Content.NPCs;

public class TerrorGhost : ModNPC
{
    public override string Texture => TextureHelper.DynamicNPCsTextures["TerrorGhost"];
    private const float _baseSpeed = 3f; 
    private const float _baseAcceleration = 0.05f; 
    protected int leftHandID = -1;
    protected int rightHandID = -1;

    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[NPC.type] = 3;
    }

    public override void SetDefaults()
    {
        NPC.aiStyle = -1;
        NPC.damage = 40;
        NPC.width = 46;
        NPC.height = 60;
        NPC.defense = 6;
        NPC.lifeMax = 51;
        NPC.knockBackResist = 0f;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
        NPC.value = Item.buyPrice(0, 0, 5, 0);
        NPC.HitSound = SoundID.NPCHit36;
        NPC.DeathSound = SoundID.NPCDeath39;
        Banner = NPC.type;
        SpawnModBiomes = [ModContent.GetInstance<CorruptionInfectedMushroomSurfaceBiome>().Type, ModContent.GetInstance<CrimsonInfectedMushroomSurfaceBiome>().Type];
        // BannerItem = ModContent.ItemType<>();
        NPCHelper.AdjustExpertMode(NPC);
        NPCHelper.AdjustMasterMode(NPC);
    }

    public override void FindFrame(int frameHeight)
    {
        if (++NPC.frameCounter >= 6)
        {
            NPC.frameCounter = 0;
            NPC.frame.Y = (NPC.frame.Y + frameHeight) % (frameHeight * 3);
        }
    }

    public override void AI()
    {   
        Lighting.AddLight(NPC.Center, 0.6f, 0.0f, 0.6f);
        NPC.realLife = NPC.whoAmI;
        if (NPC.ai[0] == 0)
        { 
            leftHandID = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X - 40, (int)NPC.Bottom.Y + 20, ModContent.NPCType<TerrorGhostHand>(), ai0: NPC.whoAmI);
            Main.npc[leftHandID].realLife = NPC.whoAmI;
            rightHandID = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X + 40, (int)NPC.Bottom.Y + 20, ModContent.NPCType<TerrorGhostHand>(), ai0: NPC.whoAmI, ai1: 1);
            Main.npc[rightHandID].realLife = NPC.whoAmI;
            Main.npc[leftHandID].ai[2] = rightHandID;
            Main.npc[rightHandID].ai[2] = leftHandID;
            NPC.ai[0] = 1;
        }

        NPC.TargetClosest(true);
        if (NPC.HasValidTarget)
        {
            if (!NPC.Center.WithinRange(Main.player[NPC.target].Center, 20f)) 
            {
                Vector2 direction = Main.player[NPC.target].Center - NPC.Center;
                direction.Normalize();
                direction *= _baseSpeed;
                NPC.velocity.X = (NPC.velocity.X * (1f - _baseAcceleration)) + (direction.X * _baseAcceleration);
                NPC.velocity.Y = (NPC.velocity.Y * (1f - _baseAcceleration)) + (direction.Y * _baseAcceleration);
            }
            else
            {
                NPC.damage = 0;
                Lighting.AddLight(NPC.Center, 2f, 0.0f, 2f);
            }
        }

        
        NPC.netUpdate = true;
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange([
            new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.TerrorGhost")
        ]);
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.Player.InModBiome<CorruptionInfectedMushroomSurfaceBiome>() || spawnInfo.Player.InModBiome<CrimsonInfectedMushroomSurfaceBiome>())
        {
            return 0.25f;
        }

        return 0f;
    }

    public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
    {
        if (hurtInfo.Damage > 0)
        {
            if (WorldGen.crimson) target.AddBuff(ModContent.BuffType<CrimsonSporeInfectionDebuff>(), 2400, true);
            else target.AddBuff(ModContent.BuffType<CorruptionSporeInfectionDebuff>(), 2400, true);
        }
    }

    public override void HitEffect(NPC.HitInfo hit)
    {
        NPCHelper.DoHitDust(NPC, hit.HitDirection, DustID.PinkTorch);
    }
}

public class TerrorGhostHand : ModNPC
{
    public override string Texture => TextureHelper.DynamicNPCsTextures["TerrorGhostHand"];
    private const float _baseSpeed = 5f; 
    private const float _baseAcceleration = 0.05f;
    private const float _curveAmplitude = 0.145f;
    private const float _curveFrequency = 0.085f;
    private int _damage;

    public override void SetDefaults()
    {
        NPC.aiStyle = -1;
        NPC.lifeMax = 10;
        NPC.damage = 20;
        NPC.width = 32;
        NPC.height = 24;
        NPC.knockBackResist = 0.8f;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
        NPC.HitSound = SoundID.NPCHit36;
        NPCHelper.AdjustExpertMode(NPC);
        NPCHelper.AdjustMasterMode(NPC);
        _damage = NPC.damage;
    }

    public override void DrawBehind(int index)
    {
        Main.instance.DrawCacheNPCsOverPlayers.Add(index);
    }

    public override void AI()
    {   
        Lighting.AddLight(NPC.Center, 0.4f, 0.0f, 0.4f);
        int parentId = (int)NPC.ai[0];
        NPC parent = Main.npc[parentId];
        if (NPC.ai[0] != 0 && parent != null && parent.active)
        {
            bool isRightHand = NPC.ai[1] == 1;
            NPC.TargetClosest(true);
            if (NPC.HasValidTarget)
            {
                Player player = Main.player[NPC.target];
                Vector2 direction = player.Center - NPC.Center;
                NPC.rotation = direction.ToRotation();
                direction.Normalize();
                direction *= _baseSpeed;
                NPC.velocity.X = (NPC.velocity.X * (1f - _baseAcceleration)) + (direction.X * _baseAcceleration);
                NPC.velocity.Y = (NPC.velocity.Y * (1f - _baseAcceleration)) + (direction.Y * _baseAcceleration);
                if (!NPC.Center.WithinRange(player.Center, 15f))
                {
                    float curveOffset = (float)(Math.Sin(Main.GameUpdateCount * _curveFrequency) * _curveAmplitude);
                    NPC.velocity.Y += isRightHand ? curveOffset : -curveOffset;
                    NPC.velocity.X += isRightHand ? -curveOffset : curveOffset;
                    NPC.damage = 0;
                }
                else
                {
                    Main.npc[(int)NPC.ai[2]].Center = NPC.Center;
                    NPC.damage = _damage;
                    NPC.defense = 20;
                    NPC.rotation = 0;
                    NPC.spriteDirection = NPC.direction = NPC.velocity.X > 0 ? 1 : -1;
                    player.velocity *= 0;
                    player.Center = NPC.Center;
                    Lighting.AddLight(NPC.Center, 1.7f, 0.0f, 1.7f);
                }
            }
            NPC.netUpdate = true;
        }
        else
        {
            NPC.active = false;
        }
    }
    
    public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
    {
        if (hurtInfo.Damage > 0)
        {
            if (WorldGen.crimson) target.AddBuff(ModContent.BuffType<CrimsonSporeInfectionDebuff>(), 2400, true);
            else target.AddBuff(ModContent.BuffType<CorruptionSporeInfectionDebuff>(), 2400, true);
        }
    }

    public override void HitEffect(NPC.HitInfo hit)
    {
        NPCHelper.DoHitDust(NPC, hit.HitDirection, DustID.PinkTorch);
    }

    public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
    {
        return false;
    }
}