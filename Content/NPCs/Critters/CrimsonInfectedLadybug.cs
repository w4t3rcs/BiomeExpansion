﻿using BiomeExpansion.Content.Biomes;

namespace BiomeExpansion.Content.NPCs.Critters
{
    public class CrimsonInfectedLadybug : ModNPC
    {
        public override string Texture => TextureHelper.DynamicNPCsTextures["CrimsonInfectedLadybug"];

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 8;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
            NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.LadyBug);
            AnimationType = NPCID.LadyBug;
            AIType = NPCID.LadyBug;
            NPC.aiStyle = NPCAIStyleID.Ladybug;
            NPC.catchItem = ModContent.ItemType<Items.NPCs.Critters.CrimsonInfectedLadybug>();
            SpawnModBiomes = [ModContent.GetInstance<CrimsonInfectedMushroomSurfaceBiome>().Type];
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange([
                new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CrimsonInfectedLadybug")
            ]);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome<CrimsonInfectedMushroomSurfaceBiome>())
            {
                return 0.2f;
            }

            return 0f;
        }
    }
}
