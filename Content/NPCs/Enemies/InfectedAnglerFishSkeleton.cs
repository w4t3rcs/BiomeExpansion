using BiomeExpansion.Content.Biomes;

namespace BiomeExpansion.Content.NPCs.Enemies;

public class InfectedAnglerFishSkeleton : ModNPC
{
    public override string Texture => TextureHelper.DynamicNPCsTextures["InfectedAnglerFishSkeleton"];

    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[NPC.type] = 6;
    }

    public override void SetDefaults()
    {
        NPC.aiStyle = NPCAIStyleID.Piranha;
        AIType = NPCID.AnglerFish;
        NPC.damage = 30;
        NPC.width = 48;
        NPC.height = 28;
        NPC.defense = 3;
        NPC.lifeMax = 40;
        NPC.knockBackResist = 0.0f;
        NPC.noGravity = true;
        AnimationType = NPCID.Piranha;
        NPC.value = Item.buyPrice(0, 0, 10, 0);
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        Banner = NPC.type;
        SpawnModBiomes = [ModContent.GetInstance<CorruptionInfectedMushroomSurfaceBiome>().Type, ModContent.GetInstance<CrimsonInfectedMushroomSurfaceBiome>().Type];
        // BannerItem = ModContent.ItemType<>();
        NPCHelper.AdjustExpertMode(NPC);
        NPCHelper.AdjustMasterMode(NPC);
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange([
            new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.InfectedAnglerFishSkeleton")
        ]);
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if ((spawnInfo.Player.InModBiome<CorruptionInfectedMushroomSurfaceBiome>() || spawnInfo.Player.InModBiome<CrimsonInfectedMushroomSurfaceBiome>()) && spawnInfo.Water)
        {
            return 0.33f;
        }

        return 0f;
    }

    public override void HitEffect(NPC.HitInfo hit)
    {
        NPCHelper.DoHitDust(NPC, hit.HitDirection, DustID.Bone);
        NPCHelper.CreateGoreOnDeath(NPC, "InfectedAnglerFishSkeletonGore1");
        NPCHelper.CreateGoreOnDeath(NPC, "InfectedAnglerFishSkeletonGore2");
        NPCHelper.CreateGoreOnDeath(NPC, "InfectedAnglerFishSkeletonGore3");
    }
}