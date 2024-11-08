using System.IO;
using System.Numerics;
using BiomeExpansion.Content.Biomes;
using BiomeExpansion.Content.Buffs;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.NPCs
{
    public class CorruptionInfectedSmallFly : ModNPC
    {
        public override string Texture => TextureHelper.DynamicNPCsTextures["CorruptionInfectedSmallFly"];

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 4;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
            NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[NPC.type] = true;
            // Change and uncomment the next line if the fly should be immune to anything
            //NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.INSERT_DEBUFF_HERE] = true;
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter += 1.0;
            NPC.frameCounter %= 120.0;
            NPC.frame.Y = frameHeight * ((int)NPC.frameCounter % 20 / 5);
        }


        public override void SetDefaults()
        {
            NPC.aiStyle = NPCAIStyleID.Butterfly;
            NPC.CloneDefaults(NPCID.Butterfly);
            AIType = NPCID.Butterfly;
            AnimationType = NPC.type;
            SpawnModBiomes = [ModContent.GetInstance<CorruptionInfectedMushroomSurfaceBiome>().Type];
            // When an item sprite is made, uncomment the next line
            //NPC.catchItem = ModContent.ItemType<CorruptionInfectedFlyNPC>();
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,
            new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CorruptionInfectedFly")
            });
        }

        public override void AI()
        {
            if (NPC.velocity.X > 0)
            {
                NPC.direction = 1;
                NPC.spriteDirection = 1;
            }
            else
            {
                NPC.direction = -1;
                NPC.spriteDirection = -1;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome<CorruptionInfectedMushroomSurfaceBiome>() && spawnInfo.Player.ZoneOverworldHeight)
            {
                return 0.1f;
            }

            return 0f;
        }
    }
}