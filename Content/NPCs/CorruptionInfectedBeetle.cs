using BiomeExpansion.Content.Biomes;
using BiomeExpansion.Content.Buffs;

namespace BiomeExpansion.Content.NPCs;

public class CorruptionInfectedBeetle : ModNPC
{
    public override string Texture => TextureHelper.DynamicNPCsTextures["CorruptionInfectedBeetle"];

    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[NPC.type] = 2;
    }

    public override void SetDefaults()
    {
        NPC.aiStyle = NPCAIStyleID.Fighter;
        AIType = NPCID.LarvaeAntlion;
        NPC.damage = 30;
        NPC.width = 34;
        NPC.height = 48;
        NPC.defense = 10;
        NPC.lifeMax = 40;
        NPC.knockBackResist = 0.6f;
        AnimationType = NPCID.CyanBeetle;
        NPC.value = Item.buyPrice(0, 0, 7, 0);
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath16;
        Banner = NPC.type;
        SpawnModBiomes = [ModContent.GetInstance<CorruptionInfectedMushroomSurfaceBiome>().Type];
        // BannerItem = ModContent.ItemType<>();
        NPCHelper.AdjustExpertMode(NPC);
        NPCHelper.AdjustMasterMode(NPC);
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange([
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,
            new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CorruptionInfectedBeetle")
        ]);
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.Player.InModBiome<CorruptionInfectedMushroomSurfaceBiome>())
        {
            if (spawnInfo.Player.ZoneRockLayerHeight)
            {
                return 0.35f;
            }

            return 0.2f;
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
    }

    // public override void ModifyNPCLoot(NPCLoot npcLoot) => npcLoot.Add(ModContent.ItemType<>(), 1, 10, 26);
}