using BiomeExpansion.Content.Biomes;
using BiomeExpansion.Content.Buffs;

namespace BiomeExpansion.Content.NPCs;

public class FearClot : ModNPC
{
    public override string Texture => TextureHelper.DynamicNPCsTextures["FearClot"];

    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[NPC.type] = 4;
    }

    public override void SetDefaults()
    {
        NPC.aiStyle = NPCAIStyleID.DemonEye;
        AIType = NPCID.DemonEye;
        NPC.damage = 21;
        NPC.width = 54;
        NPC.height = 32;
        NPC.defense = 6;
        NPC.lifeMax = 24;
        NPC.knockBackResist = 0f;
        NPC.noGravity = true;
        AnimationType = NPCID.Pixie;
        NPC.value = Item.buyPrice(0, 0, 5, 0);
        NPC.HitSound = SoundID.NPCHit5;
        NPC.DeathSound = SoundID.NPCDeath7;
        Banner = NPC.type;
        SpawnModBiomes = [ModContent.GetInstance<CorruptionInfectedMushroomSurfaceBiome>().Type, ModContent.GetInstance<CrimsonInfectedMushroomSurfaceBiome>().Type];
        // BannerItem = ModContent.ItemType<>();
        NPCHelper.AdjustExpertMode(NPC);
        NPCHelper.AdjustMasterMode(NPC);
    }

    public override void AI()
    {
        Lighting.AddLight(NPC.Center, 0.3f, 0.0f, 0.5f);
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange([
            new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.FearClot")
        ]);
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.Player.InModBiome<CorruptionInfectedMushroomSurfaceBiome>() || spawnInfo.Player.InModBiome<CrimsonInfectedMushroomSurfaceBiome>())
        {
            return 0.2f;
        }

        return 0f;
    }

    public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
    {
        if (hurtInfo.Damage > 0)
        {
            if (WorldGen.crimson)
            {
                target.AddBuff(ModContent.BuffType<CrimsonSporeInfectionDebuff>(), 2400, true);
                target.AddBuff(ModContent.BuffType<CrimsonSpawnrateDebuff>(), 1800, true);
            }
            else
            {
                target.AddBuff(ModContent.BuffType<CorruptionSporeInfectionDebuff>(), 2400, true);
                target.AddBuff(ModContent.BuffType<CorruptionSpawnrateDebuff>(), 1800, true);
            }
        }
    }

    public override void HitEffect(NPC.HitInfo hit)
    {
        NPCHelper.DoHitDust(NPC, hit.HitDirection, DustID.PurpleTorch);
    }
}