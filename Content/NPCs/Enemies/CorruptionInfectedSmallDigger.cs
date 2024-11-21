using BiomeExpansion.Content.Biomes;
using BiomeExpansion.Content.Buffs;
using BiomeExpansion.Content.Items.Placeable.Banners;

namespace BiomeExpansion.Content.NPCs.Enemies;

internal class CorruptionInfectedSmallDiggerHead : WormHead
{
    public override string Texture => TextureHelper.DynamicNPCsTextures["CorruptionInfectedSmallDiggerHead"];
    public override int BodyType => ModContent.NPCType<CorruptionInfectedSmallDiggerBody>();
    public override int TailType => ModContent.NPCType<CorruptionInfectedSmallDiggerTail>();

    public override void SetDefaults()
    {
        NPC.aiStyle = -1;
        NPC.CloneDefaults(NPCID.DiggerHead);
        NPC.damage = 30;
        NPC.defense = 2;
        NPC.lifeMax = 30;
        NPC.value = Item.buyPrice(0, 0, 10, 0);
        Banner = NPC.type;
        SpawnModBiomes = [ModContent.GetInstance<CorruptionInfectedMushroomSurfaceBiome>().Type];
        BannerItem = ModContent.ItemType<CorruptionInfectedSmallDiggerBanner>();
        NPCHelper.AdjustExpertMode(NPC, false);
        NPCHelper.AdjustMasterMode(NPC, false);
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange([
            new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CorruptionInfectedSmallDigger")
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
        NPCHelper.CreateGoreOnDeath(NPC, "CorruptionInfectedSmallDiggerHeadGore");
    }

    public override void Init()
    {
        MinSegmentLength = 6;
        MaxSegmentLength = 12;
        CommonWormInit(this);
    }

    internal static void CommonWormInit(Worm worm)
    {
        worm.MoveSpeed = 6f;
        worm.Acceleration = 0.12f;
    }
}

internal class CorruptionInfectedSmallDiggerBody : WormBody
{
    public override string Texture => TextureHelper.DynamicNPCsTextures["CorruptionInfectedSmallDiggerBody"];
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
        NPC.CloneDefaults(NPCID.DiggerBody);
        NPC.damage = 13;
        NPC.defense = 7;
        NPC.lifeMax = 30;
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
        NPCHelper.CreateGoreOnDeath(NPC, "CorruptionInfectedSmallDiggerBodyGore");
    }

    public override void Init()
    {
        CorruptionInfectedSmallDiggerHead.CommonWormInit(this);
    }
}

internal class CorruptionInfectedSmallDiggerTail : WormTail
{
    public override string Texture => TextureHelper.DynamicNPCsTextures["CorruptionInfectedSmallDiggerTail"];
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
        NPC.CloneDefaults(NPCID.DiggerTail);
        NPC.damage = 15;
        NPC.defense = 15;
        NPC.lifeMax = 30;
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
        NPCHelper.CreateGoreOnDeath(NPC, "CorruptionInfectedSmallDiggerTailGore");
    }

    public override void Init()
    {
        CorruptionInfectedSmallDiggerHead.CommonWormInit(this);
    }
}