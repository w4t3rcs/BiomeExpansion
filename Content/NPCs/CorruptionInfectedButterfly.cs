using System.IO;
using BiomeExpansion.Content.Biomes;
using BiomeExpansion.Content.Buffs;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.NPCs
{
    public class CorruptionInfectedButterfly : ModNPC
    {
        public override string Texture => TextureHelper.DynamicNPCsTextures["CorruptionInfectedButterfly"];

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 3;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
            NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Butterfly);
            AIType = NPCID.Butterfly;
            NPC.aiStyle = NPCAIStyleID.Butterfly;
            SpawnModBiomes = [ModContent.GetInstance<CorruptionInfectedMushroomSurfaceBiome>().Type];
        }

        public override void FindFrame(int frameHeight)
        {
            Vector2 direction = NPC.velocity;
            direction.Normalize();
            NPC.spriteDirection = NPC.direction = NPC.velocity.X > 0 ? 1 : -1;
            if (++NPC.frameCounter >= 6)
            {
                NPC.frameCounter = 0;
                NPC.frame.Y = (NPC.frame.Y + frameHeight) % (frameHeight * 3);
            }
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange([
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,
                new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CorruptionInfectedButterfly")
            ]);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome<CorruptionInfectedMushroomSurfaceBiome>())
            {
                return 0.2f;
            }

            return 0f;
        }
    }
}
