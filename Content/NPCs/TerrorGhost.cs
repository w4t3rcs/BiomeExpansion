using BiomeExpansion.Content.Biomes;
using BiomeExpansion.Content.Buffs;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.NPCs;

public class TerrorGhost : ModNPC
{
    protected int leftHandID = -1;
    protected int rightHandID = -1;
    
    public override string Texture => TextureHelper.DynamicNPCsTextures["TerrorGhost"];

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
        NPC.lifeMax = 26;
        NPC.knockBackResist = 0f;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
        NPC.value = Item.buyPrice(0, 0, 5, 0);
        NPC.HitSound = SoundID.NPCHit5;
        NPC.DeathSound = SoundID.NPCDeath7;
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
        if (!Main.npc.IndexInRange(leftHandID) || !Main.npc[leftHandID].active || Main.npc[leftHandID].type != ModContent.NPCType<TerrorGhostHand>())
        {
            leftHandID = NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X - 40, (int)NPC.Bottom.Y, ModContent.NPCType<TerrorGhostHand>(), ai0: NPC.whoAmI, ai1: leftHandID);
        }
        if (!Main.npc.IndexInRange(rightHandID) || !Main.npc[rightHandID].active || Main.npc[rightHandID].type != ModContent.NPCType<TerrorGhostHand>())
        {
            rightHandID = NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X + 40, (int)NPC.Bottom.Y, ModContent.NPCType<TerrorGhostHand>(), ai0: NPC.whoAmI, ai1: leftHandID);
        }
        NPC.TargetClosest(true);
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
        {
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,
            new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.TerrorGhost")
        });
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.Player.InModBiome<CorruptionInfectedMushroomSurfaceBiome>() || spawnInfo.Player.InModBiome<CrimsonInfectedMushroomSurfaceBiome>())
        {
            return 0.10f;
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

    public override void SetDefaults()
    {
        NPC.aiStyle = -1;
        NPC.lifeMax = 100;
        NPC.damage = 30;
        NPC.width = 32;
        NPC.height = 24;
        NPC.knockBackResist = 0f;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
        NPCHelper.AdjustExpertMode(NPC);
        NPCHelper.AdjustMasterMode(NPC);
    }
    
    public override void AI()
    {   
        Lighting.AddLight(NPC.Center, 0.6f, 0.0f, 0.6f);
        NPC parent = Main.npc[(int)NPC.ai[0]];
        if (parent != null && parent.active)
        {
        }
        else
        {
            NPC.active = false;
        }

        NPC.TargetClosest(true);
    }
}