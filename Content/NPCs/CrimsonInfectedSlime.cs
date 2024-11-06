using BiomeExpansion.Content.Biomes;
using BiomeExpansion.Content.Buffs;
using BiomeExpansion.Helpers;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.NPCs;

public class CrimsonInfectedSlime : ModNPC
{
    public override string Texture => TextureHelper.DynamicNPCsTextures["CrimsonInfectedSlime"];

    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[NPC.type] = 2;
    }

    public override void SetDefaults()
    {
        NPC.aiStyle = NPCAIStyleID.Slime;
        AIType = NPCID.RedSlime;
        NPC.damage = 15;
        NPC.width = 36;
        NPC.height = 31;
        NPC.defense = 4;
        NPC.lifeMax = 40;
        NPC.knockBackResist = 0.6f;
        AnimationType = NPCID.CorruptSlime;
        NPC.value = Item.buyPrice(0, 0, 1, 0);
        NPC.alpha = 85;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        Banner = NPC.type;
        SpawnModBiomes = [ModContent.GetInstance<CrimsonInfectedMushroomSurfaceBiome>().Type];
        // BannerItem = ModContent.ItemType<>();
        NPCHelper.AdjustExpertMode(NPC);
        NPCHelper.AdjustMasterMode(NPC);
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
        {
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson,
            new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CrimsonInfectedSlime")
        });
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.Player.InModBiome<CrimsonInfectedMushroomSurfaceBiome>())
        {
            if (spawnInfo.Player.ZoneOverworldHeight)
            {
                return 0.66f;
            }

            return 0.33f;
        }
        
        return 0;
    }

    public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
    {
        if (hurtInfo.Damage > 0)
        {
            target.AddBuff(ModContent.BuffType<CrimsonSporeInfectionDebuff>(), 1200, true);
        }
    }

    public override void HitEffect(NPC.HitInfo hit)
    {
        NPCHelper.DoHitDust(NPC, hit.HitDirection, DustID.Corruption);
    }

    // public override void ModifyNPCLoot(NPCLoot npcLoot) => npcLoot.Add(ModContent.ItemType<>(), 1, 10, 26);
}