using BiomeExpansion.Content.Biomes;
using BiomeExpansion.Content.Buffs;

namespace BiomeExpansion.Content.NPCs.Enemies;

internal class CorruptionInfectedDiggerHead : WormHead
{
    public override string Texture => TextureHelper.DynamicNPCsTextures["CorruptionInfectedDiggerHead"];
    public override int BodyType => ModContent.NPCType<CorruptionInfectedDiggerBody>();
    public override int TailType => ModContent.NPCType<CorruptionInfectedDiggerTail>();

    public override void SetDefaults()
    {
        NPC.aiStyle = -1;
        NPC.CloneDefaults(NPCID.DuneSplicerHead);
        NPC.damage = 41;
        NPC.defense = 5;
        NPC.lifeMax = 37;
        NPC.value = Item.buyPrice(0, 0, 10, 0);
        Banner = NPC.type;
        SpawnModBiomes = [ModContent.GetInstance<CorruptionInfectedMushroomSurfaceBiome>().Type];
        // BannerItem = ModContent.ItemType<>();
        NPCHelper.AdjustExpertMode(NPC, false);
        NPCHelper.AdjustMasterMode(NPC, false);
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange([
            new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CorruptionInfectedDigger")
        ]);
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.Player.InModBiome<CorruptionInfectedMushroomSurfaceBiome>())
        {
            if (spawnInfo.Player.ZoneDirtLayerHeight || spawnInfo.Player.ZoneRockLayerHeight)
            {
                return 0.2f;
            }

            return 0.1f;
        }

        return 0;
    }

    public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
    {
        if (hurtInfo.Damage > 0)
        {
            target.AddBuff(ModContent.BuffType<CorruptionSporeInfectionDebuff>(), 1200, true);
        }
    }

    public override void HitEffect(NPC.HitInfo hit)
    {
        NPCHelper.DoHitDust(NPC, hit.HitDirection, DustID.Corruption);
        NPCHelper.CreateGoreOnDeath(NPC, "CorruptionInfectedDiggerHeadGore");
    }

    public override void Init()
    {
        MinSegmentLength = 6;
        MaxSegmentLength = 12;
        CommonWormInit(this);
    }

    internal static void CommonWormInit(Worm worm)
    {
        worm.MoveSpeed = 7f;
        worm.Acceleration = 0.1f;
    }
}

internal class CorruptionInfectedDiggerBody : WormBody
{
    public override string Texture => TextureHelper.DynamicNPCsTextures["CorruptionInfectedDiggerBody"];
    public override void SetStaticDefaults()
    {
        NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
        {
            Hide = true
        };
        NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
    }

    public override void SetDefaults()
    {
        NPC.aiStyle = -1;
        NPC.CloneDefaults(NPCID.DuneSplicerBody);
        NPC.damage = 25;
        NPC.defense = 10;
        NPC.lifeMax = 37;
        NPCHelper.AdjustExpertMode(NPC, false);
        NPCHelper.AdjustMasterMode(NPC, false);
    }

    public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
    {
        if (hurtInfo.Damage > 0)
        {
            target.AddBuff(ModContent.BuffType<CorruptionSporeInfectionDebuff>(), 1200, true);
        }
    }

    public override void HitEffect(NPC.HitInfo hit)
    {
        NPCHelper.DoHitDust(NPC, hit.HitDirection, DustID.Corruption);
        NPCHelper.CreateGoreOnDeath(NPC, "CorruptionInfectedDiggerBodyGore");
    }

    public override void Init()
    {
        CorruptionInfectedDiggerHead.CommonWormInit(this);
    }
}

internal class CorruptionInfectedDiggerTail : WormTail
{
    public override string Texture => TextureHelper.DynamicNPCsTextures["CorruptionInfectedDiggerTail"];
    public override void SetStaticDefaults()
    {
        NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
        {
            Hide = true
        };
        NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
    }

    public override void SetDefaults()
    {
        NPC.aiStyle = -1;
        NPC.CloneDefaults(NPCID.DuneSplicerTail);
        NPC.damage = 20;
        NPC.defense = 20;
        NPC.lifeMax = 37;
        NPCHelper.AdjustExpertMode(NPC, false);
        NPCHelper.AdjustMasterMode(NPC, false);
    }

    public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
    {
        if (hurtInfo.Damage > 0)
        {
            target.AddBuff(ModContent.BuffType<CorruptionSporeInfectionDebuff>(), 1200, true);
        }
    }

    public override void HitEffect(NPC.HitInfo hit)
    {
        NPCHelper.DoHitDust(NPC, hit.HitDirection, DustID.Corruption);
        NPCHelper.CreateGoreOnDeath(NPC, "CorruptionInfectedDiggerTailGore");
    }

    public override void Init()
    {
        CorruptionInfectedDiggerHead.CommonWormInit(this);
    }
}