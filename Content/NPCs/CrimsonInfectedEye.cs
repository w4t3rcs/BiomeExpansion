using BiomeExpansion.Content.Biomes;
using BiomeExpansion.Content.Buffs;
using Terraria.GameContent.ItemDropRules;

namespace BiomeExpansion.Content.NPCs;

public class CrimsonInfectedEye : ModNPC
{
    public override string Texture => TextureHelper.DynamicNPCsTextures["CrimsonInfectedEye"];

    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[NPC.type] = 2;
    }

    public override void SetDefaults()
    {
        NPC.aiStyle = NPCAIStyleID.DemonEye;
        AIType = NPCID.DemonEye;
        NPC.damage = 24;
        NPC.width = 38;
        NPC.height = 24;
        NPC.defense = 4;
        NPC.lifeMax = 61;
        NPC.knockBackResist = 0.3f;
        NPC.noGravity = true;
        AnimationType = NPCID.DemonEye;
        NPC.value = Item.buyPrice(0, 0, 1, 0);
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
        bestiaryEntry.Info.AddRange([
            new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CrimsonInfectedEye")
        ]);
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.Player.InModBiome<CrimsonInfectedMushroomSurfaceBiome>() && spawnInfo.Player.ZoneOverworldHeight && !Main.dayTime)
        {
            return 0.5f;
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
        NPCHelper.DoHitDust(NPC, hit.HitDirection, DustID.Crimson);
        NPCHelper.CreateGoreOnDeath(NPC, "CrimsonInfectedEyeGore1");
        NPCHelper.CreateGoreOnDeath(NPC, "CrimsonInfectedEyeGore2");
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot) => npcLoot.Add(new CommonDrop(ItemID.Lens, 2, 1, 1));
}