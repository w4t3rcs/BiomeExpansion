﻿using BiomeExpansion.Content.Biomes;

namespace BiomeExpansion.Content.NPCs
{
    public class CrimsonInfectedCrab : ModNPC
    {
        public override string Texture => TextureHelper.DynamicNPCsTextures["CrimsonInfectedCrab"];

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 5;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Crab);
            AnimationType = NPCID.Crab;
            AIType = NPCID.Crab;
            NPC.aiStyle = NPCAIStyleID.Fighter;
            SpawnModBiomes = [ModContent.GetInstance<CrimsonInfectedMushroomSurfaceBiome>().Type];
            NPCHelper.AdjustExpertMode(NPC);
            NPCHelper.AdjustMasterMode(NPC);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange([
                new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CrimsonInfectedCrab")
            ]);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome<CrimsonInfectedMushroomSurfaceBiome>())
            {
                return 0.1f;
            }

            return 0f;
        }
    }
}